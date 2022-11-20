using System;

namespace Cdsi
{
    public static class Defaults
    {
        public static readonly EvaluationStatus EvaluationStatus = EvaluationStatus.NotValid;
        public static readonly DateTime LotExpiration = new DateTime(2999, 12, 31);
        public static DateTime AssessmentDate()
        {
            return System.DateTime.Now;
        }
        public static readonly DateTime MinAge = new DateTime(1900, 1, 1);
        public static readonly DateTime MaxAge = new DateTime(2999, 12, 31);
    }
}
