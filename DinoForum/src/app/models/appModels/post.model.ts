import { Comment } from "./comment";
import { User } from "./user.model";

export class Post {
    postId: string;
    title: string;
    content: string;
    dateTime: Date;
    user: User;
    comments: Comment[];
}