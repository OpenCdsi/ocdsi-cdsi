using System;

namespace Cdsi
{
    public static class Defaults
    {
        public static readonly EvaluationStatus EvaluationStatus = EvaluationStatus.NotValid;
        public static readonly DateTime LotExpiration = new DateTime(2999, 12, 31);
    }
}
