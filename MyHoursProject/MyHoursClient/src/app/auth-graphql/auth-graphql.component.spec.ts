import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthGraphqlComponent } from './auth-graphql.component';

describe('AuthGraphqlComponent', () => {
  let component: AuthGraphqlComponent;
  let fixture: ComponentFixture<AuthGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
