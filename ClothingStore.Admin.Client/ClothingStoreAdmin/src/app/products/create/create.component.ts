import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.loadScript();
    this.loadSwitch();
  }

  public loadScript() {
    let body = <HTMLDivElement> document.body;
    let script = document.createElement('script');
    script.innerHTML = `$(function () {
      $('.textarea').summernote()
    })`;
    body.appendChild(script);
  }

  public loadSwitch() {
    let body = <HTMLDivElement> document.body;
    let script = document.createElement('script');
    script.innerHTML = `$("input[data-bootstrap-switch]").each(function(){
      $(this).bootstrapSwitch('state', $(this).prop('checked'));
    });
    
    $('.select2bs4').select2({
      theme: 'bootstrap4'
    })`;
    body.appendChild(script);
  }
}
