
namespace OpenCdsi.Cdsi
{
    public interface IAssessment
    {
        IEnumerable<IVaccineDose> AdministeredDoses { get; set; }
        DateTime AssessmentDate { get; set; }
        Patient Patient { get; set; }
    }
}