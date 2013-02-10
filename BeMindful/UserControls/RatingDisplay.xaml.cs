using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BeMindful.UserControls
{
    public sealed partial class RatingDisplay : UserControl
    {
        private static RatingDisplay _instance;

        public static readonly DependencyProperty RatingProperty =
           DependencyProperty.Register("Rating", typeof(int),
           typeof(RatingDisplay), new PropertyMetadata(0, (x, y) => 
           {
               int value = (int)y.NewValue;

               if (_instance != null)
               {
                   if (value > 0)
                   {
                       _instance.txtUnrated.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       _instance.imgOne.Visibility = Windows.UI.Xaml.Visibility.Visible;
                   }

                   if (value > 1)
                       _instance.imgTwo.Visibility = Windows.UI.Xaml.Visibility.Visible;

                   if (value > 2)
                       _instance.imgThree.Visibility = Windows.UI.Xaml.Visibility.Visible;

                   if (value > 3)
                       _instance.imgFour.Visibility = Windows.UI.Xaml.Visibility.Visible;

                   if (value > 4)
                       _instance.imgFive.Visibility = Windows.UI.Xaml.Visibility.Visible;
               }
               
           }));

        public RatingDisplay()
        {
            this.InitializeComponent();
            _instance = this;
        }

        public int Rating
        {
            get
            {
                return (int)this.GetValue(RatingProperty);
            }
            set
            {
                this.SetValue(RatingProperty, value);
                  /*  
                if (value > 0)
                {
                    txtUnrated.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    imgOne.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }

                if (value > 1)
                    imgTwo.Visibility = Windows.UI.Xaml.Visibility.Visible;

                if (value > 2)
                    imgThree.Visibility = Windows.UI.Xaml.Visibility.Visible;

                if (value > 3)
                    imgFour.Visibility = Windows.UI.Xaml.Visibility.Visible;

                if (value > 4)
                    imgFive.Visibility = Windows.UI.Xaml.Visibility.Visible;*/
            }
        }
    }
}
