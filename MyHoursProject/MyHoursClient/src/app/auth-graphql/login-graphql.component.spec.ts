import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginGraphqlComponent } from './login-graphql.component';

describe('LoginGraphqlComponent', () => {
  let component: LoginGraphqlComponent;
  let fixture: ComponentFixture<LoginGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
