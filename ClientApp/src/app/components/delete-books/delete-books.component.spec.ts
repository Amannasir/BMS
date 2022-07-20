import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteBooksComponent } from './delete-books.component';

describe('DeleteBooksComponent', () => {
  let component: DeleteBooksComponent;
  let fixture: ComponentFixture<DeleteBooksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteBooksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
