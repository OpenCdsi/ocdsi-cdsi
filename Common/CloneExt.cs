namespace Cdsi
{
    public static class CloneExt
    {
        public static IAntigenDose Clone(this IAntigenDose obj)
        {
            return new AntigenDose
            {
                AntigenName = obj.AntigenName,
                VaccineDose = obj.VaccineDose,
                EvaluationStatus = EvaluationStatus.NotValid
            };
        }
    }
}
