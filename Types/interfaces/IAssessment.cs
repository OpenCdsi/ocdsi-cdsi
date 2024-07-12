
namespace Cdsi
{
    public interface IAssessment
    {
        string CaseId { get; }
        DateTime AssessmentDate { get; set; }
        Patient Patient { get; set; }
    }
}