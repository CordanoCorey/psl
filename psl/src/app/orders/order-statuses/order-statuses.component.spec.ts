import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderStatusesComponent } from './order-statuses.component';

describe('OrderStatusesComponent', () => {
  let component: OrderStatusesComponent;
  let fixture: ComponentFixture<OrderStatusesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OrderStatusesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderStatusesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
