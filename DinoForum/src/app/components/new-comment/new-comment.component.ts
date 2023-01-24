import { Component, Input } from '@angular/core';
import { PostsService } from 'src/app/services/posts.service';
import { NewCommentRequest } from 'src/app/models/httpRequests/newComment.request';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-new-comment',
  templateUrl: './new-comment.component.html',
  styleUrls: ['./new-comment.component.sass']
})
export class NewCommentComponent {
  @Input() postId: string;
  @Input() comments: Comment[];
  content = '';

  constructor(
    private postService: PostsService,
    private userService: UserService
  ) { }

  onSubmit() {
    const newCommentRequest = new NewCommentRequest();
    newCommentRequest.postId = this.postId;
    newCommentRequest.content = this.content;
    newCommentRequest.userId = this.userService.getLoggedInUser().userId;
    this.postService.newComment(newCommentRequest).subscribe(
      (response) => {
        if (response.isCommentAdded) {
          this.comments.push(response.comment);
        } else {
          alert("Error accured");
        }
      },
      (error) => {
        alert("Error accured");
      }
    );
  }
}