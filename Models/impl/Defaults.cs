using System;

namespace Cdsi
{
    public static class Defaults
    {
        public static readonly EvaluationStatus EvaluationStatus = EvaluationStatus.NotValid;
        public static readonly System.DateTime LotExpiration = new System.DateTime(2999, 12, 31);
        public static System.DateTime AssessmentDate()
        {
            return System.DateTime.Now;
        }
        public static readonly DateTime MinAge = new System.DateTime(1900, 1, 1);
        public static readonly DateTime MaxAge = new System.DateTime(2999, 12, 31);
    }
}
