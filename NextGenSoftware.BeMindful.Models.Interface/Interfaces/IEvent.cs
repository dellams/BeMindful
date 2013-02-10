using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IEvent : IBaseModel
    {
        string Name { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Description { get; set; }

        string WhenStart { get; }
        string WhenFinish { get; }
        string When { get; }
        //string Name { get; set; }
    }
}
