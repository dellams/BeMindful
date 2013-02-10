﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NextGenSoftware.BeMindful.Models;
using NextGenSoftware.BeMindful.Models.Core;
using BeMindful.ViewModels;
//using NextGenSoftware.BeMindful.Data.Providers.WebAPIProvider;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace BeMindful
{
    /// <summary>
    /// A page that displays a group title, a list of items within the group, and details for the
    /// currently selected item.
    /// </summary>
    public sealed partial class SplitPage : BeMindful.Common.LayoutAwarePage
    {
        public SplitPage()
        {
            /*
            if (App.GoingBackFromSplitPage)
            {
                App.GoingBackFromSplitPage = false;
                base.GoBack(this, null);
            }*/

            this.InitializeComponent();
        }

        #region Page state management

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
             base.LoadState(navigationParameter, pageState);

            //Moved to base...
            /*
            if (DataSource.SelectedItem != null)
                navigationParameter = DataSource.SelectedItem;

            dynamic items = GetSelectedItemParentItems(navigationParameter);
            
            if (items != null)
                this.DefaultViewModel["Items"] = items;
            */


            //this.itemsViewSource.View.MoveCurrentTo(navigationParameter);
            this.itemsViewSource.View.MoveCurrentTo(DataSource.SelectedItem);


           // return navigationParameter;



            //IPlaceType placeType = DataSource.Instance.GetPlaceType((long)navigationParameter);

            /*
           // dynamic group = null;
            dynamic items = null;
          //  dynamic selectedItem = null;

            if (navigationParameter is IPlace)
            {
               // selectedItem = 
              //  group = (navigationParameter as IPlace).Parent;
                //items = group.Places;
                items = ((navigationParameter as IPlace).Parent).Places;
            }
            else if (navigationParameter is PersonViewModel)
            {
                items = DataSource.GetPeopleForPersonType((navigationParameter as PersonViewModel).PersonType, (PeopleSortBy)DataSource.LastSortBy, DataSource.LastSortDir);
            }

            //if (group != null && items != null)
            if (items != null)
            {
                //this.DefaultViewModel["Group"] = group; //doesn't appear to be needed...
                this.DefaultViewModel["Items"] = items;
            }*/

            /*
            IPlaceType placeType = DataSource.GetPlaceType((long)navigationParameter);

            if (placeType != null)
            {
                this.DefaultViewModel["Group"] = placeType;
                this.DefaultViewModel["Items"] = placeType.Places;
            }*/


            /*
            if (pageState == null)
            {
                // When this is a new page, select the first item automatically unless logical page
                // navigation is being used (see the logical page navigation #region below.)
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    //this.itemsViewSource.View.MoveCurrentToFirst();
                    this.itemsViewSource.View.MoveCurrentTo(navigationParameter);
                    //this.itemsViewSource.

                   
                    Dispatcher.ProcessEvents(Windows.UI.Core.CoreProcessEventsOption.ProcessUntilQuit);
                    itemListView.ScrollIntoView(navigationParameter);
                    Dispatcher.ProcessEvents(Windows.UI.Core.CoreProcessEventsOption.ProcessUntilQuit);

                    //Dispatcher.RunIdleAsync(
                    



                    
                    itemListView.SelectedItem = navigationParameter;
                    itemListView.SelectedIndex = 9;
                    Dispatcher.ProcessEvents(Windows.UI.Core.CoreProcessEventsOption.ProcessUntilQuit);
                    
                    //itemListView.S
                }
            }
            else
            {
                // Restore the previously saved state associated with this page
                if (pageState.ContainsKey("SelectedItem") && this.itemsViewSource.View != null)
                {
                    //var selectedItem = SampleDataSource.GetItem((String)pageState["SelectedItem"]);
                    //this.itemsViewSource.View.MoveCurrentTo(selectedItem);

                    //TODO: Need to come back to this...
                    //var selectedItem = DataSource.Storage.GetPlace((long)pageState["SelectedItem"]);
                    //this.itemsViewSource.View.MoveCurrentTo(selectedItem);

                    this.itemsViewSource.View.MoveCurrentTo(pageState["SelectedItem"]);
                }
            }*/
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            if (this.itemsViewSource.View != null)
            {
                 //var selectedItem = (IPlace)this.itemsViewSource.View.CurrentItem;
                 //if (selectedItem != null) pageState["SelectedItem"] = selectedItem.Id;

                 pageState["SelectedItem"] = this.itemsViewSource.View.CurrentItem;
                 
                if ( this.itemsViewSource.View.CurrentItem != null)
                    DataSource.SelectedItem = (IBaseModel)this.itemsViewSource.View.CurrentItem;
            }
        }

        #endregion

        #region Logical page navigation

        // Visual state management typically reflects the four application view states directly
        // (full screen landscape and portrait plus snapped and filled views.)  The split page is
        // designed so that the snapped and portrait view states each have two distinct sub-states:
        // either the item list or the details are displayed, but not both at the same time.
        //
        // This is all implemented with a single physical page that can represent two logical
        // pages.  The code below achieves this goal without making the user aware of the
        // distinction.

        /// <summary>
        /// Invoked to determine whether the page should act as one logical page or two.
        /// </summary>
        /// <param name="viewState">The view state for which the question is being posed, or null
        /// for the current view state.  This parameter is optional with null as the default
        /// value.</param>
        /// <returns>True when the view state in question is portrait or snapped, false
        /// otherwise.</returns>
        private bool UsingLogicalPageNavigation(ApplicationViewState? viewState = null)
        {
            if (viewState == null) viewState = ApplicationView.Value;
            return viewState == ApplicationViewState.FullScreenPortrait ||
                viewState == ApplicationViewState.Snapped;
        }

        /// <summary>
        /// Invoked when an item within the list is selected.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is Snapped)
        /// displaying the selected item.</param>
        /// <param name="e">Event data that describes how the selection was changed.</param>
        void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Invalidate the view state when logical page navigation is in effect, as a change
            // in selection may cause a corresponding change in the current logical page.  When
            // an item is selected this has the effect of changing from displaying the item list
            // to showing the selected item's details.  When the selection is cleared this has the
            // opposite effect.
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();

            

            if (itemListView.SelectedItem is IPlace)
                //DataSource.SelectedItem = DataSource.Places.GetPlaceDetails((itemListView.SelectedItem as IPlace).Id);
                DataSource.Places.GetPlaceDetails((itemListView.SelectedItem as IPlace).Id); //caches by default

            else if (itemListView.SelectedItem is IPerson)
                 DataSource.People.GetPersonDetails((itemListView.SelectedItem as IPerson).Id);
                //DataSource.SelectedItem = DataSource.People.GetPersonDetails((itemListView.SelectedItem as IPerson).Id);
        }

        /// <summary>
        /// Invoked when the page's back button is pressed.
        /// </summary>
        /// <param name="sender">The back button instance.</param>
        /// <param name="e">Event data that describes how the back button was clicked.</param>
        protected override void GoBack(object sender, RoutedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation() && itemListView.SelectedItem != null)
            {
                // When logical page navigation is in effect and there's a selected item that
                // item's details are currently displayed.  Clearing the selection will return
                // to the item list.  From the user's point of view this is a logical backward
                // navigation.
                this.itemListView.SelectedItem = null;
            }
            else
            {
                // When logical page navigation is not in effect, or when there is no selected
                // item, use the default back button behavior.
               // App.GoingBackFromSplitPage = true;
                
                
                base.GoBack(sender, e);

                if (!App.ComingFromGroupDetailPage)          
                    base.GoBack(sender, e);
            }
        }

        /// <summary>
        /// Invoked to determine the name of the visual state that corresponds to an application
        /// view state.
        /// </summary>
        /// <param name="viewState">The view state for which the question is being posed.</param>
        /// <returns>The name of the desired visual state.  This is the same as the name of the
        /// view state except when there is a selected item in portrait and snapped views where
        /// this additional logical page is represented by adding a suffix of _Detail.</returns>
        protected override string DetermineVisualState(ApplicationViewState viewState)
        {
            // Update the back button's enabled state when the view state changes
            var logicalPageBack = this.UsingLogicalPageNavigation(viewState) && this.itemListView.SelectedItem != null;
            var physicalPageBack = this.Frame != null && this.Frame.CanGoBack;
            this.DefaultViewModel["CanGoBack"] = logicalPageBack || physicalPageBack;

            // Determine visual states for landscape layouts based not on the view state, but
            // on the width of the window.  This page has one layout that is appropriate for
            // 1366 virtual pixels or wider, and another for narrower displays or when a snapped
            // application reduces the horizontal space available to less than 1366.
            if (viewState == ApplicationViewState.Filled ||
                viewState == ApplicationViewState.FullScreenLandscape)
            {
                var windowWidth = Window.Current.Bounds.Width;
                if (windowWidth >= 1366) return "FullScreenLandscapeOrWide";
                return "FilledOrNarrow";
            }

            // When in portrait or snapped start with the default visual state name, then add a
            // suffix when viewing details instead of the list
            var defaultStateName = base.DetermineVisualState(viewState);
            return logicalPageBack ? defaultStateName + "_Detail" : defaultStateName;
        }

        #endregion

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var item = (sender as FrameworkElement).DataContext;
           // dynamic group = null;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            //this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
            /*
            if (item is IPlace)
            {
                // selectedItem = 
                //  group = (navigationParameter as IPlace).Parent;
                //items = group.Places;
                group = ((item as IPlace).Parent);
            }
            else if (item is PersonViewModel)
            {
                group = DataSource.GetPeopleForPersonType((navigationParameter as PersonViewModel).PersonType, (PeopleSortBy)DataSource.LastSortBy, DataSource.LastSortDir);
            }
            */

            this.Frame.Navigate(typeof(ItemDetailPage2), item); //IPlace or IPerson
            //this.Frame.Navigate(typeof(ItemDetailPage), 1);
            //this.Frame.Navigate(typeof(ItemDetailPage), ((IPlace)group).Id);
            //this.Frame.Navigate(typeof(SplitPage), itemId);

        }
    }
}
