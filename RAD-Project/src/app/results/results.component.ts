import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent implements OnInit {

  id: number;
  name: string;
  private sub: any;

  lectures: any;

  clicked: boolean;

  constructor(private route: ActivatedRoute, private httpService: HttpService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.name = params['name'];
      this.httpService.getLectures(this.id)
                      .subscribe(
                        lectures => this.lectures = lectures,
                        err => {
                            console.log(err);
                        });
   });
   this.clicked = false;
  }

  clickAlternator(){
    this.clicked = !this.clicked;
  }

}
