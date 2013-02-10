using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NextGenSoftware.BeMindful.Models.Core;


namespace NextGenSoftware.BeMindful.Models
{
    public class PersonDetail : Person, IPersonDetail
    {
        

        public IList<IPlace> PlacesInTheArea { get; set; }
        public IPlace PersonIsAt { get; set; }
        public IList<IPlace> PlacesPersonIsGoingTo { get; set; }
        public IList<IPerson> PeopleInTheArea { get; set; }
        public IList<IPlace> PlacesPersonHasBeenTo { get; set; }
        public IList<IEvent> EventsPersonHasBeenTo { get; set; }

        public IList<IPlace> PlacesInTheAreaSummary
        {
            get
            {
                if (PlacesInTheArea == null)
                    PlacesInTheArea = new List<IPlace>();

                return PlacesInTheArea.Take(36).ToList();
            }
        }

        public IList<IPlace> PlacesPersonIsGoingToSummary
        {
            get
            {
                if (PlacesPersonIsGoingTo == null)
                    PlacesPersonIsGoingTo = new List<IPlace>();

                return PlacesPersonIsGoingTo.Take(36).ToList();
            }
        }

        public IList<IPerson> PeopleInTheAreaSummary
        {
            get
            {
                if (PeopleInTheArea == null)
                    PeopleInTheArea = new List<IPerson>();

                return PeopleInTheArea.Take(36).ToList();
            }
        }

        public IList<IPlace> PlacesPersonHasBeenToSummary
        {
            get
            {
                if (PlacesPersonHasBeenTo == null)
                    PlacesPersonHasBeenTo = new List<IPlace>();

                return PlacesPersonHasBeenTo.Take(36).ToList();
            }
        }

        public IList<IEvent> EventsPersonHasBeenToSummary
        {
            get
            {
                if (EventsPersonHasBeenTo == null)
                    EventsPersonHasBeenTo = new List<IEvent>();

                return EventsPersonHasBeenTo.Take(36).ToList();
            }
        }

        public override int NumberOfPlacesInTheArea
        {
            get
            {
                if (PlacesInTheArea == null)
                    PlacesInTheArea = new List<IPlace>();

                return PlacesInTheArea.Count();
            }
        }

        public override int NumberOfPlacesPersonIsGoingTo
        {
            get
            {
                if (PlacesPersonIsGoingTo == null)
                    PlacesPersonIsGoingTo = new List<IPlace>();

                return PlacesPersonIsGoingTo.Count();
            }
        }

        public override int NumberOfPeopleInTheArea
        {
            get
            {
                if (PeopleInTheArea == null)
                    PeopleInTheArea = new List<IPerson>();

                return PeopleInTheArea.Count();
            }
        }

        public override int NumberOfPlacesPersonHasBeenTo
        {
            get
            {
                if (PlacesPersonHasBeenTo == null)
                    PlacesPersonHasBeenTo = new List<IPlace>();

                return PlacesPersonHasBeenTo.Count();
            }
        }

        public override int NumberOfEventsPersonHasBeenTo
        {
            get
            {
                if (EventsPersonHasBeenTo == null)
                    EventsPersonHasBeenTo = new List<IEvent>();

                return EventsPersonHasBeenTo.Count();
            }
        }

      //  public IPlaceType Parent { get; set; }


        //public IList<IEvent> Events
        //{
        //    get
        //    {
        //        if (_events == null)
        //            _events = new List<IEvent>();

        //        return (IList<IEvent>)_events;
        //    }
        //    set
        //    {
        //        _events = (IList<IEvent>)value;
        //    }
        //}

       // public IEvent NextEvent { get; set; }


        //public int NumberOfEventsHeld
        //{
        //    get
        //    {
        //        return Events.Count();
        //    }
        //}

        
        //public IEvent NextEvent
        //{
        //    get
        //    {
        //        return Events.OrderBy(x => x.Start).FirstOrDefault() as Event;
        //    }
        //}
         
    }
}
