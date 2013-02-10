using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPlaceDetail : IPlacePerson, IMetroDisplay
    {
        IPlaceType Parent { get; set; }

        IList<IPerson> PeopleGoing { get; set; }
        IList<IPerson> PeopleThere { get; set; }
        IList<IPerson> PeopleInTheArea { get; set; }
        IList<IEvent> Events { get; set; }
    }
}
