import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelationGraphqlComponent } from './relation-graphql.component';

describe('RelationGraphqlComponent', () => {
  let component: RelationGraphqlComponent;
  let fixture: ComponentFixture<RelationGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RelationGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RelationGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
