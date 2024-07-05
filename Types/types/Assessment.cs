using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenCdsi.Cdsi
{
    public class Assessment : IAssessment
    {
        [JsonPropertyName("assessmentDate")]
        public DateTimeOffset AssessmentDate { get; set; }

        [JsonPropertyName("patient")]
        public Patient Patient { get; set; }

        [JsonPropertyName("doses")]
        public IEnumerable<IVaccineDose> AdministeredDoses { get; set; }
    }
}
