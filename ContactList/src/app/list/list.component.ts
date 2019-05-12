import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Data } from '../data';
import { PassContactService } from '../pass-contact.service';
import { routes } from '../routing/routing.module';
import { Router } from '@angular/router';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  apiValue: any;
  contactId: number;


  constructor(private http: Http,
    private contactData: PassContactService,
    private data: PassContactService,
    private router: Router) {

  }

  ngOnInit() {
    //this.http.get("/api/getallcontactserror").subscribe(result => {
    //  this.apiValue = result.json();
    //  console.log(result);
    //});
    this.apiValue = Data;
    this.data.currentMessage.subscribe(contactId => this.contactId = contactId)
  }

  newMessage(id: number) {
    this.data.changeMessage(id);
  }

  goToContact(id: number) {
    console.log("evo me");
    this.newMessage(id);
    this.router.navigate(['/contact']);
  }

  //passContact(id) {
  //  this.contactData.passContact(Data[id]);
  //}

  submitOnEnter(event) {
    if (event.keyCode === 13) {
      event.preventDefault();

    }
  }
}
