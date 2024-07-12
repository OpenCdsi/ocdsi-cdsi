using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cdsi
{
    public class Assessment : IAssessment
    {
        [JsonPropertyName("key")]
        public string CaseId { get; set; } = string.Empty;

        [JsonPropertyName("assessmentDate")]
        public DateTime AssessmentDate { get; set; }

        [JsonPropertyName("patient")]
        public Patient Patient { get; set; }
    }
}
