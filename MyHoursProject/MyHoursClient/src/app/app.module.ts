import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { from } from 'rxjs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UserGraphqlComponent } from './user-graphql/user-graphql.component';

import {APOLLO_OPTIONS} from 'apollo-angular';
import {HttpLink} from 'apollo-angular/http';
import {InMemoryCache} from '@apollo/client/core';
import { ProjectGraphqlComponent } from './project-graphql/project-graphql.component';
import { RelationGraphqlComponent } from './relation-graphql/relation-graphql.component';
import { AuthGraphqlComponent } from './auth-graphql/auth-graphql.component';
import { LoginGraphqlComponent } from './auth-graphql/login-graphql.component';
import { RegisterGraphqlComponent } from './auth-graphql/register-graphql.component';

@NgModule({
  declarations: [
    AppComponent,
    UserGraphqlComponent,
    ProjectGraphqlComponent,
    RelationGraphqlComponent,
    AuthGraphqlComponent,
    LoginGraphqlComponent,
    RegisterGraphqlComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    HttpClient,
    {
      provide: APOLLO_OPTIONS,
      useFactory: (httpLink: HttpLink) => {
        return {
          cache: new InMemoryCache(),
          link: httpLink.create({
            uri: 'https://localhost:5001/graphql',
          }),
        };
      },
      deps: [HttpLink],
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }