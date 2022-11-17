import { Component, Injectable, OnInit } from '@angular/core';
import { CategoryServices } from '../services/category.services';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})

@Injectable()
export class CategoryListComponent {

  categories: any[] = [];
  constructor(private CategoryService: CategoryServices) { }





  getCategories() {
    this.CategoryService.getAllCategories().subscribe((res: any) => {
      console.log(res);
      this.categories = res;
    }, err => {
      alert(err);
    }

    );
  }

}
