import gql from 'graphql-tag';

export const PROJECT_QUERY = gql`
query($pname: String) {
    projects(pname: $pname) {
        id
        pname
        description
        isActive
    }
}
`;

export const GETU_QUERY = gql`
query{
    getusers{
        id
        name
        email
    }
}
`;
