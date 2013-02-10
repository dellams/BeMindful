using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public class BaseModel : BindableBase, IBaseModel
    {
        public static Uri BaseUri = new Uri("ms-appx:///");
        private string _createdByName;

        public long Id { get; set; }
        public long ParentId { get; set; }
        /*
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Content { get; set; }
         * 
         * 
        */

        public static IBeMindfulDataSource DataSource { get; set; }
       

        public string Created
        {
            get
            {
                return string.Concat(CreatedOn.ToString(), " by ", CreatedBy);
            }
        }

        public string CreatedByName
        {
            get
            {
                if (string.IsNullOrEmpty(_createdByName))
                {
                    //TODO: Need to look up users name with the given id.
                    //DataSource.Get
                }

                return _createdByName;
            }
        }

        public string ImagePath { get; set; }

        private ImageSource _image = null;
        //private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this.ImagePath != null)
                    this._image = new BitmapImage(new Uri(BaseUri, this.ImagePath));

                return this._image;
            }

            set
            {
                this.ImagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }


        public List<string> PicturePaths { get; set; }
        public List<ImageSource> Pictures { get; set; }
        /*
        public List<ImageSource> Pictures
        {
            get
            {
                if (this._image == null && this.ImagePath != null)
                    this._image = new BitmapImage(new Uri(_baseUri, this.ImagePath));

                return this._image;
            }

            set
            {
                this.ImagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }*/

        public void SetImage(String path)
        {
            this._image = null;
            this.ImagePath = path;
            this.OnPropertyChanged("Image");
        }


        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }
}
