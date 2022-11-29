namespace OpenCdsi.Cdsi
{
    /// <summary>
    /// Represents an antigen dose administered to a patient.
    /// </summary>
    /// <remarks>Created as a result of the organize-patient-history procedure. Note that the
    /// Logic Spec refers to this as a "vaccine dose administered" in the section on Gathering
    /// Nessasary Data.</remarks>
    public interface IAntigenDose
    {
        string AntigenName { get; }
        IVaccineDose VaccineDose { get; } // prefer composition over inheritence
        EvaluationStatus EvaluationStatus { get; set; }
        IList<EvaluationReason> EvaluationReasons { get; }
    }
}