import { Component, Injectable, Input, OnInit } from '@angular/core';
import { Blog } from '../model/blog';

@Component({
  selector: 'app-blog-card',
  templateUrl: './blog-card.component.html',
  styleUrls: ['./blog-card.component.css']
})

export class BlogCardComponent {

  @Input() post: any
  constructor() { }



}
