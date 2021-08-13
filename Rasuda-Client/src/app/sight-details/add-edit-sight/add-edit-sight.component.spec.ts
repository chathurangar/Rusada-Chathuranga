import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditSightComponent } from './add-edit-sight.component';

describe('AddEditSightComponent', () => {
  let component: AddEditSightComponent;
  let fixture: ComponentFixture<AddEditSightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditSightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditSightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
