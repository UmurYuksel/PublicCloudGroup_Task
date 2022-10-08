using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace publiccloudgroup_api.DTO_s.Abstract
{
    public abstract class BaseRequestModelDto
    {
        [Required]
        public string Zone { get; set; } = string.Empty;
        [Required]
        public string InstanceName { get; set; } = string.Empty;
    }
}
