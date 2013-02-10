using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IMetroDisplay : IBaseModel
    {
        string Title { get; }
        string Subtitle { get; }
        string Content { get; }
    }
}
