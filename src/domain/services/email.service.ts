import { MailerService } from "@nestjs-modules/mailer";
import { Injectable } from "@nestjs/common";
import { User } from "@prisma/client";
import { join } from "path";

@Injectable()
export class EmailService {
  constructor(private mailService: MailerService) {}

  async sendEmailBoasVindas(user: User, key: string) {
    const confirmUrl = `${process.env.HOST}/v1/user/confirmEmail/${key}`;

    const nome =
      user.nome === null ? user.email : `${user.nome} ${user.sobreNome}`;

    const sendEmail = await this.mailService.sendMail({
      to: user.email,
      subject: "Bem Vindo ao Bora Rachar! Confirme seu email",
      template: join(__dirname, "../../common/templates", "bemvindo"),
      context: {
        nome,
        confirmUrl,
      },
    });

    console.log("SendEmail: ", JSON.stringify(sendEmail));
  }
}