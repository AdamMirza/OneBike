import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikerClockStatComponent } from './biker-clock-stat.component';

describe('BikerClockStatComponent', () => {
  let component: BikerClockStatComponent;
  let fixture: ComponentFixture<BikerClockStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikerClockStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikerClockStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
