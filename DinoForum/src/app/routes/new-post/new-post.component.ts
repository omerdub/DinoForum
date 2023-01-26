import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NewPostRequest } from 'src/app/models/httpRequests/newPost.request';
import { PostsService } from 'src/app/services/posts.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.sass']
})
export class NewPostComponent implements OnInit {

  title = '';
  content = '';
  constructor(
    private postService: PostsService,
    private userService: UserService,
    private router: Router
  ) { }
  ngOnInit(): void {
  }

  onSubmit() {
    const newPostRequest = new NewPostRequest();
    newPostRequest.title = this.title;
    newPostRequest.content = this.content;
    newPostRequest.userId = this.userService.getLoggedInUser().userId;
    console.log(newPostRequest)
    this.postService.newPost(newPostRequest).subscribe(
      (response) => {
        if (response.isPostCreated) {
          this.router.navigate(['/post', response.post.postId]);
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
