import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { formationComponent } from './formation.component';

describe('FormationComponent', () => {
  let component: formationComponent;
  let fixture: ComponentFixture<formationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ formationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(formationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
