import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from '../http.service';
import { Observable } from 'rxjs/Rx';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {

  id: number;
  name: string;
  private sub: any;

  students: any[];

  constructor(private route: ActivatedRoute, private httpService: HttpService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];
      this.name = params['name'];
      this.httpService.getStudents()
                      .subscribe(
                        student => this.students = student,
                        err => {
                            console.log(err);
                        });
    });
  }

}
