import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RoutingsMapComponent } from './routings-map.component';

describe('RoutingsMapComponent', () => {
  let component: RoutingsMapComponent;
  let fixture: ComponentFixture<RoutingsMapComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RoutingsMapComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RoutingsMapComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
