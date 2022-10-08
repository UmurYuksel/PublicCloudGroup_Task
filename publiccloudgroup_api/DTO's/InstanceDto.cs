using Google.Cloud.Compute.V1;

namespace publiccloudgroup_api.DTO_s
{
    public class InstanceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Zone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string LastStartTimestamp { get; set; } = string.Empty;
        public string LastStopTimestamp { get; set; } = string.Empty;
    }
}
