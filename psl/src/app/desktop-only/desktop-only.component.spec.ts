import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DesktopOnlyComponent } from './desktop-only.component';

describe('DesktopOnlyComponent', () => {
  let component: DesktopOnlyComponent;
  let fixture: ComponentFixture<DesktopOnlyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DesktopOnlyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DesktopOnlyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
