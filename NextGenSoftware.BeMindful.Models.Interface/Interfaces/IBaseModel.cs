using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IBaseModel
    {
        long Id { get; set; }
        long ParentId { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn  { get; set; }
        int CreatedBy { get; set; }
        int ModifiedBy { get; set; }
        ImageSource Image { get; set; }
        List<ImageSource> Pictures { get; set; }
    }
}
