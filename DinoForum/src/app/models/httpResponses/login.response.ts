import { User } from "../appModels/user.model";

export class LoginResponse {
    user: User;
    isAuthenticated: boolean;
    message: string;
}