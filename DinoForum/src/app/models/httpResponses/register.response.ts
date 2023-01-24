import { User } from "../appModels/user.model";

export class RegisterResponse {
    user: User;
    isRegistered: boolean;
    message: string;
}