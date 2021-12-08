using System;

namespace Cdsi
{
    /// <summary>
    /// A record of a vaccine dose administered to a patient.
    /// </summary>
    /// <remarks>Typically provided by the EHR system as part of the patients medical history.</remarks>
    public interface IVaccineDose
    {
        DateTime DateAdministered { get; }
        string VaccineDescription { get; }
        string VaccineType { get; }
        string CVX { get; }
        string MVX { get; }
        DateTime LotExpiration { get; }
        string DoseCondition { get; }
    }
}
