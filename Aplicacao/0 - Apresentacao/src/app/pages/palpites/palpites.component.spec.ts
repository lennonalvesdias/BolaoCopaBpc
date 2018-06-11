import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PalpitesComponent } from './palpites.component';

describe('PalpitesComponent', () => {
  let component: PalpitesComponent;
  let fixture: ComponentFixture<PalpitesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PalpitesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PalpitesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
