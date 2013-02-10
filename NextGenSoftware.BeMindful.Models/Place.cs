using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using NextGenSoftware.BeMindful.Models.Core;


namespace NextGenSoftware.BeMindful.Models
{
    public class Place : PlaceTypePlaceBase, IPlace
    {
        //private IList<IEvent> _events;
        private int _numberOfPeopleGoing;
        private int _numberOfPeopleThere;
        private int _numberOfPeopleInTheArea;
        private int _numberOfEventsHeld;

        //Temp till plugged into Azure, etc!
        public Place(int numberOfPeopleGoing, int numberOfPeopleThere, int numberOfPeopleInTheArea)
        {
            _numberOfPeopleGoing = numberOfPeopleGoing;
            _numberOfPeopleThere = _numberOfPeopleThere;
            _numberOfPeopleInTheArea = numberOfPeopleInTheArea;
        }

        public Place()
        {

        }

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

        //public int NumberOfEventsHeld { get; set; }

        public virtual int NumberOfEventsHeld
        {
            get
            {
                return _numberOfEventsHeld;
            }
        }
        public virtual int NumberOfPeopleGoing
        {
            get
            {
                return _numberOfPeopleGoing;
            }
        }

        public virtual int NumberOfPeopleThere
        {
            get
            {
                return _numberOfPeopleThere;
            }
        }

        public virtual int NumberOfPeopleInTheArea
        {
            get
            {
                return _numberOfPeopleInTheArea;
            }
        }

       // public virtual int NumberOfPeopleThere { get; }
        //public virtual int NumberOfPeopleInTheArea { get; }

        public IPlaceType Parent { get; set; }

        /*
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
         * */

        public IEvent NextEvent { get; set; }
        /*
        public int NumberOfEventsHeld
        {
            get
            {
                return Events.Count();
            }
        }*/

        /*
        public IEvent NextEvent
        {
            get
            
                return Events.OrderBy(x => x.Start).FirstOrDefault() as Event;
            }
        }*/
         
    }
}
