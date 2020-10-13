#load "interfaces.csx"
#load "entities.csx"

using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.Extensions.Logging;

public class PostService : IPostService
{
    private readonly IGraphQLClient _client;
    private readonly ILogger<PostService> _logger;

    public PostService(IGraphQLClient client, ILogger<PostService> logger)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<List<Post>> GetAllPosts(PostOptionsInput postOptionsInput)
    {
        var query = new GraphQLRequest
        {
            Query = @"
                query($options: PageQueryOptions) {
                  posts(options: $options) {
                    data {
                        id
                        title
                        body
                    }
                    meta {
                        totalCount
                    }
                  }
                }"
            ,
            Variables = new { options = postOptionsInput }
        };

        var response = await _client.SendQueryAsync<ResponsePostCollectionType>(query).ConfigureAwait(false);

        response.Errors?.ToList().ForEach(error => _logger.LogError(error.Message));

        return response.Data.Posts.Data.ToList();
    }

    public async Task<Post> GetPost(int id)
    {
        var request = new GraphQLRequest
        {
            Query = @"
                query($id: ID!) {
                    post(id: $id) {
                        id
                        title
                        body
                    }
                }"
            ,
            Variables = new { id }
        };

        var response = await _client.SendQueryAsync<ResponsePostType>(request).ConfigureAwait(false);

        response.Errors?.ToList().ForEach(error => _logger.LogError(error.Message));

        return response.Data.Post;
    }

    public async Task<Post> CreatePost(PostInput postToCreate)
    {
        var query = new GraphQLRequest
        {
            Query = @"
                mutation($input: CreatePostInput!) {
                    createPost(input: $input) {
                        id
                        title
                        body
                    }
                }"
            ,
            Variables = new { input = postToCreate }
        };

        var response = await _client.SendMutationAsync<ResponseCreatePostType>(query).ConfigureAwait(false);

        response.Errors?.ToList().ForEach(error => _logger.LogError(error.Message));

        return response.Data.CreatePost;
    }

    public async Task<Post> UpdatePost(int id, PostInput postToUpdate)
    {
        var query = new GraphQLRequest
        {
            Query = @"
                mutation($id: ID!, $input: UpdatePostInput!){
                  updatePost(id: $id, input: $input){
                    id
                    title
                    body
                  }
               }"
            ,
            Variables = new { id, input = postToUpdate }
        };

        var response = await _client.SendMutationAsync<ResponseUpdatePostType>(query).ConfigureAwait(false);

        response.Errors?.ToList().ForEach(error => _logger.LogError(error.Message));

        return response.Data.UpdatePost;
    }

    public async Task<bool> DeletePost(int id)
    {
        var query = new GraphQLRequest
        {
            Query = @"
               mutation($id: ID!) {
                   deletePost(id: $id)
                }"
            ,
            Variables = new { id }
        };

        var response = await _client.SendMutationAsync<ResponseDeletePostType>(query).ConfigureAwait(false);

        response.Errors?.ToList().ForEach(error => _logger.LogError(error.Message));

        return response.Data.DeletePost;
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }
}
