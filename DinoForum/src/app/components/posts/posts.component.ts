import { Component, OnInit } from '@angular/core';
import { PostsService } from 'src/app/services/posts.service';
import { Post } from 'src/app/models/appModels/post.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.sass']
})
export class PostsComponent implements OnInit {

  posts: Post[];

  constructor(private postsService: PostsService, private router: Router) { }

  ngOnInit() {
    this.postsService.getAllPosts().subscribe(response => {
      this.posts = response.posts;
      console.log(this.posts)
    });
  }

  viewPost(postId: string) {
    console.log(postId)
    this.router.navigate(['/post', postId]);
  }
}