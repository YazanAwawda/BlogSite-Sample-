import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http: HttpClient) { }

  // addUser(user: User){
  //   let users = [];
  //   if(localStorage.getItem('Users')) {
  //     users = JSON.parse(localStorage.getItem('Users'));
  //     users = [...users, user];
  //   } else {
  //     users = [user];
  //   }
  //   localStorage.setItem('Users', JSON.stringify(users));
  // }

  addUser(user: User) {
    return this.http.post('https://localhost:7265/api/User/post', user);
  }

  banUser(id: number) {
    return this.http.put('https://localhost:7265/api/User/ban/' + id, id);
  }

  adminUser(id: number) {
    return this.http.put('https://localhost:7265/api/User/admin/' + id, id);
  }

  getUserByName(name: string): Observable<string[]> {
    return this.http.get<string[]>('https://localhost:7265/api/User/get/' + name);
  }

}
