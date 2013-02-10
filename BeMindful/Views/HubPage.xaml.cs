//using BeMindful.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using NextGenSoftware.BeMindful.Data.Providers.WebAPIProvider;
using NextGenSoftware.BeMindful.Models;
using NextGenSoftware.BeMindful.Models.Core;
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
using BeMindful.Common;
using BeMindful.UserControls;
using BeMindful.Views;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace BeMindful
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class HubPage : BeMindful.Common.LayoutAwarePage
    {
        public HubPage()
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
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            //var sampleDataGroups = SampleDataSource.GetGroups((String)navigationParameter);
            //this.DefaultViewModel["Items"] = sampleDataGroups;


           // var place = DataSource<BeMindfulDataSource>.Instance.GetPlace(4);

            //var placeTypes = DataSource.Instance.GetPlaceTypesForCat(PlaceCat.PlacesToPracticeSpirituality);
            //var placeTypes = DataSource<BeMindfulDataSource>.Instance.GetPlaceTypesForCat(PlaceCat.PlacesToPracticeSpirituality);
            //var placeTypes = DataSource.Instance.GetPlaceTypesForCat(PlaceCat.PlacesToPracticeSpirituality);


            this.DefaultViewModel["Items"] = new List<PlaceType>()
            {
                new PlaceType
                {
                    Id = 0, 
                    Title = "What's Near Me"
                }
                ,
                new PlaceType
                {
                    Id = 1,
                    Title = "Who's Near Me"
                },
                new PlaceType
                {
                    Id = 2,
                    Title = "Present Moment Reminders"
                },
                new PlaceType
                {
                    Id = 3,
                    Title = "Echart TV"
                },
                new PlaceType
                {
                    Id = 4,
                    Title = "Panic Alarm"
                }
                ,
                new PlaceType
                {
                    Id = 5,
                    Title = "Mindfulness Training"
                }
            };

           // return null;

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
           // var groupId = ((SampleDataGroup)e.ClickedItem).UniqueId;
           // this.Frame.Navigate(typeof(SplitPage), groupId);

            var sectionId = ((IPlaceType)e.ClickedItem).Id;

            switch ((Sections)sectionId)
            {
                case Sections.WhatsNearMe:
                    this.Frame.Navigate(typeof(GroupedItemsZoomPage), sectionId);
                    break;

                case Sections.WhosNearMe:
                    this.Frame.Navigate(typeof(GroupedItemsZoomPage), sectionId);    
                    break;

                case Sections.PresentMomentReminders:
                    this.Frame.Navigate(typeof(GroupedItemsPage), sectionId);   
                   // this.Frame.Navigate(typeof(HorizontalTabbedViewxaml), sectionId);    
                //this.Frame.Navigate(typeof(RatingExample), sectionId);
                    //Frame.Navigate(typeof(ExamplePage), new ExampleModel("Rating", new RatingExample(), "Rating"));
                    break;

                case Sections.MindfulnessTraining:
                   // this.Frame.Navigate(typeof(VerticalTabbedView), sectionId);  
                    //this.Frame.Navigate(typeof(ContentContainersModule), sectionId);  
                    this.Frame.Navigate(typeof(ItemDetailPage4), new Place()); 
                    
                    break;

                case Sections.PanicAlarm:
                    this.Frame.Navigate(typeof(ItemDetailPage2), sectionId); 
                    break;

                case Sections.EchartTV:
                    //this.Frame.Navigate(typeof(ItemDetailPage), sectionId);
                    break;

                    //TODO: Add rest here...

            }
        }
    }
}
