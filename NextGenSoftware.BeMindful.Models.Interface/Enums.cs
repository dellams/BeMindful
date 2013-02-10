using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
   // public class Enums
   // {
    public enum Sections
    {
        WhatsNearMe,
        WhosNearMe,
        PresentMomentReminders,
        EchartTV,
        PanicAlarm,
        MindfulnessTraining
    }

        public enum PlaceCat
        {
            All,
            Spirituality,
            Nature
        }

        public enum PlaceTypes
        {
            All,
            Yoga,
            TaiChi,
            MeditationCentre,
            EstaticDance,
            LoveBeaming,
            Healing,
            GuidedMeditation,
            Angelic,
            LightWorkers,
            EchartTolleGroups,
            Park,
            River,
            Stream,
            OpenArea,
            Fields,
            Woods,
            Forest,
            Cliff,
            Beach,
            Coast,
            CoastalWalk
        }
    
        public enum Spirituality
        {
            All,
            Yoga,
            TaiChi,
            MeditationCentre,
            EstaticDance,
            LoveBeaming,
            Healing,
            GuidedMeditation,
            Angelic,
            LightWorkers,
            EchartTolleGroups
        }

        public enum Nature
        {
            All,
            Park,
            River,
            Stream,
            OpenArea,
            Fields,
            Woods,
            Forest,
            Cliff,
            Beach,
            Coast,
            CoastalWalk
        }

        public enum PlaceSortBy
        {
            Type,
            Name,
            Distance,
            Rating,
            Popularity,
            NoPeopleAttending,
            NoPeopleAlreadyThere
        }

        public enum PersonType
        {
            All,
            FriendsOnly 
        }

        public enum PeopleSortBy
        {
            FirstName,
            LastName,
            FullName,
            Distance,
            Rating,
            Aura,
            Position,
            Experience,
            JoinedDate,
            NoEventsAttendted,
            HowManyTimesTheyHaveHelpedSomeone
        }

        public enum SortDir
        {
            Ascending,
            Descending
        }
//    }
}
