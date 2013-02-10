using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Core;

namespace BeMindful
{

    /// <summary>
    /// View-Model with dependency properties for use with DXPage.
    /// When used as DataContext of DXPage, can support ISupportSaveLoadState
    /// interface to enable navigation and/or persistency.
    /// </summary>
    public class MainPageViewModel : BindableBase, ISupportSaveLoadState
    {

        public MainPageViewModel()
        {
            Header = "Header";
        }

        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                SetProperty<string>(ref _header, value, "Header");
            }
        }

        #region ISupportSaveLoadState Members

        public void LoadState(object navigationParameter, PageStateStorage pageState)
        {
            //pageState.
        }

        public void SaveState(PageStateStorage pageState)
        {
        }

        #endregion
    }
}
