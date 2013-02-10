using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPerson : IPlacePerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string About { get; set; }
        PersonType PersonType { get; set; }

        int NumberOfPlacesInTheArea { get; }
        int NumberOfPlacesPersonIsGoingTo { get; }
        int NumberOfPeopleInTheArea { get; }
        int NumberOfPlacesPersonHasBeenTo { get; }
        int NumberOfEventsPersonHasBeenTo { get; }
    }
}
