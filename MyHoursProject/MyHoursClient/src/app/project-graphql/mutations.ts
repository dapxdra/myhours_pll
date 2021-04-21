import gql from 'graphql-tag';

export const CREATE_PROJECT = gql`
mutation($project: ProjectInput!){
  createProject(input: $project){
        id
        pname
        description
        isActive
    }
  }
`;

export const EDIT_PROJECT = gql`
mutation($id: ID!, $project: ProjectInput!){
  updateProject(id: $id, input: $project){
        id
        pname
        description
        isActive
    }
  }
`;


export const DELETE_PROJECT = gql`
mutation($id: ID!) {
    deleteProject(id: $id){
      id
    }
  }
`;

export const SUM_USER = gql`
mutation($relation: RelationInput!){
  createRelation(input: $relation){
        id
        dashboard
        time
        userId
        projectId
    }
  }
`;