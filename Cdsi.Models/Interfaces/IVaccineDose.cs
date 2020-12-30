using System;

namespace Cdsi.Models
{
    /// <summary>
    /// A record of a vaccine dose administered to a patient.
    /// </summary>
    public interface IVaccineDose
    {
        DateTime DateAdministered { get; }
        string VaccineDescription { get; }
        string VaccineType { get; }
        string CVX { get; }
        string MVX { get; }
    }
}
