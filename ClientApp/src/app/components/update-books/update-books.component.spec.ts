import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateBooksComponent } from './update-books.component';

describe('UpdateBooksComponent', () => {
  let component: UpdateBooksComponent;
  let fixture: ComponentFixture<UpdateBooksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateBooksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
