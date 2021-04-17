import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectGraphqlComponent } from './project-graphql.component';

describe('ProjectGraphqlComponent', () => {
  let component: ProjectGraphqlComponent;
  let fixture: ComponentFixture<ProjectGraphqlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectGraphqlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectGraphqlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
