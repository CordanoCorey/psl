import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarriersMarketShareComponent } from './carriers-market-share.component';

describe('CarriersMarketShareComponent', () => {
  let component: CarriersMarketShareComponent;
  let fixture: ComponentFixture<CarriersMarketShareComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarriersMarketShareComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarriersMarketShareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
