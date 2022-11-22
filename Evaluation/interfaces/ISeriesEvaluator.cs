namespace OpenCdsi.Cdsi
{
    public interface ISeriesEvaluator
    {
        IPatientSeries PatientSeries { get; }

        /// <summary>
        /// Returns the vaccine-dose-administered list with the status' set.
        /// </summary>
        /// <param name="immunizationHistory"></param>
        /// <returns></returns>
        IEnumerable<IAntigenDose> Evaluate(IEnumerable<IAntigenDose> immunizationHistory);
    }
}
