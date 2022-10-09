using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publiccloudgroup_ap.tests
{
    internal static class Dummies
    {
        internal static IList<InstanceDto> dummyInstanceList = new List<InstanceDto>()
        {
            new InstanceDto {Zone="1234", Name="Instance-1", LastStartTimestamp="Some Date in string 1", LastStopTimestamp="Some Date in string 1" , Status="TERMINATED"},
            new InstanceDto {Zone="2345", Name="Instance-1", LastStartTimestamp="Some Date in string 2", LastStopTimestamp="Some Date in string 2" , Status="RUNNING"},
        };
    }
}
