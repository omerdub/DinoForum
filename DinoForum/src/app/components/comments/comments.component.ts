import { Component, Input } from '@angular/core';
import { Comment } from 'src/app/models/appModels/comment';
@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.sass']
})
export class CommentsComponent {
  @Input() comments: Comment[];
}
