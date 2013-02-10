
using NextGenSoftware.BeMindful.Models;
using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace BeMindful
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage3 : BeMindful.Common.LayoutAwarePage
    {
        public ItemDetailPage3()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            //base.LoadState(navigationParameter, pageState);





            //this.flipView.SelectedItem = navigationParameter;

            //return navigationParameter;

            // Allow saved page state to override the initial item to display
            /*
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }*/

            /*
            base.LoadState(navigationParameter, pageState);

            if (DataSource<MockBeMindfulDataSource>.SelectedItem != null)
                navigationParameter = DataSource<MockBeMindfulDataSource>.SelectedItem;


            dynamic items = GetSelectedItemParentItems(navigationParameter);

            if (items != null)
            {
                //this.DefaultViewModel["Group"] = placeType;
                this.DefaultViewModel["Items"] = items;

                this.flipView.SelectedItem = navigationParameter;

                //int index = ((List<IBaseModel>)items).IndexOf((IBaseModel)navigationParameter);
                //this.flipView.SelectedIndex = ((List<IBaseModel>)items).IndexOf((IBaseModel)navigationParameter);
            }
            */

            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            /*
            var item = SampleDataSource.GetItem((String)navigationParameter);
            this.DefaultViewModel["Group"] = item.Group;
            this.DefaultViewModel["Items"] = item.Group.Items;
            this.flipView.SelectedItem = item;
            */
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            //var selectedItem = (IPlace)this.flipView.SelectedItem;
            //pageState["SelectedItem"] = selectedItem.Id;

           // pageState["SelectedItem"] = flipView.SelectedItem;

           // if (flipView.SelectedItem != null)
           //     DataSource<MockBeMindfulDataSource>.SelectedItem = (IBaseModel)flipView.SelectedItem;
        }

        private void Header_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartLayoutUpdates(object sender, RoutedEventArgs e)
        {

        }
    }
}
