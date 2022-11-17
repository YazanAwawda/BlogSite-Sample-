import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comment } from '../model/comment';

@Injectable({
  providedIn: 'root'
})
export class AddCommentService {

  constructor(private http: HttpClient) { }

  addComment(comment: Comment) {
    return this.http.post('https://localhost:7265/api/Comment/post', comment);
  }

  getComments(postId: number): Observable<Comment[]> {
    return this.http.get<Comment[]>('https://localhost:7265/api/Comment/findComment/' + postId);
  }

  getUserCommentCount(username: string) {
    return this.http.get('https://localhost:7265/api/Comment/userComment/' + username);
  }

  updateComment(id: number, newComment: string) {
    return this.http.put('https://localhost:7265/api/Comment/edit/' + id, { Id: id, newComment: newComment });
  }

  deleteComment(id: number) {
    return this.http.delete('https://localhost:7265/api/Comment/delete/' + id);
  }

  deleteAllComment(postId: number) {
    return this.http.delete('https://localhost:7265/api/Comment/deleteAll/' + postId);
  }
}
