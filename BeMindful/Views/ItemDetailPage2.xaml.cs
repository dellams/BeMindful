
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

    public enum ItemDetailSectionType
    {
        PeopleSummary,
        PlacesSummary,
        Map,
        PeopleThere,
        PeopleGoing,
        PeopleNear,
        Events,
        Gallery,
        Rating,
        PersonIsAt,
        PersonIsGoingTo
    }
    public class ItemDetailSection
    {
        public string Title { get; set; }
        public object Content { get; set; }
        public ItemDetailSectionType Section { get; set; }
        //public List<IBaseModel> Items { get; set; }
        //public Place Place { get; set; }
    }

    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SummaryTemplate { get; set; }
        public DataTemplate PeopleSummaryTemplate2 { get; set; }
        public DataTemplate MapTemplate { get; set; }
        public DataTemplate PeopleThereTemplate { get; set; }
        public DataTemplate PeopleGoingTemplate { get; set; }
        public DataTemplate PeopleNearTemplate { get; set; }
        public DataTemplate RatingTemplate { get; set; }
        public DataTemplate EventsTemplate { get; set; }
        public DataTemplate GalleryTemplate { get; set; }
        public DataTemplate PersonIsAtTemplate { get; set; }
        public DataTemplate PersonIsGoingToTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is ItemDetailSection)
            {
                switch (((ItemDetailSection)item).Section)
                {
                    case ItemDetailSectionType.PlacesSummary:
                        return PlacesSummaryTemplate;

                    case ItemDetailSectionType.PeopleSummary:
                        return PeopleSummaryTemplate;

                    case ItemDetailSectionType.Map:
                        return MapTemplate;

                    case ItemDetailSectionType.PeopleThere:
                        return PeopleThereTemplate;

                    case ItemDetailSectionType.PeopleGoing:
                        return PeopleGoingTemplate;

                    case ItemDetailSectionType.PeopleNear:
                        return PeopleNearTemplate;

                    case ItemDetailSectionType.Events:
                        return EventsTemplate;

                    case ItemDetailSectionType.Rating:
                        return RatingTemplate;

                    case ItemDetailSectionType.Gallery:
                        return GalleryTemplate;

                    case ItemDetailSectionType.PersonIsAt:
                        return PersonIsAtTemplate;

                    case ItemDetailSectionType.PersonIsGoingTo:
                        return PersonIsGoingToTemplate;
                }
            }
            return base.SelectTemplateCore(item, container);
        }
    }

    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    public sealed partial class ItemDetailPage2 : BeMindful.Common.LayoutAwarePage
    {
       

        public ItemDetailPage2()
        {
            this.InitializeComponent();
            this.Loaded += ItemDetailPage2_Loaded;
        }

        void ItemDetailPage2_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            slideView.Items.Add(new ItemDetailSection { Title = "Summary" });
            slideView.Items.Add(new ItemDetailSection { Title = "Map" });
            slideView.Items.Add(new ItemDetailSection { Title = "People There" });
             * 
             * 
             */

            
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
            base.LoadState(navigationParameter, pageState);

  
            //TODO: Do we want to cache these or not? // Oh yeah, forgot DataSource has built in caching! :) (need to consider suspending and resumming in future...)

            IBaseModel selectedItem = null;

            switch (DataSource.SelectedItemType)
            {
                case ObjetType.Place:
                    selectedItem = DataSource.Places.GetPlaceDetails((DataSource.SelectedItem as IBaseModel).Id);
                    break;

                case ObjetType.Person:
                    selectedItem = DataSource.People.GetPersonDetails((DataSource.SelectedItem as IBaseModel).Id);
                    break;
            }

            //common sections
            List<ItemDetailSection> sections = new List<ItemDetailSection>
            {
                //new ItemDetailSection
                //{
                //     Section = ItemDetailSectionType.Summary,
                //     Title = "Summary",
                //     Content = selectedItem
                //},
                new ItemDetailSection
                {
                    Section = ItemDetailSectionType.Map,
                    Title = "Map",
                    Content = selectedItem
                },
                new ItemDetailSection
                {
                    Section = ItemDetailSectionType.PeopleNear,
                    Title = "People Near By",
                    Content = selectedItem
                }
            };

            switch (DataSource.SelectedItemType)
            {
                case ObjetType.Place:
                    {
                        sections.AddRange
                        (
                            new List<ItemDetailSection>
                            {
                                new ItemDetailSection
                                {
                                     Section = ItemDetailSectionType.PlacesSummary,
                                     Title = "Summary",
                                     Content = selectedItem
                                },
                                new ItemDetailSection
                                {
                                    Section = ItemDetailSectionType.PeopleThere,
                                    Title = "People There",
                                    Content = selectedItem
                                },
                                new ItemDetailSection
                                {
                                    Section = ItemDetailSectionType.PeopleGoing,
                                    Title = "People Going",
                                    Content = selectedItem
                                }
                            }
                        );
                    }
                    break;

                case ObjetType.Person:
                    {
                        sections.AddRange
                        (
                            new List<ItemDetailSection>
                            {
                               new ItemDetailSection
                                {
                                     Section = ItemDetailSectionType.PeopleSummary,
                                     Title = "Summary",
                                     Content = selectedItem
                                },
                                new ItemDetailSection
                                {
                                    Section = ItemDetailSectionType.PersonIsAt,
                                    Title = "Person Is At",
                                    Content = selectedItem
                                },
                                new ItemDetailSection
                                {
                                    Section = ItemDetailSectionType.PersonIsGoingTo,
                                    Title = "Person Is Going To",
                                    Content = selectedItem
                                }
                            }
                        );
                    }
                    break;
            }



            // Remember the details are cached in the SplitPage when an item is selected.
           


           // this.DefaultViewModel["SelectedPlaceDetail"] = selectedItem;

            this.DefaultViewModel["Sections"] = sections;

           

                
       
           


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

            //pageState["SelectedItem"] = flipView.SelectedItem;

           // if (flipView.SelectedItem != null)
             //   DataSource.SelectedItem = (IBaseModel)flipView.SelectedItem;
        }

        private void Header_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartLayoutUpdates(object sender, RoutedEventArgs e)
        {

        }

        private void GridView_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Handled = true;
            //e.Data. //TODO: Explore this more...
        }

        private void GridView_DragItemsStarting_1(object sender, DragItemsStartingEventArgs e)
        {
            e.Cancel = true;
        }

        private void GridView_DragLeave_1(object sender, DragEventArgs e)
        {
            
        }

        private void GridView_DragOver_1(object sender, DragEventArgs e)
        {

        }


        private void gvPeopleThere_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.Frame.Navigate(typeof(GroupedItemsZoomPage), e.ClickedItem); //IPlace or IPerson
        }

      

        private void gvPeopleThere_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GotoItemDetail(sender);
        }

        private void GotoItemDetail(object sender)
        {
            GridView gridView = sender as GridView;

            if (gridView != null)
            {
                DataSource.SelectedItem = gridView.SelectedItem as IBaseModel;
                this.Frame.Navigate(typeof(ItemDetailPage2), gridView.SelectedItem); //IPlace or IPerson
            }
        }

     
        private void gvPersonIsGoingTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GotoItemDetail(sender);
        }

        private void gvPeopleGoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GotoItemDetail(sender);
        }
    }
}
