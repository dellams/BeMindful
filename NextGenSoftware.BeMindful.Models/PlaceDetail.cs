using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NextGenSoftware.BeMindful.Models.Core;


namespace NextGenSoftware.BeMindful.Models
{
    //public class PlaceDetail : PlaceTypePlaceBase, IPlaceDetail
    public class PlaceDetail : Place, IPlaceDetail
    {
        private IList<IEvent> _events;

        /*
        public string DistanceDisplay
        {
            get
            {
                if (Distance < 1000)
                    return string.Concat(Distance, " meteres");
                else
                {
                    int distance = Distance / 1000;
                    return string.Concat(distance, " mile", distance > 1 ? "s" : string.Empty);
                }
            }
        }

        public int Distance { get; set; }
        public int Rating { get; set; }
        */


        public IList<IPerson> PeopleGoing { get; set; }
        public IList<IPerson> PeopleThere { get; set; }
        public IList<IPerson> PeopleInTheArea { get; set; }

        public IList<IPerson> PeopleGoingSummary
        {
            get
            {
                if (PeopleGoing == null)
                    PeopleGoing = new List<IPerson>();

                return PeopleGoing.Take(36).ToList();
            }
        }

        public IList<IPerson> PeopleThereSummary
        {
            get
            {
                if (PeopleThere == null)
                    PeopleThere = new List<IPerson>();

                return PeopleThere.Take(36).ToList();
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

        public override int NumberOfPeopleGoing
        {
            get
            {
                if (PeopleGoing == null)
                    PeopleGoing = new List<IPerson>();

                return PeopleGoing.Count();
            }
        }

        public override int NumberOfPeopleThere
        {
            get
            {
                if (PeopleThere == null)
                    PeopleThere = new List<IPerson>();

                return PeopleThere.Count();
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

       // public IList<IEvent> Events { get; set; }

        //public IPlaceType Parent { get; set; }

        public IList<IEvent> Events
        {
            get
            {
                if (_events == null)
                    _events = new List<IEvent>();

                return (IList<IEvent>)_events;
            }
            set
            {
                _events = (IList<IEvent>)value;
            }
        }

       // public IEvent NextEvent { get; set; }


        public int NumberOfEventsHeld
        {
            get
            {
                return Events.Count();
            }
        }

        
        public IEvent NextEvent
        {
            get
            {
                return Events.OrderBy(x => x.Start).FirstOrDefault() as Event;
            }
        }
         
    }
}
