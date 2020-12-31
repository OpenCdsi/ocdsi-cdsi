using System.Collections.Generic;

namespace System.Data
{
    public static class SystemDataHelpers
    {
        public static IEnumerable<DataRow> AsEnumerable(this DataRowCollection rows)
        {
            foreach (DataRow row in rows)
            {
                yield return row;
            }
        }
    }
}
