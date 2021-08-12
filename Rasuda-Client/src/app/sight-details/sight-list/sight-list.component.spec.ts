import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SightListComponent } from './sight-list.component';

describe('SightListComponent', () => {
  let component: SightListComponent;
  let fixture: ComponentFixture<SightListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SightListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SightListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
