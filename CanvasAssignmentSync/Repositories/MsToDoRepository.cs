using AngleSharp;
using Azure.Identity;
using CanvasAssignmentSync.Models;
using Microsoft.EntityFrameworkCore.Metadata;
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
        // Permissions. Scope of access
        private readonly List<string> _scopes;
        private readonly GraphServiceClient _graphServiceClient;

        public MsToDoRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            //var scopes = new[] { "User.Read" };
            //var tenantId = "common";
            //var clientId = "YOUR_CLIENT_ID";

            var msToDoOptions = new MsToDoOptions();
            var configSection = _configuration.GetSection(MsToDoOptions.MsToDo);
            configSection.Bind(msToDoOptions);

            _tenantId = msToDoOptions.TenantId;
            _clientId = msToDoOptions.ClientId;
            _scopes = msToDoOptions.Scopes;
            var deviceCodeCredential = GetDeviceCodeCredential();

            _graphServiceClient = new GraphServiceClient(deviceCodeCredential, _scopes);

        }

        private DeviceCodeCredential GetDeviceCodeCredential()
        {
            // using Azure.Identity;
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            // Callback function that receives the user prompt
            // Prompt contains the generated device code that use must
            // enter during the auth process in the browser
            Func<DeviceCodeInfo, CancellationToken, Task> callback = (code, cancellation) => {
                Console.WriteLine(code.Message);
                return Task.FromResult(0);
            };

            // https://docs.microsoft.com/dotnet/api/azure.identity.devicecodecredential
            var deviceCodeCredential = new DeviceCodeCredential(
                callback, _tenantId, _clientId, options);
            return deviceCodeCredential;
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
            throw new NotImplementedException();
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
