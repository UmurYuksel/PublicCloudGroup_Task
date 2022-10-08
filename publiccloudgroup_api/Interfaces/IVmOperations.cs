using Google.Cloud.Compute.V1;
using publiccloudgroup_api.DTO_s;

namespace publiccloudgroup_api.Interfaces
{
    public interface IVmOperations
    {
        /// <summary>
        /// This function is used to fetch list of Virtual Machines
        /// </summary>
        /// <returns>List of instances</returns>
        Task<(bool isSuccess, IList<InstanceDto> vmInstances, string responseMessage)> GetAllVmIntances();

        /// <summary>
        /// This function is used to start selected Virtual Machine
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Boolean Result and String Response Message</returns>
        Task<(bool isSuccess, string responseMessage)> StartSelectedVm(StartRequestModelDto requestModel);

        /// <summary>
        /// This function is used to stop selected Virtual Machine
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Boolean Result and String Response Message</returns>
        Task<(bool isSuccess, string responseMessage)> StopSelectedVm(StopRequestModelDto requestModel);

        /// <summary>
        /// This function is used to resume the Selected Virtual Machine
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Boolean Result and String Response Message</returns>
        Task<(bool isSuccess, string responseMessage)> ResumeSelectedVm(ResumeRequestModelDto requestModel);


        /// <summary>
        /// This function is used to suspend the Selected Virtual Machine
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns>Boolean Result and String Response Message</returns>
        Task<(bool isSuccess, string responseMessage)> SuspendSelectedVm(SuspendRequestModelDto requestModel);

    }
}
