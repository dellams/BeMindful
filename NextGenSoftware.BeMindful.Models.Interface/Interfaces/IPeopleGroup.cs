using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core.Interfaces
{
    public interface IPeopleGroup : IMetroDisplay
    {
        IList<IPerson> People { get; set; }
        PersonType PeopleType { get; set; }
    }
}
