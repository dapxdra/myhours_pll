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


export const DELETE_RELATION = gql`
mutation($id: ID!) {
    deleteRelation(id: $id){
      id
    }
  }
`;