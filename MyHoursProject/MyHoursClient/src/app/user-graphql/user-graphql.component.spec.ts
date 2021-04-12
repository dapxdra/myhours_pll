import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserGraphqlComponent } from './user-graphql.component';

describe('UserGraphqlComponent', () => {
  let component: UserGraphqlComponent;
  let fixture: ComponentFixture<UserGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
