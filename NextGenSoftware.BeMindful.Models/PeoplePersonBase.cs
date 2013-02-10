using NextGenSoftware.BeMindful.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextGenSoftware.BeMindful.Models
{
    public class PeoplePersonBase : BaseModel, IPlacePerson
    {
        //private IList<IEvent> _events;

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
        }*/

        public IEvent NextEvent { get; set; }

        //public IEvent NextEvent
        //{
        //    get
        //    {
        //        return Events.OrderBy(x => x.Start).FirstOrDefault() as Event;
        //    }
        //}
    }
}
