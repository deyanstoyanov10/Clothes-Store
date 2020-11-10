import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { Type } from './../categoriesType.model';
import { ToastrService } from 'ngx-toastr';
import { CategoriesService } from '../categories.service';
import { Category } from '../category.model';

function enumSelector(definition) {
  return Object.keys(definition)
    .map(key => ({ value: definition[key], title: key }));
}

function isNumber(c : AbstractControl) : ValidationErrors | null {
  return !isNaN(c.value) ? null : { isNumber: true};
}

@Component({
  selector: 'app-categories-create',
  templateUrl: './categories-create.component.html',
  styleUrls: ['./categories-create.component.css']
})
export class CategoriesCreateComponent implements OnInit {

  public types = enumSelector(Type);
  category: Category;
  categoryForm : FormGroup;

  constructor(private fb: FormBuilder,
      private categoriesService: CategoriesService, 
      private toastr: ToastrService) {

        this.types.splice(0 , this.types.length / 2);

        this.categoryForm = this.fb.group({
          type : ['', [Validators.required, isNumber]],
          name : ['', [Validators.required, Validators.maxLength(50)]]
        });
    
   }

  ngOnInit(): void {
  }

  create() {
    const type = parseInt(this.categoryForm.value.type);
    const name = this.categoryForm.value.name;

    const vals = { type, name };
    this.categoriesService.createCategory(vals).subscribe(res => {
      if(res) {
        this.toastr.success("Successfully created category.");
        this.categoryForm.reset();
      }
      console.log(res);
    });
    
  }

  get type() {
    return this.categoryForm.get('type');
  }

  get name() {
    return this.categoryForm.get('name');
  }
}
