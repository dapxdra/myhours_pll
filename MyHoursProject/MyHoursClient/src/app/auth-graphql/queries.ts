import gql from 'graphql-tag';

export const LOGIN_QUERY = gql`
query($email: String, $password: String) {
    auth(email: $email, password: $password)
}
`;