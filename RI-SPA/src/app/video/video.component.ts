import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {

  videos: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getVideos();

  }

  getVideos(){
    this.http.get('http://localhost:5000/api/videos').subscribe(response => {
      this.videos = response;
    }, error => {
      console.log(error);
    });
  }

}
