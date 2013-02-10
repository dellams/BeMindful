using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPlace : IPlacePerson, IMetroDisplay
    {
        IPlaceType Parent { get; set; }

        int NumberOfPeopleGoing { get; }
        int NumberOfPeopleThere { get; }
        int NumberOfPeopleInTheArea { get; }
        int NumberOfEventsHeld { get; }
    }
}
