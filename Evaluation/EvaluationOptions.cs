namespace Cdsi
{
    public class EvaluationOptions : IEvaluationOptions
    {
        public DateTime AssessmentDate { get; init; }
        public DateTime DateOfBirth { get; init; }
        public IEnumerable<IPatientObservation> Observations { get; } = Array.Empty<IPatientObservation>();
    }
}
