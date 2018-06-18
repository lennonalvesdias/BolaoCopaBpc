import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutDefault } from './default.component';

describe('DefaultComponent', () => {
  let component: LayoutDefault;
  let fixture: ComponentFixture<LayoutDefault>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutDefault ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutDefault);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
