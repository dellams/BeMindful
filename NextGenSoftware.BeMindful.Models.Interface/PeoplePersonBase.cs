using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public class PeoplePersonBase : BaseModel, IPlacePerson
    {
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

        public List<IEvent> Events { get; set; }

        public Event NextEvent
        {
            get
            {
                return 
            }
        }
    }
}
