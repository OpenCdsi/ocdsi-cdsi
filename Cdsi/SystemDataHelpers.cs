using System.Data;

namespace OpenCdsi.Cdsi
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
