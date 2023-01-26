import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../models/appModels/post.model';
import { getAllPostsResponse as GetAllPostsResponse } from '../models/httpResponses/getAllPosts.response';
import { getPostByPostIdRequest } from '../models/httpRequests/getPostByPostId.request';
import { GetPostByPostIdResponse } from '../models/httpResponses/getPostByPostId.response';
import { NewCommentRequest } from '../models/httpRequests/newComment.request';
import { NewCommentResponse } from '../models/httpResponses/newComment.response';
import { NewPostRequest } from '../models/httpRequests/newPost.request';
import { NewPostResponse } from '../models/httpResponses/newPost.response';

@Injectable({
    providedIn: 'root'
})
export class PostsService {

    private baseUrl = environment.apiBaseUrl;

    constructor(private http: HttpClient) { }

    getAllPosts(): Observable<GetAllPostsResponse> {
        return this.http.get<GetAllPostsResponse>(`${this.baseUrl}/post/getallposts`);
    }

    getPostByPostId(postId: string): Observable<GetPostByPostIdResponse> {
        return this.http.get<GetPostByPostIdResponse>(`${this.baseUrl}/post/getpostbypostid?postId=${postId}`);
    }

    newComment(newCommentRequest: NewCommentRequest): Observable<NewCommentResponse> {
        return this.http.post<NewCommentResponse>(`${this.baseUrl}/post/newcomment`, newCommentRequest);
    }

    newPost(newPostRequest: NewPostRequest): Observable<NewPostResponse> {
        return this.http.post<NewPostResponse>(`${this.baseUrl}/post/newpost`, newPostRequest);
    }
}