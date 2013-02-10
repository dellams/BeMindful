using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models.Core;

namespace NextGenSoftware.BeMindful.Models
{
    public class Event : BaseModel, IEvent
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        
        public string When
        {
            get
            {
                string returnValue;

                if (Start.Date == End.Date)
                    //string.Format(
                    returnValue =  string.Concat(GetDate(Start), " ", GetTime(Start), " - ", GetTime(End));
                else
                    returnValue = string.Concat(GetDateTime(Start), " - ", GetDateTime(End));

                return returnValue;
            }
        }

        public string WhenStart
        {
            get
            {
                return GetDateTime(Start);
            }
        }

        public string WhenFinish
        {
            get
            {
                return GetDateTime(End);
            }
        }

        private string GetDateTime(DateTime date)
        {
            string test = string.Concat(GetDate(date), " ", GetTime(date));
            
            return string.Concat(GetDate(date), " ", GetTime(date));
        }

        private string GetDate(DateTime date)
        {
            string test = string.Concat(date.Day.ToString().PadLeft(2, '0'), "/", date.Date.Month.ToString().PadLeft(2, '0'), "/", date.Date.Year);

            return string.Concat(date.Day.ToString().PadLeft(2, '0'), "/", date.Date.Month.ToString().PadLeft(2, '0'), "/", date.Date.Year);
        }

        private string GetTime(DateTime date)
        {
            string test = string.Concat(date.Hour.ToString().PadLeft(2, '0'), ":", date.Minute.ToString().PadLeft(2, '0'));

            return string.Concat(date.Hour.ToString().PadLeft(2, '0'), ":", date.Minute.ToString().PadLeft(2, '0'));
        }
    }
}
