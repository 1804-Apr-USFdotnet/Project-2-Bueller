import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookByClassComponent } from './book-by-class.component';

describe('BookByClassComponent', () => {
  let component: BookByClassComponent;
  let fixture: ComponentFixture<BookByClassComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookByClassComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookByClassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
