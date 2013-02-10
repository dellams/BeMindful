using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models.Core;

namespace NextGenSoftware.BeMindful.Models
{
    public class Person : PeoplePersonBase, IPerson, IMetroDisplay
    {
        private int _numberOfPlacesInTheArea;
        private int _numberOfPlacesPersonIsGoingTo;
        private int _numberOfPeopleInTheArea;
        private int _numberOfPlacesPersonHasBeenTo;
        private int _numberOfEventsPersonHasBeenTo;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }

        public string FullName
        {
            get
            {
                return string.Concat(FirstName, " ", LastName);
            }
        }

        public PersonType PersonType { get; set; }

        public string Title
        {
            get
            {
                return FullName;
            }
        }

        public string Subtitle
        {
            get
            {
                return string.Concat("Distance: ", this.DistanceDisplay, " Rating: ", this.Rating);
            }
        }

        public string Content
        {
            get
            {
                return About;
            }
        }

        public virtual int NumberOfPlacesInTheArea
        {
            get
            {
                return _numberOfPlacesInTheArea;
            }
        }

        public virtual int NumberOfPlacesPersonIsGoingTo
        {
            get
            {
                return _numberOfPlacesPersonIsGoingTo;
            }
        }

        public virtual int NumberOfPeopleInTheArea
        {
            get
            {
                return _numberOfPeopleInTheArea;
            }
        }

        public virtual int NumberOfPlacesPersonHasBeenTo
        {
            get
            {
                return _numberOfPlacesPersonHasBeenTo;
            }
        }

        public virtual int NumberOfEventsPersonHasBeenTo
        {
            get
            {
                return _numberOfEventsPersonHasBeenTo;
            }
        }
        
    }
}
