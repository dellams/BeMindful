//using BeMindful.Data;

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

// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229

namespace BeMindful
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public sealed partial class GroupDetailPage : BeMindful.Common.LayoutAwarePage
    {
        public GroupDetailPage()
        {
            this.InitializeComponent();
        }


        protected override void GoBack(object sender, RoutedEventArgs e)
        {
            base.GoBack(sender, e);
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
            //this.itemsViewSource.View.MoveCurrentTo(navigationParameter);

            /*
            navigationParameter = base.LoadState(navigationParameter, pageState);

            //this.itemsViewSource.View.MoveCurrentTo(navigationParameter);

            this.DefaultViewModel["Group"] = (IPlaceType)group;

            return navigationParameter;
            */







            
            GroupInfoList<object> groups = (GroupInfoList<object>)navigationParameter;

            if (groups != null && groups.Count > 0)
            {
                dynamic group = null;
                dynamic items = null;

                 if (groups[0] is IPlace)
                 {
                    group = (groups[0] as IPlace).Parent;
                   // items = ((groups[0] as IPlace).Parent).Places;
                 }
            
                 else if (groups[0] is IPerson)
                 {
                     //group = (groups[0] as IPerson).Parent;
                    // items = DataSource.GetPeopleForPersonType((groups[0] as IPerson).PersonType, (PeopleSortBy)DataSource.LastSortBy, DataSource.LastSortDir);
                 }

                 var placeType = DataSource.StorageProvider.GetPlaceType(1);

                
                //this.DefaultViewModel["Group"] = placeType;

                this.DefaultViewModel["Group"] = (IPlaceType)group;
                this.DefaultViewModel["Items"] = groups;
            }

            //return navigationParameter;
            






            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var group = SampleDataSource.GetGroup((String)navigationParameter);
            //var group = SampleDataSource.GetGroup((String)navigationParameter);
            //var groups = DataSource.Instance.GetAllPlaceTypes();
            /*
            if (DataSource.SelectedItem != null)
                navigationParameter = DataSource.SelectedItem;

            dynamic items = GetSelectedItemParentItems(navigationParameter);

            if (items != null)
                this.DefaultViewModel["Items"] = items;


            this.itemsViewSource.View.MoveCurrentTo(navigationParameter);
            */
            /*
            var placeType = DataSource.Storage.GetPlaceType((long)navigationParameter);

            this.DefaultViewModel["Group"] = placeType;
            this.DefaultViewModel["Items"] = placeType.Places;
            */
        }

        /// <summary>
        /// Invoked when an item is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
           // var itemId = ((IPlace)e.ClickedItem).Id;
            //this.Frame.Navigate(typeof(ItemDetailPage), itemId);

           // this.Frame.Navigate(typeof(SplitPage), itemId);

            DataSource.SelectedItem = (IBaseModel)e.ClickedItem;

            //if its in snapped mode we want to go straight to the ItemDetailPage
            if (this.ApplicationViewStates.CurrentState.Name == "Snapped")
                this.Frame.Navigate(typeof(ItemDetailPage), e.ClickedItem);
            else
            {
                App.ComingFromGroupDetailPage = true;
                this.Frame.Navigate(typeof(SplitPage), e.ClickedItem);
            }
        }
    }

}

