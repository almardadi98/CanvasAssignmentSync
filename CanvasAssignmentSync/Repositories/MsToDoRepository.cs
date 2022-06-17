using AngleSharp;
using AngleSharp.Diffing.Strategies.ElementStrategies;
using Azure.Identity;
using CanvasAssignmentSync.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace CanvasAssignmentSync.Repositories
{
    public class MsToDoRepository : IMsToDoRepository
    {
        private readonly IConfiguration _configuration;
        // Multi-tenant apps can use "common",
        // single-tenant apps must use the tenant ID from the Azure portal
        private readonly string _tenantId;
        // Value from app registration
        private readonly string _clientId;
        private readonly string _clientSecret;
        // Permissions. Scope of access
        private readonly List<string> _scopes;
        private readonly GraphServiceClient _client;


        public MsToDoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var msToDoOptions = new MsToDoOptions();
            var configSection = _configuration.GetSection(MsToDoOptions.MsToDo);
            configSection.Bind(msToDoOptions);
            _tenantId = msToDoOptions.TenantId;
            _clientId = msToDoOptions.ClientId;
            _clientSecret = msToDoOptions.ClientSecret;
            _scopes = msToDoOptions.Scopes ?? new List<string>() { "User.Read" };
            // For authorization code flow, the user signs into the Microsoft
            // identity platform, and the browser is redirected back to your app
            // with an authorization code in the query parameters
            var authorizationCode = GetAuthorizationCode();

            // using Azure.Identity;
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            // https://docs.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential
            var authCodeCredential = new AuthorizationCodeCredential(
                _tenantId, _clientId, _clientSecret, authorizationCode, options);



            _client = new GraphServiceClient(authCodeCredential, _scopes);


        }

        private string GetAuthorizationCode()
        {

            var authorizationCode = "AUTH_CODE_FROM_REDIRECT";


            return authorizationCode;
        }

        public async Task<List<MsToDoTask>?> GetTasks()
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask?> GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask?> GetTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask> CreateTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask> UpdateTask(MsToDoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTask> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MsToDoTaskList>?> GetTaskLists()
        {
            var user = await _client.Me
                .Request()
                .Select(u => new {
                    u.DisplayName,
                    u.JobTitle
                })
                .GetAsync();
            var collPage =  await _client.Me.Todo.Lists
                .Request()
                .Top(20)
                .GetAsync();

            return new List<MsToDoTaskList>();
        }

        public async Task<MsToDoTaskList?> GetTaskList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskList?> CreateTaskList(MsToDoTaskList taskList)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskList> UpdateTaskList(MsToDoTaskList taskList)
        {
            throw new NotImplementedException();
        }

        public async Task<MsToDoTaskList> DeleteTaskList(int id)
        {
            throw new NotImplementedException();
        }
    }
}
