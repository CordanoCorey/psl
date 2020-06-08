import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarriersGridComponent } from './carriers-grid.component';

describe('CarriersGridComponent', () => {
  let component: CarriersGridComponent;
  let fixture: ComponentFixture<CarriersGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarriersGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarriersGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
