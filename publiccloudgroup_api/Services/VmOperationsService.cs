using AutoMapper;
using Google.Cloud.Compute.V1;
using publiccloudgroup_api.DTO_s;
using publiccloudgroup_api.Interfaces;

namespace publiccloudgroup_api.Services
{
    public class VmOperationsService : IVmOperations
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public VmOperationsService(IMapper mapper, IConfiguration config)
        {
            _mapper = mapper;
            _config = config;
        }

        public async Task<(bool isSuccess, IList<InstanceDto> vmInstances, string responseMessage)> GetAllVmIntances()
        {
            try
            {
                InstancesClient client = await InstancesClient.CreateAsync();
                IList<Instance> allInstances = new List<Instance>();

                // Make the request to list all VM instances in a project =>
                await foreach (var instancesByZone in client.AggregatedListAsync(_config["ProjectId"]))
                {
                    // The result contains a KeyValuePair collection, where the key is a zone and the value =>
                    foreach (var instance in instancesByZone.Value.Instances)
                    {
                        instance.Zone = instancesByZone.Key.Replace("zones/",""); //This is how I extract the zone. The Instance object provides the zone as a link =>
                        allInstances.Add(instance);
                    }
                }
                var allInstancesDto = _mapper.Map<List<InstanceDto>>(allInstances);
                return (true, allInstancesDto, "Success");
            }
            catch (Exception ex)
            {
                return (false, Array.Empty<InstanceDto>(), $"Error: {ex.Message}"); //Array.Empy is equivalent to empty IList.
            }

        }

        public async Task<(bool isSuccess, string responseMessage)> StartSelectedVm(StartRequestModelDto requestModel)
        {
            try
            {
                InstancesClient client = await InstancesClient.CreateAsync();

                StartInstanceRequest startRequestObject = _mapper.Map<StartInstanceRequest>(requestModel); //Auto Mapping

                startRequestObject.Project = _config["ProjectId"];

                var operation = await client.StartAsync(startRequestObject);

                var result = await operation.PollUntilCompletedAsync();

                if (result.IsCompleted && !result.IsFaulted)
                    return (true, $"{requestModel.InstanceName} has been started successfully.");

                return (false, $"Error. Details: {result.Result.Error.Errors[0].ErrorDetails[0].ErrorInfo.Reason}");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string responseMessage)> StopSelectedVm(StopRequestModelDto requestModel)
        {
            try
            {
                InstancesClient client = await InstancesClient.CreateAsync();

                StopInstanceRequest stopRequestObject = _mapper.Map<StopInstanceRequest>(requestModel); //Auto-Mapping.
                
                stopRequestObject.Project = _config["ProjectId"]; //User-Secrets.

                var operation = await client.StopAsync(stopRequestObject);

                var result = await operation.PollUntilCompletedAsync();

                if (result.IsCompleted && !result.IsFaulted)
                    return (true, $"{requestModel.InstanceName} has been stopped successfully.");

                return (false, $"Error. Details: {result.Result.Error.Errors[0].ErrorDetails[0].ErrorInfo.Reason}");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string responseMessage)> SuspendSelectedVm(SuspendRequestModelDto requestModel)
        {
            try
            {
                InstancesClient client = await InstancesClient.CreateAsync();

                SuspendInstanceRequest suspendRequest = _mapper.Map<SuspendInstanceRequest>(requestModel); //Auto-Mapping.

                suspendRequest.Project = _config["ProjectId"]; //User-Secrets.

                var operation = await client.SuspendAsync(suspendRequest);

                var result = await operation.PollUntilCompletedAsync();

                if (result.IsCompleted && !result.IsFaulted)
                    return (true, $"{requestModel.InstanceName} has been suspended successfully.");

                return (false, $"Error. Details: {result.Result.Error.Errors[0].ErrorDetails[0].ErrorInfo.Reason}");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool isSuccess, string responseMessage)> ResumeSelectedVm(ResumeRequestModelDto requestModel)
        {
            try
            {
                InstancesClient client = await InstancesClient.CreateAsync();

                ResumeInstanceRequest resumeRequest = _mapper.Map<ResumeInstanceRequest>(requestModel); //Auto Mapping.

                resumeRequest.Project = _config["ProjectId"]; //User-Secrets.

                var operation = await client.ResumeAsync(resumeRequest);

                var result = await operation.PollUntilCompletedAsync();

                if (result.IsCompleted && !result.IsFaulted)
                    return (true, $"{requestModel.InstanceName} has been resumed successfully.");

                return (false, $"Error. Details: {result.Result.Error.Errors[0].ErrorDetails[0].ErrorInfo.Reason}");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
