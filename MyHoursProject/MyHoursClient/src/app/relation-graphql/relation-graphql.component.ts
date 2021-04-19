import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Apollo } from 'apollo-angular';
import { CREATE_RELATION, DELETE_RELATION } from './mutations';
import { RELATION_QUERY } from './queries';

@Component({
  selector: 'app-relation-graphql',
  templateUrl: './relation-graphql.component.html',
  styleUrls: ['./relation-graphql.component.scss']
})
export class RelationGraphqlComponent implements OnInit {
  public userid = null;
  public relations: any;
  public currentRelation: any;
  public dashboard = null;
  public date = null;
  public time = null;

  public isFormVisible = false;
  constructor(private route: ActivatedRoute, private apollo: Apollo) {
    this.relations = [];
  }

  ngOnInit(): void {
    let id = this.route.snapshot.params.id;
    this.userid = id;
  }
  reset(){
    this.currentRelation = {
      dashboard: '',
      date: '',
      time: ''
    };
    this.isFormVisible = false;
  }

  users(relation: any){
    return relation.users.map((b:any) => b.name).join(', ');
  }
  projects(relation: any){
    return relation.projects.map((p:any) => p.name).join(', ');
  }
  logout() {
    window.location.href = "http://localhost:4200/login"
  }
  filter() {
    this.apollo.watchQuery({
      query: RELATION_QUERY,
      fetchPolicy: 'network-only',
      variables: {
        dashboard: this.dashboard === '' ? null : this.dashboard,
      }
    }).valueChanges.subscribe(result => {
      this.relations = result.data;
      this.reset();
    });
  }

  delete(id: number){
    this.apollo.mutate({
      mutation: DELETE_RELATION,
      variables: {
        id: id
      }
    }).subscribe(() => {
      this.filter();
    });
  }

  save() {
    let relation = {
      dashboard: this.currentRelation.dashboard,
      date: this.currentRelation.date,
      time: this.currentRelation.time
    };
    this.apollo.mutate({
      mutation: CREATE_RELATION,
      variables: {
        relation: relation
      }
    }).subscribe(() => {
      this.filter();
    });
  }
  
}

