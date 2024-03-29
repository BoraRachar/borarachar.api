/* eslint-disable  @typescript-eslint/no-explicit-any */
import { Injectable } from "@nestjs/common";
import { PassportStrategy } from "@nestjs/passport";
import { Strategy } from "passport-instagram";
import "dotenv/config";
import { InstagramProvider } from "../../../infrastructure/providers/instagram.provider";

@Injectable()
export class InstagramStrategy extends PassportStrategy(Strategy) {
  constructor(private readonly provider: InstagramProvider) {
    super({
      clientID: provider.clientID,
      clientSecret: provider.clientSecret,
      callbackURL: provider.callBackURL,
      scope: provider.scope,
      code: provider.response_type,
      grant_type: provider.grant_type,
    });
  }

  async validate(
    accessToken: string,
    refreshToken: string,
    profile: any,
    done: any,
  ) {
    done(null, profile);
  }
}
