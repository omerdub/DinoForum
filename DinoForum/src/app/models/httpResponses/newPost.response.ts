import { Post } from "../appModels/post.model";

export class NewPostResponse {
    isPostCreated: boolean;
    post: Post;
}