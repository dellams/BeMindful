using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPlaceType : IMetroDisplay
    {
        IList<IPlace> Places { get; set; }
        PlaceTypes PlacesType { get; set; }
        PlaceCat CatType { get; set; }
    }
}
