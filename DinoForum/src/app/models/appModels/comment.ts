import { User } from "./user.model";

export class Comment {
    CommentId: string;
    Content: string;
    DateTime: Date;
    User: User;
}
