import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DealersGridComponent } from './dealers-grid.component';

describe('DealersGridComponent', () => {
  let component: DealersGridComponent;
  let fixture: ComponentFixture<DealersGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DealersGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DealersGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
