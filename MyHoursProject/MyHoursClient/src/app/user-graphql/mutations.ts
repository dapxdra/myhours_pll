import gql from 'graphql-tag';

export const CREATE_USER = gql`
mutation($user: UserInput!){
    createUser(input: $user){
        id
        email
        name
        lastname
        projects {
            id
            projectname
        }
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