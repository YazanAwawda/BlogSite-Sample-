import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../model/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryServices {

  apiUrl = 'https://localhost:7265/api/Category';
  Category: Category;
  constructor(private http: HttpClient) { }

  // tslint:disable-next-line: typedef
  getCategory(categoryID: number | any) {
    return this.http.get(`${this.apiUrl}/CategoryId/${categoryID}`);
  }

  // tslint:disable-next-line: typedef
  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}/AllGategories`);
  }

  // tslint:disable-next-line: typedef
  RemoveCategory(id: any) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  // tslint:disable-next-line: typedef
  UpdateCategory(id, Name, Description) {
    return this.http.put(`${this.apiUrl}/` + id,
      {
        Id: id,
        newName: Name,
        newDescription: Description
      });
  }


  // tslint:disable-next-line: typedef
  newCategory(category: Category) {
    return this.http.post(`${this.apiUrl}/`, category);
  }
}
