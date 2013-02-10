//using App2.Data;
using BeMindful;
using NextGenSoftware.BeMindful.Models;
using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace BeMindful
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class GroupedItemsZoomPage : BeMindful.Common.LayoutAwarePage
    {
        private ObservableCollection<GroupInfoList<object>> _data;
        private Sections _currentSection;

        public GroupedItemsZoomPage()
        {
           // App.GoingBackFromSplitPage = false;
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
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            //this.DefaultViewModel["Groups"] = sampleDataGroups;

            //var groups = DataSource.Instance.GetAllPlaceTypes();
            //this.DefaultViewModel["Groups"] = groups;

            //reset the currently selected item.
            //DataSource.SelectedItem = null; //TODO: Was in!

            //_currentSection = (Sections)Convert.ToInt32(navigationParameter);
            _currentSection = (Sections)Convert.ToInt32(navigationParameter);

            

            switch ((Sections)Convert.ToInt32(navigationParameter))
            {
                case Sections.WhatsNearMe:
                    {
                        stkpnlWhatsNearMe.Visibility = Windows.UI.Xaml.Visibility.Visible;

                    }
                    break;

                case Sections.WhosNearMe:
                    {
                        stkpnlWhosNearMe.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        comboSortBy.Items.Clear();
                        comboSortBy.Items.Add("First Name");
                        comboSortBy.Items.Add("Last Name");
                        comboSortBy.Items.Add("Distance");
                        comboSortBy.Items.Add("Position"); //such as healer, light worker, warrior of the light, wayshower, etc...
                        comboSortBy.Items.Add("Aura");
                        comboSortBy.Items.Add("Position"); //TODO: may just merge this into aura later... not sure yet (see ideas doc for more info...)
                        comboSortBy.Items.Add("Experience"); //will show another dropdown where they can select the place type you want to see how much exp there have in (such as beginner, intermeditate,advanced.
                        comboSortBy.Items.Add("Joined Data"); //not sure about this one?
                    }
                    break;
            }

            BindData(true, _currentSection);
            BindPlaceTypesDropDown();

          //  return null;
        }

        private void BindSortByDropDown()
        {
            
        }

        private void BindData(bool refresh)
        {
            BindData(refresh, _currentSection);
        }

        private void BindData(bool refresh, Sections section)
        {
            PlaceCat cat = PlaceCat.All;
            PlaceTypes placesType = PlaceTypes.All;
            PersonType personType = PersonType.All;
            PlaceSortBy placesSortBy = PlaceSortBy.Type;
            PeopleSortBy peopleSortBy = PeopleSortBy.FullName;
            SortDir sortDir = SortDir.Ascending;
            ObservableCollection<GroupInfoList<object>> data = null;

            if (groupedItemsViewSource != null)
            {
                int placeTypesSkipBy = 0;

                if (comboCat != null && (PlaceCat)comboCat.SelectedIndex == PlaceCat.Nature && comboType != null && (PlaceTypes)comboType.SelectedIndex != PlaceTypes.All)
                    placeTypesSkipBy = 10;


                if (comboCat != null && comboCat.SelectedIndex != -1)
                    cat = (PlaceCat)comboCat.SelectedIndex;

                if (comboType != null && comboType.SelectedIndex != -1)
                    placesType = (PlaceTypes)comboType.SelectedIndex;

                if (comboPeople != null && comboPeople.SelectedIndex != -1)
                    personType = (PersonType)comboPeople.SelectedIndex;

                if (comboSortDir != null && comboSortDir.SelectedIndex != -1)
                    sortDir = (SortDir)comboSortDir.SelectedIndex;


                if (comboSortBy != null && comboSortBy.SelectedIndex != -1)
                {
                    switch (section)
                    {
                        case Sections.WhatsNearMe:
                            placesSortBy = (PlaceSortBy)comboSortBy.SelectedIndex;
                            break;

                        case Sections.WhosNearMe:
                            peopleSortBy = (PeopleSortBy)comboSortBy.SelectedIndex;
                            break;
                    }
                }

               

                switch (section)
                {
                    case Sections.WhatsNearMe:
                        data = DataSource.Places.GetPlacesGroupedBy(cat, placesType, placesSortBy, sortDir, refresh);
                        break;

                    case Sections.WhosNearMe:
                        data = DataSource.People.GetPeopleGroupedBy(personType, peopleSortBy, sortDir, refresh);
                        break;
                }

                if (_data == null)
                {
                    _data = data;

                    groupedItemsViewSource.Source = _data;
                    (semanticZoom.ZoomedOutView as ListViewBase).ItemsSource = groupedItemsViewSource.View.CollectionGroups;
                }
                else
                {
                    //remove all except 1st one due to bug in control that if you remove all and then add any again it doesnt redraw correctly!

                    _data.Clear();
                    /*
                    bool existingData = false;

                    if (_data.Count > 0)
                    {
                        int count = _data.Count;

                        for (int i = count - 1; i > 0; i--)
                            _data.RemoveAt(i);

                        existingData = true;
                    }
                    */

                    for (int i = 0; i < data.Count; i++)
                        _data.Add(data[i]);
                    

                    //now its safe to remove the 1st item.
                   // if (existingData && _data.Count > 0)
                    //    _data.RemoveAt(0);
                }

                /*
                groupedItemsViewSource.Source = _data;
                (semanticZoom.ZoomedOutView as ListViewBase).ItemsSource = groupedItemsViewSource.View.CollectionGroups;

                semanticZoom.UpdateLayout();
                this.UpdateLayout();
                itemGridView.UpdateLayout();
                */
            }
        }

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            GroupInfoList<object> groups = (GroupInfoList<object>)(sender as FrameworkElement).DataContext;

            if (groups != null && groups.Count > 0)
                this.Frame.Navigate(typeof(GroupDetailPage), groups);


            /*
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;
            //List<GroupInfoList> group = (sender as FrameworkElement).DataContext;
            GroupInfoList<object> groups = (GroupInfoList<object> )(sender as FrameworkElement).DataContext;
            //GroupInfoList<NextGenSoftware.BeMindful.Models.Place> places = (GroupInfoList<Place>)(sender as FrameworkElement).DataContext;

            if (groups != null)
            {
                Place place = groups[0] as Place;

                if (place != null)
                {
                    // Navigate to the appropriate destination page, configuring the new page
                    // by passing required information as a navigation parameter
                    //this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);

                    this.Frame.Navigate(typeof(GroupDetailPage), place.ParentId);
                    //this.Frame.Navigate(typeof(SplitPage), itemId);
                }
            }*/
            

            

        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            
              
            //if its in snapped mode we want to go straight to the ItemDetailPage
            if (this.ApplicationViewStates.CurrentState.Name == "Snapped")
                this.Frame.Navigate(typeof(ItemDetailPage), e.ClickedItem);
            else
                this.Frame.Navigate(typeof(SplitPage), e.ClickedItem); // iplace or iperson
              
              
             /*
            dynamic selectedItem;

            if (e.ClickedItem is IPlace)
                selectedItem = e.ClickedItem as IPlace;

            else if (e.ClickedItem is IPerson)
                selectedItem = e.ClickedItem as IPerson;

            IPlaceType placeType = e.ClickedItem as IPlaceType;
            IPlace place = e.ClickedItem as IPlace;

            long itemId = 0;

            if (placeType != null)
                itemId = placeType.Id;

            else if (place != null)
                itemId = place.Id;
            */


            

            //if its in snapped mode we want to go straight to the ItemDetailPage
            if (this.ApplicationViewStates.CurrentState.Name == "Snapped")
                this.Frame.Navigate(typeof(ItemDetailPage), e.ClickedItem);
            //this.Frame.Navigate(typeof(ItemDetailPage), itemId);
            else
            {
                App.ComingFromGroupDetailPage = false;
                this.Frame.Navigate(typeof(SplitPage), e.ClickedItem); // iplace or iperson
            }
        }

        private void comboCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindData(false);
            BindPlaceTypesDropDown();
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindData(false);
        }

        private void BindPlaceTypesDropDown()
        {
            //TODO: Will eventually use that Enum friendly string attribute I normally use... :)
            if (comboCat != null)
            {
                switch ((PlaceCat)comboCat.SelectedIndex)
                {
                    case PlaceCat.All:
                        comboType.ItemsSource = Enum.GetNames(typeof(PlaceTypes)).OrderBy(x => x);
                        break;

                    case PlaceCat.Nature:
                        comboType.ItemsSource = Enum.GetNames(typeof(Nature)).OrderBy(x => x);
                        break;

                    case PlaceCat.Spirituality:
                        comboType.ItemsSource = Enum.GetNames(typeof(Spirituality)).OrderBy(x => x);
                        break;
                }

                comboType.SelectedIndex = 0;
            }
        }

        private void btnTest_Click_1(object sender, RoutedEventArgs e)
        {
            GroupInfoList<object> newGroup = new GroupInfoList<object>();

            newGroup.Key = "Test";
            newGroup.Add(new Place{Title = "test place 1"});
            newGroup.Add(new Place { Title = "test place 2" });
            newGroup.Add(new Place { Title = "test place 3" });

            _data.Add(newGroup);
           
        }

        private void btnRemove_Click_1(object sender, RoutedEventArgs e)
        {
            _data.RemoveAt(_data.Count - 1);

            

        }

        private void btnClear_Click_1(object sender, RoutedEventArgs e)
        {
            _data.Clear();

            semanticZoom.UpdateLayout();
            this.UpdateLayout();
            itemGridView.UpdateLayout();
                


            /*
            GroupInfoList<object> newGroup = new GroupInfoList<object>();

            newGroup.Key = "Test";
            newGroup.Add(new Place { Title = "test place 1" });
            newGroup.Add(new Place { Title = "test place 2" });
            newGroup.Add(new Place { Title = "test place 3" });

            _data.Add(newGroup);

            newGroup.Key = "Test2";
            newGroup.Add(new Place { Title = "test2 place 1" });
            newGroup.Add(new Place { Title = "test2 place 2" });
            newGroup.Add(new Place { Title = "test2 place 3" });

            _data.Add(newGroup);
            */
        }

        private void comboSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindData(false);
        }

        private void comboSortDir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindData(false);
        }

        private void comboPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BindData(false);
        }

        private void pageRoot_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            semanticZoom.Width = e.NewSize.Width;
        }

        /*
        private void comboSection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboSection != null)
            {
                switch (comboSection.SelectedIndex)
                {
                    case 0:
                        this.Frame.Navigate(typeof(HubPage));
                        break;

                    case 1: //What's Near Me
                        this.Frame.Navigate(typeof(GroupedItemsPage));
                        break;
                }
            }

            
        }*/
    }
}
