
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
    public sealed partial class ItemDetailPage : BeMindful.Common.LayoutAwarePage
    {
        public ItemDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter val                      ue passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            base.LoadState(navigationParameter, pageState);
            this.flipView.SelectedItem = DataSource.SelectedItem;

            // This will force the GetPeopleForPlace, etc methods to refresh,
            switch (DataSource.SelectedItemType)
            {
                case ObjetType.Place:
                    DataSource.ClearCache(CacheToClear.People);
                    break;

                case ObjetType.Person:
                    DataSource.ClearCache(CacheToClear.Places);
                    break;
            }

            //return navigationParameter;

            // Allow saved page state to override the initial item to display
            /*
            if (pageState != null && pageState.ContainsKey("SelectedItem"))
            {
                navigationParameter = pageState["SelectedItem"];
            }*/

            /*
            base.LoadState(navigationParameter, pageState);

            if (DataSource.SelectedItem != null)
                navigationParameter = DataSource.SelectedItem;


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

            pageState["SelectedItem"] = flipView.SelectedItem;

            if (flipView.SelectedItem != null)
                DataSource.SelectedItem = (IBaseModel)flipView.SelectedItem;
        }

        private void Header_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        private void peopleThereGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (DataSource.SelectedItemType)
            {
                case ObjetType.Place:
                    this.DefaultViewModel["PeopleThere"] = DataSource.People.GetPeopleAtPlace(flipView.SelectedItem as IPlace);
                    this.DefaultViewModel["PeopleGoing"] = DataSource.People.GetPeopleGoingPlace(flipView.SelectedItem as IPlace);
                    this.DefaultViewModel["PeopleNear"] = DataSource.People.GetPeopleNearPlace(flipView.SelectedItem as IPlace);
                    break;

                case ObjetType.Person:
                    //TODO: Implement GetPlacePersonIsAt, etc
                    this.DefaultViewModel["PlaceTheyAreAt"] = DataSource.Places.GetPlacePersonIsAt(flipView.SelectedItem as IPerson);
                    this.DefaultViewModel["PlacesTheyAreGoing"] = DataSource.Places.GetPlacesPersonIsGoingTo(flipView.SelectedItem as IPerson);
                    this.DefaultViewModel["PlacesTheyAreNear"] = DataSource.Places.GetPlacesPersonIsNear(flipView.SelectedItem as IPerson);
                    break;
            }
        }
    }
}
