//import { Injectable } from '@angular/core';
//import { BehaviorSubject } from 'rxjs';
//import { Data } from './data';

//@Injectable()
//export class PassContactService {
   
//  private contactDataSource = new BehaviorSubject(Data[1]);
//  currentData = this.contactDataSource.asObservable();

//  constructor() {
//    passContact(contact: Object) {
//      this.contactDataSource.next(contact);
//    }
//  }

//}


import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class PassContactService {

  private messageSource = new BehaviorSubject(22);
  currentMessage = this.messageSource.asObservable();

  constructor() { }

  changeMessage(message: number) {
    this.messageSource.next(message)
  }

}
