import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { LOGIN_QUERY } from './queries';

@Component({
  selector: 'app-login-graphql',
  templateUrl: './login-graphql.component.html',
  styleUrls: ['./login-graphql.component.scss']
})
export class LoginGraphqlComponent implements OnInit {

  public email: '';
  public password: '';

  constructor(private apollo: Apollo) { }

  ngOnInit(): void {
  }

  login(){
    this.apollo.watchQuery({
      query: LOGIN_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        email: this.email,
        password: this.password
      }
    }).valueChanges.subscribe(result => {
      var user: any;
      user = result;
      window.location.href='http://localhost:4200/home/' + user.data.auth;
    });
  }

}
