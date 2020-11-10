import { ToastrService } from 'ngx-toastr';
import { Category } from './../category.model';
import { Type } from './../categoriesType.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


function enumSelector(definition) {
  return Object.keys(definition)
    .map(key => ({ value: definition[key], title: key }));
}

@Component({
  selector: 'app-categories-edit',
  templateUrl: './categories-edit.component.html',
  styleUrls: ['./categories-edit.component.css']
})

export class CategoriesEditComponent implements OnInit {

  public types = enumSelector(Type);
  id: string;
  category: Category;
  categoryForm : FormGroup;

  constructor(private fb: FormBuilder,
      private route: ActivatedRoute,
      private categoriesService: CategoriesService, 
      private toastr: ToastrService,
      private router : Router) {
    this.types.splice(0 , this.types.length / 2);

    this.id = this.route.snapshot.paramMap.get('id');
    
    this.categoryForm = this.fb.group({
      type : [0, [Validators.required]],
      name : ['', [Validators.required,Validators.maxLength(50)]]
    });
   }

  ngOnInit(): void {
    this.fetchCategory();
  }

  fetchCategory() {
    this.categoriesService.getCategory(this.id).subscribe(category => {
      this.category = category;
      this.categoryForm = this.fb.group({
        type : [this.category.type, [Validators.required]],
        name : [this.category.name, [Validators.required]]
      });
    });
  }

  edit() {
    const type = parseInt(this.categoryForm.value.type);
    const name = this.categoryForm.value.name;

    const vals = { type, name };
    this.categoriesService.editCategory(this.id, vals).subscribe(res => {
      if(res == null) {
        this.toastr.success("Successfully updated category.");
      }
    });
    
  }

  delete() {
    this.categoriesService.deleteCategory(this.id).subscribe(res => {
      if(res == null) {
        this.toastr.success("Successfully deleted category.");
        this.router.navigate(['/categories/list']).then(() => window.location.reload());
      }
    });
  }

  get type() {
    return this.categoryForm.get('type');
  }

  get name() {
    return this.categoryForm.get('name');
  }
}
