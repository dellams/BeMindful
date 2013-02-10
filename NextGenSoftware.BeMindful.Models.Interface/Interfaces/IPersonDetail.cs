using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPersonDetail : IPlacePerson, IMetroDisplay
    {
        IPlace PersonIsAt { get; set; }

        IList<IPlace> PlacesInTheArea { get; set; }
        IList<IPlace> PlacesPersonIsGoingTo { get; set; }
        IList<IPerson> PeopleInTheArea { get; set; }
        IList<IPlace> PlacesPersonHasBeenTo { get; set; }
        IList<IEvent> EventsPersonHasBeenTo { get; set; }


        IList<IPlace> PlacesInTheAreaSummary { get; }
        IList<IPlace> PlacesPersonIsGoingToSummary { get; }
        IList<IPerson> PeopleInTheAreaSummary { get; }
        IList<IPlace> PlacesPersonHasBeenToSummary { get; }
        IList<IEvent> EventsPersonHasBeenToSummary { get; }
       

       
        

        
        //IList<IEvent> Events { get; set; } //TODO: Not sure whether to treat individual people who provide services as a Place or not?
    }
}
