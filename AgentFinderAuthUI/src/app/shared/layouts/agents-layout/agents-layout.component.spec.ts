import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgentsLayoutComponent } from './agents-layout.component';

describe('AgentsLayoutComponent', () => {
  let component: AgentsLayoutComponent;
  let fixture: ComponentFixture<AgentsLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgentsLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgentsLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
