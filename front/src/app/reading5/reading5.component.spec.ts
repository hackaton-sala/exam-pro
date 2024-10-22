import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Reading5Component } from './reading5.component';

describe('Reading5Component', () => {
  let component: Reading5Component;
  let fixture: ComponentFixture<Reading5Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Reading5Component]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Reading5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
