import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// material
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatButtonModule, MatFormFieldModule, MatGridListModule, MatCheckboxModule, MatToolbarModule, MatMenuModule, MatIconModule} from '@angular/material';
import { MatInputModule, MatSnackBarModule, MatTableModule, MatProgressSpinnerModule } from '@angular/material';
import { MatCardModule, MatSidenavModule, MatChipsModule } from '@angular/material';

// components
import { LandingComponent } from './landing/landing.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { ResultsComponent } from './results/results.component';
import { LoginComponent } from './login/login.component';
import { ClassListComponent } from './class-list/class-list.component';
import { HttpService } from './http.service';

const appRoutes: Routes = [
  { path: 'landing', component: LandingComponent },
  { path: 'class-list', component: ClassListComponent },
  { path: 'attendance/:id/:name', component: AttendanceComponent },
  { path: 'lectures/:id/:name', component: ResultsComponent },
  { path: 'login', component: LoginComponent},
  { path: '',
    redirectTo: '/class-list',
    pathMatch: 'full'
  },
  { path: '**', component: ClassListComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    LandingComponent,
    ResultsComponent,
    AttendanceComponent,
    LoginComponent,
    ClassListComponent
  ],
  imports: [
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatGridListModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatSidenavModule,
    MatChipsModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
