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


export const DELETE_PROJECT = gql`
mutation($id: ID!) {
    deleteProject(id: $id){
      id
    }
  }
`;