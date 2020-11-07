import { CategoriesService } from './../categories.service';
import { Component, OnInit } from '@angular/core';
import { Category } from '../category.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  categoriesList: Array<Category>;
  constructor(private categoriesService : CategoriesService) { }

  ngOnInit(): void {
    this.fetchCategories();
  }

  fetchCategories() {
    this.categoriesService.getCategories().subscribe(categories => {
      this.categoriesList = categories;
    })
  }
}
