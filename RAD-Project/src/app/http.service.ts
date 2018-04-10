import { Injectable }     from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import {Observable} from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpService {

  constructor (private http: Http) {} 

  getModules() : Observable<any[]> {
    //get a list of modules
    return this.http.get('http://localhost:2830/api/Modules')
                    .map((res:Response) => res.json())
                    .catch((error:any) => Observable.throw(error.json));
  }

  addModule (body: Object): Observable<any[]> {
    let bodyString = JSON.stringify(body);
    let headers      = new Headers({ 'Content-Type': 'application/json' });
    let options       = new RequestOptions({ headers: headers });

    return this.http.post('http://localhost:2830/api/Modules', body, options)
                     .map((res:Response) => res.json())
                     .catch((error:any) => Observable.throw(error.json));
}   

  getLecturers(): Observable<any[]> {
    return this.http.get('http://localhost:2830/Help/Api/GET-api-Modules')
                    .map((res:Response) => res.json())
                    .catch((error:any) => Observable.throw(error.json()));
  }

}
