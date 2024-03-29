import {
  BadRequestException,
  HttpException,
  HttpStatus,
  Injectable,
} from "@nestjs/common";
import { PrismaService } from "./prisma.service";
import { User, Prisma, TypeEmail } from "@prisma/client";
import { EmailService } from "./email.service";
import { KeyService } from "./key.service";
import { JsonObject } from "@prisma/client/runtime/library";
import { encryptPass } from "../core/hashPassword";
import { TypeKeys } from "../../common/constants/key.default";
import { ResetPasswordDto } from "../dto/reset-password.dto";
import { UserResponseDto } from "../dto/Response/user-response.dto";

@Injectable()
export class UserService {
  constructor(
    private prisma: PrismaService,
    private emailService: EmailService,
    private keyService: KeyService,
  ) {}

  async findOneUserbyEmail(email: string): Promise<{ [p: string]: unknown }> {
    const user = await this.prisma.user.findUnique({
      where: { email: email },
    });
    const userWithoutPassword = this.exclude(user, ["password"]);
    return userWithoutPassword;
  }

  exclude<User, Key extends keyof User>(
    user: User,
    keys: Key[],
  ): { [p: string]: unknown } {
    return Object.fromEntries(
      Object.entries(user).filter(([key]) => {
        // eslint-disable-next-line @typescript-eslint/ban-ts-comment
        // @ts-ignore
        return !keys.includes(key);
      }),
    );
  }

  async findOneUserbySocialId(socialId: string): Promise<User | null> {
    const user = await this.prisma.user.findUnique({
      where: { socialId: socialId },
    });
    return user;
  }

  async findOneUserById(userId: string): Promise<{ [p: string]: unknown }> {
    const user = await this.prisma.user.findUnique({
      where: { id: userId },
    });
    const userWithoutPassword = this.exclude(user, ["password"]);

    return userWithoutPassword;
  }

  async socialUserCreate(data: Prisma.UserCreateInput): Promise<User> {
    const existUser = await this.prisma.user.findUnique({
      where: { email: data.email },
    });

    if (existUser == null) {
      const user = await this.prisma.user.create({ data });

      const key = await this.keyService.createKeyConfirmEmail(user);

      await this.emailService.sendEmailBoasVindas(user, key.value);

      return user;
    } else {
      return existUser;
    }
  }

  async validUser(email) {
    const now = new Date();

    const user = await this.prisma.user.findUnique({
      where: {
        email: email,
      },
    });
    console.info("UserValid: ", user != null ? user.id : "Invalido");

    if (user != null) {
      const keys = await this.prisma.key.findMany({
        where: {
          userId: user.id,
          type: "Cadastro",
        },
      });

      console.info("KeysCount: ", keys.length);

      for (const key in keys) {
        console.info("KeyUpdate: ", key);
        await this.prisma.key.update({
          where: {
            id: keys[key].id,
          },
          data: {
            status: false,
          },
        });
      }

      const newKey = await this.keyService.createKey(
        user,
        TypeKeys.ResendEmailConfirmar,
      );

      console.info("NewKey: ", newKey.value);

      await this.prisma.email.create({
        data: {
          userId: user.id,
          createdAt: now,
          type: TypeEmail.Cadastro,
        },
      });

      await this.emailService.sendEmailBoasVindas(user, newKey.value);

      return true;
    } else {
      return false;
    }
  }

  async createUser(data): Promise<JsonObject> {
    const exist = await this.prisma.user.findUnique({
      where: {
        email: data.email,
      },
    });

    if (exist != null) {
      throw new HttpException("Usuario já Cadastrado ", HttpStatus.BAD_REQUEST);
    }

    const user = await this.prisma.user.create({
      data: {
        nome: data.nome,
        sobreNome: data.sobrenome,
        email: data.email,
        password: await encryptPass(data.password),
      },
    });

    const key = await this.keyService.createKeyConfirmEmail(user);

    await this.emailService.sendEmailBoasVindas(user, key.value);

    if (user != null) {
      return {
        statusCode: 201,
        message: "Usuario criado com sucesso",
        url: `${process.env.HOST}/user/confirmEmail/${key.value}`,
      };
    } else {
      throw new HttpException(
        "Falha ao criar o usuario.",
        HttpStatus.BAD_REQUEST,
      );
    }
  }

  async completeSignUp(
    userId: string,
    data: Prisma.UserUpdateInput,
  ): Promise<User> {
    const user = await this.prisma.user.findUnique({
      where: { id: userId },
    });

    const existCpf = await this.prisma
      .$queryRaw`SELECT * FROM users WHERE cpf = ${data.cpf}`;

    if (existCpf[0] != null) {
      throw new HttpException("CPF já Cadastrado", HttpStatus.BAD_REQUEST);
    }

    if (!user)
      throw new HttpException("Usuário não encontrado", HttpStatus.NOT_FOUND);

    const updatedUser = await this.prisma.user.update({
      where: { id: userId },
      data: {
        ...data,
        updatedAt: new Date(),
      },
    });

    return updatedUser;
  }

  async recoverPassword(email: string) {
    const userExists = await this.prisma.user.findUnique({
      where: { email },
    });

    console.info("userExists: ", userExists ? userExists.id : "Não encontrado");

    if (!userExists || !userExists.validateUser) {
      throw new HttpException("Usuario não encontrado", HttpStatus.NOT_FOUND);
    }

    await this.emailService.sendRecoverPasswordEmail(userExists, email);

    return {
      statusCode: HttpStatus.CREATED,
      message: "Email de recuperação enviado!",
    };
  }

  async resetPassword(data: ResetPasswordDto) {
    const userExists = await this.prisma.user.findUnique({
      where: { email: data.email },
    });

    console.info(
      "userExists: ",
      userExists !== null ? userExists.id : "Não encontrado",
    );

    if (userExists === null) throw new HttpException("", HttpStatus.NOT_FOUND);

    if (data.password != data.confirmPassword)
      throw new BadRequestException("As senhas inseridas não são iguais!");

    await this.prisma.user.update({
      where: {
        email: data.email,
      },
      data: {
        password: await encryptPass(data.password),
      },
    });

    return {
      data: [{ email: userExists.email }],
      statusCode: HttpStatus.OK,
      message: "Sua senha foi redefinida com sucesso!",
    };
  }
}
