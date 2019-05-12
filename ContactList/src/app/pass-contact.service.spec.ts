/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PassContactService } from './pass-contact.service';

describe('PassContactService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PassContactService]
    });
  });

  it('should ...', inject([PassContactService], (service: PassContactService) => {
    expect(service).toBeTruthy();
  }));
});
