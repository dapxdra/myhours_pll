import gql from 'graphql-tag';

export const RELATION_QUERY = gql`
query($dashboard: String) {
    users(dashboard: $dashboard) {
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