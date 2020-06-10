import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeframeControlComponent } from './timeframe-control.component';

describe('TimeframeControlComponent', () => {
  let component: TimeframeControlComponent;
  let fixture: ComponentFixture<TimeframeControlComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimeframeControlComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeframeControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
