import gql from 'graphql-tag';

export const RELATION_QUERY = gql`
query($userid: ID!) {
  relation(userid: $userid) {
        id
        dashboard
        date
        time
        userId
        projectId
    }
}
`;
export const GETRELATION_QUERY = gql`
query($userid: ID!, $projectid: ID!) {
  getrelation(userid: $userid, projectid: $projectid)

  gettime(userid: $userid, projectid: $projectid)
}

`;
export const HPRO_QUERY = gql`
query($projectid: ID!) {
    sumPro(projectid: $projectid)
}
`;
export const HUSE_QUERY = gql`
query($userid: ID!) {
    sumUser(userid: $userid)
}
`;

export const GETPROJECTS_QUERY = gql`
query($userid: ID!) {
  getprojects(userid: $userid) {
        id
        pname
        description
    }
}
`;