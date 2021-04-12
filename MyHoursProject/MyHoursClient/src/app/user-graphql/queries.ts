import gql from 'graphql-tag';

export const USER_QUERY = gql`
query($email: String, $name: String) {
    companies(email: $email, name: $name) {
        id
        email
        name
        lastame
        projects {
            id
            projectname
        }
    }
}
`;