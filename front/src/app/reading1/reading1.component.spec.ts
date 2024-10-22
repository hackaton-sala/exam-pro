import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Reading1Component } from './reading1.component';

describe('Reading1Component', () => {
  let component: Reading1Component;
  let fixture: ComponentFixture<Reading1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Reading1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Reading1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
