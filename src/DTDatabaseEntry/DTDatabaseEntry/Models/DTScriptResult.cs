using System.Collections.Generic;
using System.Text;

namespace DTDatabaseEntry.Models
{
    public class DTScriptResult
    {
        public int? RecordsAffected { get; set; }

        public List<string> Headers { get; set; }

        public List<DTScriptRow> Rows { get; set; }

        public override string ToString()
        {
            if (RecordsAffected.HasValue)
            {
                return $"Records Affected: {RecordsAffected}";
            }
            StringBuilder result = new StringBuilder();
            if (Headers != null)
            {
                result.AppendLine(string.Join(", ", Headers));
            }
            if (Rows != null)
            {
                foreach (var row in Rows)
                {
                    result.AppendLine(row.ToString());
                }
            }
            return result.ToString();
        }
    }
}