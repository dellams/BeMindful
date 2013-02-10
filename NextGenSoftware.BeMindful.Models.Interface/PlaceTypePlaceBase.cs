using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public class PlaceTypePlaceBase : BaseModel, IMetroDisplay
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
    }
}
