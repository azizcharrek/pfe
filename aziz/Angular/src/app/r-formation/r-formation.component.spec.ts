import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RFormationComponent } from './r-formation.component';

describe('RFormationComponent', () => {
  let component: RFormationComponent;
  let fixture: ComponentFixture<RFormationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RFormationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RFormationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
