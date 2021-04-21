import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { USER_QUERY } from '../user-graphql/queries';
import { CREATE_USER, DELETE_USER, EDIT_USER } from '../user-graphql/mutations';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-list-user-graphql',
  templateUrl: './list-user-graphql.component.html',
  styleUrls: ['./user-graphql.component.scss']
})
export class ListUserGraphqlComponent implements OnInit {

  public users: any;
  public currentUser: any;
  public isFormVisible = false;
  public name = null;
  public lastname = null;
  public email = null;
  public password = null;

  public editname= null;
  public editlastname = null;
  public editemail = null;
  public editpassword = null;
  public temp=null;
  public isEditVisible = false
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
  cargar(id: number){
    this.isEditVisible = true;
    this.temp = id;
  }
  edit(){
    
    let user = {
      name: this.editname,
      lastname: this.editlastname,
      email: this.editemail,
      password: this.editpassword


    };
    this.apollo.mutate({
      mutation: EDIT_USER,
      variables: {
        id: this.temp,
        user: user
      }
    }).subscribe(() => {
      alert("Edit succesfully");
      window.location.href ="http://localhost:4200/users";
      this.filter();
    });
  }
  logout(){
    window.location.href="http://localhost:4200/login"
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
      alert("Save succesfully");
      window.location.href ="http://localhost:4200/login";
      this.filter();
    });
  }

  //  pdf(){
  //    const doc = new jsPDF();

  //    doc.fromHTML(document.getElementById('jajas'))
  //    doc.save('Lista de usuarios');

  //  }

}
