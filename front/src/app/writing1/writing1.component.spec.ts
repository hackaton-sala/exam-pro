import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Writing1Component } from './writing1.component';

describe('Writing1Component', () => {
  let component: Writing1Component;
  let fixture: ComponentFixture<Writing1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Writing1Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Writing1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
