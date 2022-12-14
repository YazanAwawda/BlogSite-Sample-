import { Component, Injectable, OnInit } from '@angular/core';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [PostsService]
})
export class HomeComponent implements OnInit {

  //posts: Blog[];
  posts: any[];
  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
    this.postsService.getAllPosts().subscribe(
      post_data => {
        this.posts = post_data.reverse();
        console.log(this.posts);
      }, error => {
        console.log('error');
      }
    )
    // this.http.get('data/posts.json').subscribe(
    //   post_data=>{
    //     this.posts = post_data;
    //   }
    // );
  }

}
