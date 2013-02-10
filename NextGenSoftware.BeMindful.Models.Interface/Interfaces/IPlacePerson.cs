using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IPlacePerson : IBaseModel
    {
        string DistanceDisplay { get; }
        int Distance { get; }
        int Rating { get; set; }
        IEvent NextEvent { get; }
        //IList<IEvent> Events { get; set; }
    }
}
