import gql from 'graphql-tag';

export const USER_QUERY = gql`
query($email: String, $name: String) {
    users(email: $email, name: $name) {
        id
        name
        lastname
        email
        password
        isActive
    }
}
`;