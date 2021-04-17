import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterGraphqlComponent } from './register-graphql.component';

describe('RegisterGraphqlComponent', () => {
  let component: RegisterGraphqlComponent;
  let fixture: ComponentFixture<RegisterGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
