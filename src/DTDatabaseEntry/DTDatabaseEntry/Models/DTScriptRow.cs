using System.Collections.Generic;

namespace DTDatabaseEntry.Models
{
    public class DTScriptRow
    {
        public List<object> Values { get; set; }

        public override string ToString()
        {
            return string.Join(", ", Values);
        }
    }
}