import {
  TestBed,
  ComponentFixture,
} from '@angular/core/testing';

import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { SiteLayoutComponent } from './site-layout.component';

let component: SiteLayoutComponent;
let fixture: ComponentFixture<SiteLayoutComponent>;
let page: Page;

describe('SiteLayoutComponent', () => {

  beforeEach(() => {

    TestBed.configureTestingModule({
      declarations: [
        SiteLayoutComponent,
      ],
      providers: [],
      imports: []
    });

    fixture = TestBed.createComponent(SiteLayoutComponent);
    component = fixture.componentInstance;
    page = new Page();

  });

  it('needs tests', () => {

    expect(false).toBeTruthy();

  });

});

class Page {

  constructor() {

  }

  getPageElements() {

  }

}