import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { employeComponent } from './employe.component';

describe('employeComponent', () => {
  let component: employeComponent;
  let fixture: ComponentFixture<employeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ employeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(employeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
