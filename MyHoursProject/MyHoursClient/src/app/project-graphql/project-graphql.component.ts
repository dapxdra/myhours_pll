import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { GETU_QUERY, PROJECT_QUERY } from './queries';
import { CREATE_PROJECT, DELETE_PROJECT, EDIT_PROJECT, SUM_USER } from './mutations';
import { identifierModuleUrl } from '@angular/compiler';
import { CREATE_RELATION } from '@app/relation-graphql/mutations';

@Component({
  selector: 'app-project-graphql',
  templateUrl: './project-graphql.component.html',
  styleUrls: ['./project-graphql.component.scss']
})
export class ProjectGraphqlComponent implements OnInit {

  public users:any;
  public projects: any;
  public currentProject: any;
  public pname = null;
  public editname= null;
  public description = null;
  public editdesc= null;
  public isActive = true;
  public editactive=true;
  public temp = null;
  public isEditVisible = false
  public isFormVisible= false;
  public isTableUser =false;
  public projectId: any;


  public dashboard = '';
  public time= 0;

  constructor(private apollo: Apollo) { 
    this.projects = [];
    this.users = [];
  }

  ngOnInit(): void {
    this.filter();
  }

  reset(){
    this.currentProject = {
      pname: '',
      description: ''
    };
    this.isFormVisible = false;
    this.isEditVisible = false;
  }

  // user(user: any){
  //   return user.projects.map((b:any) => b.projectname).join(', ');
  // }

  filter() {
    this.apollo.watchQuery({
      query: PROJECT_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        pname: this.pname === '' ? null : this.pname
      }
    }).valueChanges.subscribe(result => {
      this.projects = result.data;
      this.reset();
    });
  }
  sumUser(id: number){
    let relation = {
      dashboard: this.dashboard,
      time: this.time,
      userId: id,
      projectId: this.projectId
    };
    this.apollo.mutate({
      mutation: SUM_USER,
      variables: {
        relation: relation
      }
    }).subscribe(() => {
      alert("Add succesfully");
      window.location.href ="http://localhost:4200/projects";
    });
  }
  getUsers(id: number){
    this.projectId=id;
    this.isTableUser=true;
    this.apollo.watchQuery({
      query: GETU_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        
      }
    }).valueChanges.subscribe(result => {
      var res: any;
      res = result;
      this.users = res.data.getusers;
      console.log(this.users);
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
  cargar(id: number){
    this.isEditVisible = true;
    this.temp = id;
  }
  edit(){
    
    let project = {
      pname: this.editname,
      description: this.editdesc,
      isActive: this.editactive

    };
    this.apollo.mutate({
      mutation: EDIT_PROJECT,
      variables: {
        id: this.temp,
        project: project
      }
    }).subscribe(() => {
      alert("Edit succesfully");
      window.location.href ="http://localhost:4200/projects";
      this.filter();
    });
  }

  save() {
    let project = {
      pname: this.currentProject.pname,
      description: this.currentProject.description,
      isActive: this.currentProject.isActive
    };
    this.apollo.mutate({
      mutation: CREATE_PROJECT,
      variables: {
        project: project
      }
    }).subscribe(() => {
      alert("Save succesfully");
      window.location.href ="http://localhost:4200/projects";
      this.filter();
    });
  }

  logout(){
    window.location.href = "http://localhost:4200/login"
  }

}
