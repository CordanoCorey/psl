import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutingsGridComponent } from './routings-grid.component';

describe('RoutingsGridComponent', () => {
  let component: RoutingsGridComponent;
  let fixture: ComponentFixture<RoutingsGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoutingsGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoutingsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
