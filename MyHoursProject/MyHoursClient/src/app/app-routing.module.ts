import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserGraphqlComponent } from '@app/user-graphql/user-graphql.component'; 

const routes: Routes = [
  { path: 'users',component: UserGraphqlComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
