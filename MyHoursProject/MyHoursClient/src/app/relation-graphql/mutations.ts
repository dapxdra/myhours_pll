import gql from 'graphql-tag';

export const CREATE_RELATION = gql`
mutation($relation: RelationInput!){
  createRelation(input: $relation){
        id
        dashboard
        isActive
        date
        time
        user {
          id
          name
          lastname
          email
          password
          isActive
        }
        project {
          id
          projectname
          isActive
        }

    }
  }
`;

export const EDIT_RELATION = gql`
mutation($id: ID!, $relation: RelationInput!){
  updateRelation(id: $id, input: $relation){
        time
        dashboard
        userId
        projectId
    }
  }
`;

export const DELETE_RELATION = gql`
mutation($id: ID!) {
    deleteRelation(id: $id){
      id
    }
  }
`;