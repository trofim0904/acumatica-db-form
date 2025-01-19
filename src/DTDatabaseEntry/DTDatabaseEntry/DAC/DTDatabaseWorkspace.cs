using PX.Data;
using PX.Data.BQL;

namespace DTDatabaseEntry.DAC
{
    [PXCacheName("Database Workspace")]
    public class DTDatabaseWorkspace : PXBqlTable, IBqlTable
    {
        #region Type
        [PXString]
        [PXUIField(DisplayName = "DB Type", Enabled = false)]
        public string Type { get; set; }

        public abstract class type : BqlString.Field<type> { }
        #endregion

        #region Input
        [PXString]
        [PXUIField(DisplayName = "DB Input", Enabled = true)]
        public string Input { get; set; }

        public abstract class input : BqlString.Field<input> { }
        #endregion

        #region Output
        [PXString]
        [PXUIField(DisplayName = "DB Output", Enabled = false)]
        public string Output { get; set; }

        public abstract class output : BqlString.Field<output> { }
        #endregion
    }
}