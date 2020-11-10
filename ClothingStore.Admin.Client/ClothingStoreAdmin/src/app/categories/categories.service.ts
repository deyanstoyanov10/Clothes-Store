import { Category } from './category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CategoryUpdateModel } from './categoryUpdate.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categoriesPath: string = environment.apiUrl + "categories/";
              
  constructor(private http : HttpClient) { }

  getCategories() : Observable<Array<Category>> {
    return this.http.get<Array<Category>>(this.categoriesPath);
  }

  getCategory(id: string) : Observable<Category> {
    return this.http.get<Category>(this.categoriesPath + id);
  }

  createCategory(category: CategoryUpdateModel) : Observable<any> {
    return this.http.post(this.categoriesPath, category);
  }

  editCategory(id: string, category: CategoryUpdateModel) : Observable<any> {
    return this.http.put(this.categoriesPath + id, category);
  }

  deleteCategory(id: string) : Observable<any> {
    return this.http.delete(this.categoriesPath + id);
  }
}
