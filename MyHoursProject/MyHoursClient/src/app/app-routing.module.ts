import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginGraphqlComponent } from '@app/auth-graphql/login-graphql.component';
import { ProjectGraphqlComponent } from '@app/project-graphql/project-graphql.component';
import { UserGraphqlComponent } from '@app/user-graphql/user-graphql.component';
import { ListUserGraphqlComponent } from '@app/user-graphql/list-user-graphql.component';
import { RelationGraphqlComponent } from '@app/relation-graphql/relation-graphql.component';

const routes: Routes = [
  { path: '',   redirectTo: 'login', pathMatch: 'full' },
  { path: 'login',component: LoginGraphqlComponent},
  { path: 'register',component: UserGraphqlComponent},
  { path: 'users',component: ListUserGraphqlComponent},
  { path: 'projects',component: ProjectGraphqlComponent},
  { path: 'home/:id',component: RelationGraphqlComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
