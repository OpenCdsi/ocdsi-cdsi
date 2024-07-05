
namespace OpenCdsi.Cdsi
{
    public interface IAssessment
    {
        IEnumerable<IVaccineDose> AdministeredDoses { get; set; }
        DateTimeOffset AssessmentDate { get; set; }
        Patient Patient { get; set; }
    }
}