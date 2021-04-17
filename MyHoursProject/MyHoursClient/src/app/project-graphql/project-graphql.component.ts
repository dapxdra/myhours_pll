import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { PROJECT_QUERY } from './queries';
import { CREATE_PROJECT, DELETE_PROJECT } from './mutations';

@Component({
  selector: 'app-project-graphql',
  templateUrl: './project-graphql.component.html',
  styleUrls: ['./project-graphql.component.scss']
})
export class ProjectGraphqlComponent implements OnInit {

  public projects: any;
  public currentProject: any;
  public isFormVisible = false;
  public projectname = null
  public isActive = true;

  constructor(private apollo: Apollo) { 
    this.projects = [];}

  ngOnInit(): void {
    this.filter();
  }

  reset(){
    this.currentProject = {
      projectname: ''
    };
    this.isFormVisible = false;
  }

  // user(user: any){
  //   return user.projects.map((b:any) => b.projectname).join(', ');
  // }

  filter() {
    this.apollo.watchQuery({
      query: PROJECT_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        name: this.projectname === '' ? null : this.projectname
      }
    }).valueChanges.subscribe(result => {
      this.projects = result.data;
      this.reset();
    });
  }

  delete(id: number){
    this.apollo.mutate({
      mutation: DELETE_PROJECT,
      variables: {
        id: id
      }
    }).subscribe(() => {
      this.filter();
    });
  }

  save() {
    let project = {
      projectname: this.currentProject.projectname,
      isActive: this.currentProject.isActive
    };
    this.apollo.mutate({
      mutation: CREATE_PROJECT,
      variables: {
        project: project
      }
    }).subscribe(() => {
      this.filter();
    });
  }

}
