import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Blog } from '../model/blog';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private http: HttpClient) { }

  // getPost(id: number) {
  //   console.log(this.getAllPosts());
  //   return this.getAllPosts().pipe(
  //     map(post => {
  //       return post.find(p => p.Id === id);
  //     })
  //   );
  // }

  // tslint:disable-next-line: typedef
  getPost(id: number) {
    return this.http.get('https://localhost:7265/api/Post/findPost/' + id);
  }

  // https://localhost:7265/api/Post?

  getAllPosts(): Observable<Blog[]> {
    return this.http.get<Blog[]>('https://localhost:7265/api/Post');
  }

  // tslint:disable-next-line: typedef
  getUserPosts(userName: string) {
    return this.http.get<Blog[]>('https://localhost:7265/api/Post/userPost/' + userName);
  }

  // tslint:disable-next-line: typedef
  updatePost(id: number, title: string, description: string) {
    return this.http.put('https://localhost:7265/api/Post/edit/' + id,
      { Id: id, newTitle: title, newDescription: description });
  }

  // tslint:disable-next-line: typedef
  deletePost(id: number) {
    return this.http.delete('https://localhost:7265/api/Post/delete/' + id);
  }
}
