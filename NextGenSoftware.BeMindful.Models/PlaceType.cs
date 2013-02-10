using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models.Core;

namespace NextGenSoftware.BeMindful.Models
{
    public class PlaceType : PlaceTypePlaceBase, IPlaceType
    {
        public IList<IPlace> Places { get; set; }
        public PlaceTypes PlacesType { get; set; }
        public PlaceCat CatType { get; set; }
       

        // Provides a subset of the full items collection to bind to from a GroupedItemsPage
        // for two reasons: GridView will not virtualize large items collections, and it
        // improves the user experience when browsing through groups with large numbers of
        // items.
        //
        // A maximum of 12 items are displayed because it results in filled grid columns
        // whether there are 1, 2, 3, 4, or 6 rows displayed
        
        //TODO: Need to implement this properly. Max 12 items, see sample data code.
        public IList<IPlace> TopItems
        {
            get
            {
                return Places.Take(12).ToList();
            }
        }
    }
}
