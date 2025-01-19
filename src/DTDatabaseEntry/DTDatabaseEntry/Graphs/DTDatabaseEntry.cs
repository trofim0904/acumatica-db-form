using System.Collections;
using PX.Data;
using Workspace = DTDatabaseEntry.DAC.DTDatabaseWorkspace;

namespace DTDatabaseEntry.Graphs
{
    public class DTDatabaseEntry : PXGraph<DTDatabaseEntry>
    {
        #region Actions
        public PXCancel<Workspace> Cancel;

        public PXAction<Workspace> GetDBType;

        public PXAction<Workspace> ExecuteScript;
        #endregion

        #region View
        public PXFilter<Workspace> Workspace;
        #endregion

        #region Events
        public virtual void _(Events.RowSelected<Workspace> args)
        {
            if (args.Row is Workspace workspace)
            {
                PXUIFieldAttribute.SetEnabled<Workspace.input>(args.Cache, workspace,
                    !string.IsNullOrWhiteSpace(workspace.Type));
            }
        }
        #endregion

        #region Action Implementation
        [PXButton]
        [PXUIField(DisplayName = "Get Database Type")]
        protected virtual IEnumerable getDBType(PXAdapter adapter)
        {
            Workspace.Current.Type = "Unknown";
            return adapter.Get();
        }

        [PXButton]
        [PXUIField(DisplayName = "Execute Script")]
        protected virtual IEnumerable executeScript(PXAdapter adapter)
        {
            Workspace.Current.Output = "Unknown";
            return adapter.Get();
        } 
        #endregion
    }
}