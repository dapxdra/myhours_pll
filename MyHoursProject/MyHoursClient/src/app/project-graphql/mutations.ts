import gql from 'graphql-tag';

export const CREATE_PROJECT = gql`
mutation($project: ProjectInput!){
  createProject(input: $project){
        id
        projectname
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