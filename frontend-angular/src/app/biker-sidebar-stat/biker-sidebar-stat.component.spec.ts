import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikerSidebarStatComponent } from './biker-sidebar-stat.component';

describe('BikerSidebarStatComponent', () => {
  let component: BikerSidebarStatComponent;
  let fixture: ComponentFixture<BikerSidebarStatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikerSidebarStatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikerSidebarStatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
