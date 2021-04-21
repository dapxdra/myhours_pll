import gql from 'graphql-tag';

export const CREATE_USER = gql`
mutation($user: UserInput!){
  createUser(input: $user){
        id
        name
        lastname
        email
        password
        isActive
    }
  }
`;

export const EDIT_USER = gql`
mutation($id: ID!, $user: UserInput!){
  updateUser(id: $id, input: $user){
        id
        name
        lastname
        email
        password
        isActive
    }
  }
`;


export const DELETE_USER = gql`
mutation($id: ID!) {
    deleteUser(id: $id){
      id
    }
  }
`;