import gql from 'graphql-tag';

export const PROJECT_QUERY = gql`
query($projectname: String) {
    users(projectname: $projectname) {
        id
        projectname
        isActive
    }
}
`;