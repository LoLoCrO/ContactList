import { Component, OnInit } from '@angular/core';
import { PassContactService } from '../pass-contact.service';
import { Data } from '../data';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  contactId: number;
  //contact = {
  //  fullName: Data[this.contactId].firstName,
  //  lastName: Data[this.contactId].lastName,
  //  address: Data[this.contactId].address,
  //  bookmarked: Data[this.contactId].bookmarked.toString()
  //};
  //contactKeyed = Object.keys(this.contact);
  //contactProperties = [];
  contact = Data[this.contactId];
  //contactDefaults = {
  //  firstName: Data[this.contactId].firstName,
  //  lastName: Data[this.contactId].lastName,
  //  address: Data[this.contactId].address,
  //  bookmarked: Data[this.contactId].bookmarked
  //};
  //contactProps = Object.keys(this.contact);
  //contactNumbers = Object.keys(this.contact.numbers);
  //contactEmails = Object.keys(this.contact.emails);
  //contactTags = Object.keys(this.contact.tags);

constructor(private data: PassContactService) { }

  ngOnInit() {
    this.data.currentMessage.subscribe(contactId => this.contactId = contactId);
    //for (let prop of this.contactKeyed) {
    //  this.contactProperties.push(this.contactKeyed[prop]);
    //}
    console.log(this.contactId);
    console.log(Data[this.contactId]);
}
}
