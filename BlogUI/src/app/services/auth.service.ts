import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../model/user';
import { EncryptionService } from './encryption.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
    private encryptionService: EncryptionService) { }

  getAllUsers(): Observable<string[]> {
    return this.http.get<string[]>('https://localhost:7265/api/User');
  }

  // tslint:disable-next-line: typedef
  authUser(user: User, UserArray: User[]) {
    return UserArray.find(p => p.userName === user.userName && p.password === this.encryptionService.encryptPass(user.password));
  }
}
