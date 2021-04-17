import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { USER_QUERY } from './queries';
import { CREATE_USER, DELETE_USER } from './mutations';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-user-graphql',
  templateUrl: './user-graphql.component.html',
  styleUrls: ['./user-graphql.component.scss']
})
export class UserGraphqlComponent implements OnInit {

  public users: any;
  public currentUser: any;
  public isFormVisible = false;
  public name = null;
  public lastname = null;
  public email = null;
  public password = null;
  constructor(private apollo: Apollo) { 
    this.users = [];
  }

  ngOnInit(): void {
    this.filter();
  }
  reset(){
    this.currentUser = {
      name: '',
      email: '',
      lastname: '',
      password: '',
    };
    this.isFormVisible = false;
  }

  // user(user: any){
  //   return user.projects.map((b:any) => b.projectname).join(', ');
  // }

  filter() {
    this.apollo.watchQuery({
      query: USER_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        email: this.email === '' ? null : this.email,
        name: this.name === '' ? null : this.name
      }
    }).valueChanges.subscribe(result => {
      this.users = result.data;
      this.reset();
    });
  }

  delete(id: number){
    this.apollo.mutate({
      mutation: DELETE_USER,
      variables: {
        id: id
      }
    }).subscribe(() => {
      this.filter();
    });
  }

  save() {
    let user = {
      name: this.currentUser.name,
      lastname: this.currentUser.lastname,
      email: this.currentUser.email,
      password: this.currentUser.password
    };
    this.apollo.mutate({
      mutation: CREATE_USER,
      variables: {
        user: user
      }
    }).subscribe(() => {
      this.filter();
    });
  }

  //  pdf(){
  //    const doc = new jsPDF();

  //    doc.fromHTML(document.getElementById('jajas'))
  //    doc.save('Lista de usuarios');

  //  }

}
