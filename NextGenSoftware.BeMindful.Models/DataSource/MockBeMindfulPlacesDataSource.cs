using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models.Core;

namespace NextGenSoftware.BeMindful.Models
{

    public partial class MockBeMindfulDataSource : IBeMindfulDataSource
    {
        private IPlace _lastPlace;
        int _imageCounter;

        public IPlaceDetail GetPlaceDetails(long placeId)
        {
            return new PlaceDetail
            {
                Content = "blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah ",
                CreatedBy = 0,
                CreatedOn = DateTime.Now,
                Events = new List<IEvent>
                 {
                      new Event{ Name =  "Dave's Aawesome Event!", Start = DateTime.Now, End = DateTime.Now.AddHours(3)}, 
                      new Event{ Name =  "Dave's 2nd Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 3rd Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 4th Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 5th Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                 },

                Distance = 100,
                PeopleGoing = GetPeopleGoingPlace(null), //NOTE: These will not be seperate calls from live dta since will all be pulled back in one hit so is more efficient...
                PeopleInTheArea = GetPeopleNearPlace(null),
                PeopleThere = GetPeopleAtPlace(null), //TODO: Not sure whether to load ALL people or just 10 or whatever it is to fill the grid, then load the rest when they click the People heading to view the People detail
                Title = "Dave's Place!",
                Rating = 5,
                Subtitle = "Dave's Place is the place to be! :o )",
                ImagePath = "Assets/LightGray.png"
            };
        }

        public IList<IPlace> GetAllPlaces()
        {
            return new List<IPlace>();
            //return GenerateMockDataForPlace("yoga", 10).Concat(GenerateMockDataForPlace("tai chi", 10
        }

        public IList<IPlaceType> GetAllPlaceTypes()
        {
            //TODO: May just create a new cat called All and use method below...
            return new List<IPlaceType>
            {
                GetPlaceType("Yoga"),
                GetPlaceType("MeditationCentres"),
                GetPlaceType("TaiChi"),
                GetPlaceType("Tantra"),
                GetPlaceType("Trees"),
                GetPlaceType("Raikea"),
                GetPlaceType("Parks"),
                GetPlaceType("River"),
                
                GetPlaceType("OpenAreas"),
                GetPlaceType("OrangeTrees")
            };
        }

        //List<IPlace> GetAllPlacesForCatAndType(PlaceCat cat, PlaceTypes placeType);

        public IList<IPlace> GetAllPlacesForCatAndType(PlaceCat cat, PlaceTypes placeType)
        {
            List<IPlace> places = new List<IPlace>();
            //simulate a table in the db 
            /*
            places.AddRange(GenerateMockDataForPlace("Yoga", 10));
            places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
            places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
            places.AddRange(GenerateMockDataForPlace("Parks", 10));
            places.AddRange(GenerateMockDataForPlace("Rivers", 10));
            places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
            */


            //return places.Where(x => x.
            /*
             switch (placeType)
             {
                 case 
             */

            switch (cat)
            {
                case PlaceCat.Spirituality:
                    {
                        switch (placeType)
                        {
                            case PlaceTypes.All:
                                {
                                    places.AddRange(GenerateMockDataForPlace("Yoga", 10));
                                    places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                                    places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                                } break;

                            case PlaceTypes.Yoga:
                                {
                                    places.AddRange(GenerateMockDataForPlace("Yoga", 10));

                                } break;

                            case PlaceTypes.TaiChi:
                                places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                                break;

                            case PlaceTypes.MeditationCentre:
                                places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                                break;

                        }
                    } break;

                case PlaceCat.Nature:
                    {
                        switch (placeType)
                        {
                            case PlaceTypes.All:
                                {
                                    places.AddRange(GenerateMockDataForPlace("Parks", 10));
                                    places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                                    places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                                } break;

                            case PlaceTypes.OpenArea:
                                places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                                break;

                            case PlaceTypes.Park:
                                places.AddRange(GenerateMockDataForPlace("Parks", 10));
                                break;

                            case PlaceTypes.River:
                                places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                                break;

                        }
                    } break;

                case PlaceCat.All:
                    {
                        switch (placeType)
                        {
                            case PlaceTypes.All:
                                {
                                    places.AddRange(GenerateMockDataForPlace("Yoga", 10));
                                    places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                                    places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                                    places.AddRange(GenerateMockDataForPlace("Parks", 10));
                                    places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                                    places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                                } break;

                            case PlaceTypes.Yoga:
                                {
                                    places.AddRange(GenerateMockDataForPlace("Yoga", 10));

                                } break;

                            case PlaceTypes.TaiChi:
                                places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                                break;

                            case PlaceTypes.MeditationCentre:
                                places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                                break;

                            case PlaceTypes.OpenArea:
                                places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                                break;

                            case PlaceTypes.Park:
                                places.AddRange(GenerateMockDataForPlace("Parks", 10));
                                break;

                            case PlaceTypes.River:
                                places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                                break;

                        }

                    } break;
            }
            return places;
        }


        public IList<IPlaceType> GetAllPlaceTypesForCatAndType(PlaceCat cat, PlaceTypes type)
        {
            switch (cat)
            {
                case PlaceCat.Spirituality:
                    {
                        return new List<IPlaceType>
                        {
                            GetPlaceType("Yoga"),
                            GetPlaceType("MeditationCentre"),
                            GetPlaceType("TaiChi"),
                            GetPlaceType("LoveBeaming"),
                            GetPlaceType("EstaticDance")
                        };
                    } break;

                case PlaceCat.Nature:
                    {
                        return new List<IPlaceType>
                        {
                            GetPlaceType("Park"),
                            GetPlaceType("CoastalWalk"),
                            GetPlaceType("River"),
                            GetPlaceType("OpenArea"),
                            GetPlaceType("Woods")
                        };
                    } break;

                default:
                case PlaceCat.All:
                    {
                        return new List<IPlaceType>
                        {
                            GetPlaceType("Yoga"),
                            GetPlaceType("MeditationCentre"),
                            GetPlaceType("TaiChi"),
                            GetPlaceType("LoveBeaming"),
                            GetPlaceType("Park"),
                            GetPlaceType("EstaticDance"),
                            GetPlaceType("CoastalWalk"),
                            GetPlaceType("River"),
                            GetPlaceType("OpenArea"),
                            GetPlaceType("Woods")
                        };
                    } break;
            }
        }



        public List<PlaceType> GetPlaceTypesForCat(PlaceCat cat)
        {
            switch (cat)
            {
                case PlaceCat.Spirituality:
                    return new List<PlaceType>{
                         GetPlaceType("Yoga"),
                        GetPlaceType("Meditation Centres"),
                        GetPlaceType("Tai Chi")};

                case PlaceCat.Nature:
                    return new List<PlaceType>{
                        GetPlaceType("parks"),
                        GetPlaceType("rivers"),
                        GetPlaceType("open areas")};

                default:
                    return new List<PlaceType>();
            }
        }



        public IList<IPlace> GetAllPlacesForCat(PlaceCat cat)
        {
            List<IPlace> places = new List<IPlace>();

            switch (cat)
            {
                case PlaceCat.Spirituality:
                    {
                        places.AddRange(GenerateMockDataForPlace("Yoga", 10));
                        places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                        places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                    } break;

                case PlaceCat.Nature:
                    {
                        places.AddRange(GenerateMockDataForPlace("Parks", 10));
                        places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                        places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                    } break;

                case PlaceCat.All:
                    {
                        places.AddRange(GenerateMockDataForPlace("Yoga", 10));
                        places.AddRange(GenerateMockDataForPlace("Meditation Centres", 10));
                        places.AddRange(GenerateMockDataForPlace("Tai Chi", 10));
                        places.AddRange(GenerateMockDataForPlace("Parks", 10));
                        places.AddRange(GenerateMockDataForPlace("Rivers", 10));
                        places.AddRange(GenerateMockDataForPlace("Open Areas", 10));
                    } break;
            }

            return places;
        }

        public IList<IPlace> GetPlacesForType(long placeTypeId)
        {

            return GenerateMockDataForPlace("yoga", 10);

            // return GenerateMockDataForPlace(type, 10);

        }


        public IPlace GetPlacePersonIsAt(IPerson person)
        {
            return GenerateMockDataForPlace("TaiChi", 1)[0];
        }

        public IList<IPlace> GetPlacesPersonIsGoing(IPerson person)
        {
            return GenerateMockDataForPlace("Yoga", 10);
        }

        public IList<IPlace> GetPlacesPersonIsNear(IPerson person)
        {
            return GenerateMockDataForPlace("Yoga", 10);
        }

        public IList<IPlace> GetPlacesForType(string type)
        {
            return GenerateMockDataForPlace(type, 10);

            /*
            switch (type)
            {
                case "yoga":
                    return GenerateMockDataForPlace("yoga", 10);

                case "meditation":
                    return GenerateMockDataForPlace("yoga", 10);

                default:
                    return new List<IPlace>();
            }*/
        }

        //private IList<IPlace> GenerateMockDataForPlace(string name, int number)
        private IList<IPlace> GenerateMockDataForPlace(string name, int number, PlaceType parentPlaceType = null)
        {
            IList<IPlace> places = new List<IPlace>();
            int imageCounter = 0;
            string imagePath = string.Empty;
            string title = string.Empty;

            string[] yogaNames = new string[] { "Daves Super Yoga Club", "Jims Yoga Club", "Yoga for everyone" };
            string[] taiChiNames = new string[] { "Daves Super Tai Chi Club", "Ta Chi Mania!", "Tai Chi for everyone" };
            string[] genericNames = new string[] { "Daves Super {0} Club", "{0} Mania!", "{0} for everyone" };

            for (int i = 0; i < number; i++)
            {
                switch (imageCounter)
                {
                    case 0:
                        imagePath = "Assets/LightGray.png";
                        break;

                    case 1:
                        imagePath = "Assets/MediumGray.png";
                        break;

                    case 2:
                        imagePath = "Assets/DarkGray.png";
                        break;

                }

                switch (name.ToLower())
                {
                    case "yoga":
                        title = yogaNames[imageCounter];
                        break;

                    case "tai chi":
                        title = taiChiNames[imageCounter];
                        break;

                    default:
                        title = string.Format(genericNames[imageCounter], name);
                        break;

                }

                imageCounter++;

                if (imageCounter > 2)
                    imageCounter = 0;

                Random random = new Random();
                int distance = random.Next(1, 1500);
                int rating = random.Next(1, 5);

                places.Add(new Place(25, 10, 100)
                {
                    Id = i,
                    ParentId = 1,
                    ImagePath = imagePath,
                    Title = title,
                    Rating = rating,
                    Distance = distance,
                    //Title = name + " " + i, 
                    Subtitle = name + " sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title" + i,
                    Content = name + " desc  desc  desc  desc  desc  desc  desc  desc  desc  desc desc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  desc" + i,
                    Parent = parentPlaceType,
                   // NumberOfPeopleGoing = 25,  //TODO: Not sure whether to load counts here or not? Think I will, dont think I should load the entire collection though...
                    //NumberOfPeopleInTheArea = 100,
                    //NumberOfPeopleThere = 10,
                    NextEvent = new Event{ Name =  "Dave's Aawesome Event!", Start = DateTime.Now, End = DateTime.Now.AddHours(3)} //TODO: Same as counts, think may load this up-front, will see... (but not ALL of the events, just the next one)
                });


            }

            return places;
        }

        public bool UpdatePlaceDetails(IPlace place)
        {
            throw new NotImplementedException();
        }

        public bool RatePlace(int placeId, int rating)
        {
            throw new NotImplementedException();
        }


        public PlaceType GetPlaceType(string type)
        {
            PlaceTypes placeType = (PlaceTypes)Enum.Parse(typeof(PlaceTypes), type);
            PlaceCat placeCat = PlaceCat.All;
            string imagePath = string.Empty;

            switch (placeType)
            {
                case PlaceTypes.Yoga:
                case PlaceTypes.TaiChi:
                case PlaceTypes.MeditationCentre:
                case PlaceTypes.LoveBeaming:
                case PlaceTypes.LightWorkers:
                case PlaceTypes.Healing:
                case PlaceTypes.GuidedMeditation:
                case PlaceTypes.EstaticDance:
                case PlaceTypes.EchartTolleGroups:
                case PlaceTypes.Angelic:
                    placeCat = PlaceCat.Spirituality;
                    break;

                case PlaceTypes.Beach:
                case PlaceTypes.Cliff:
                case PlaceTypes.Coast:
                case PlaceTypes.CoastalWalk:
                case PlaceTypes.Fields:
                case PlaceTypes.Forest:
                case PlaceTypes.OpenArea:
                case PlaceTypes.Park:
                case PlaceTypes.River:
                case PlaceTypes.Stream:
                case PlaceTypes.Woods:
                    placeCat = PlaceCat.Nature;
                    break;

                default:
                    placeCat = PlaceCat.All;
                    break;

            }

            switch (_imageCounter)
            {
                case 0:
                    imagePath = "Assets/LightGray.png";
                    break;

                case 1:
                    imagePath = "Assets/NormalGray.png";
                    break;

                case 2:
                    imagePath = "Assets/DarkGray.png";
                    break;
            }

            _imageCounter++;

            if (_imageCounter == 3)
                _imageCounter = 0;

            return new PlaceType
            {
                Id = 1,
                Title = type,
                Content = type + " desc",
                Subtitle = type + " sub title",
                ImagePath = imagePath,
                CatType = placeCat,
                PlacesType = (PlaceTypes)Enum.Parse(typeof(PlaceTypes), type),
                Places = (IList<IPlace>)GenerateMockDataForPlace(type, 10)
            };

            /*
            switch (type)
            {
                case "yoga":
                    {
                        return new PlaceType
                        {
                            Id = 1,
                            Name = type,
                            Description = type + " desc",
                            Places = GenerateMockDataForPlace(type, 10)
                        };
                    }

                case "mediatation":
                    {
                        return new PlaceType
                        {
                            Id = 1,
                            Name = type,
                            Description = type + " desc",
                            Places = GenerateMockDataForPlace(type, 10)
                        };
                    }
            }*/
        }


        public IPlace GetPlace(long id)
        {

            return _lastPlace;
            /*
            return new Place
                {
                    Id = 0,
                    ParentId = 1,
                    ImagePath = "Assets/LightGray.png",
                    Title = "yoga 0",
                    Subtitle = "yoga sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title0",
                    Content = "yoga desc  desc  desc  desc  desc  desc  desc  desc  desc  desc desc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  desc0",
                };*/
        }

        /*
        public Task<IPlace> GetPlace(long id)
        {
            return new Task<IPlace>(() => { return new Place { Title = "Daves med camp" }; });
        }
        */

        IPlaceType IBeMindfulDataSource.GetPlaceType(long placeTypeId)
        {
            PlaceType placeType = new PlaceType()
            {
                ImagePath = "Assets/LightGray.png",
                Title = "Yoga",
                Subtitle = "Yoga desc",
                Id = 1,
                Places = (IList<IPlace>)GenerateMockDataForPlace("Yoga", 10)
                //TODO: Best to lazy load these...
            };

            _lastPlace = placeType.Places[3];
            return placeType;

            /*
            //TODO: Will actually load the place type from service/db here...
            return new PlaceType()
                            {
                                ImagePath = "Assets/LightGray.png",
                                Title = "Yoga",
                                Subtitle = "Yoga desc",
                                Id = 1,
                                Places = (IList<IPlace>)GenerateMockDataForPlace("Yoga", 10)
                                //TODO: Best to lazy load these...
                            };*/
        }


        IList<IPlaceType> IBeMindfulDataSource.GetPlaceTypesForCat(PlaceCat cat)
        {
            switch (cat)
            {
                case PlaceCat.Spirituality:
                    {
                        return new List<IPlaceType>()
                        {
                            new PlaceType()
                            {
                                 ImagePath = "Assets/LightGray.png",
                                 Title = "Yoga",
                                 Subtitle = "Yoga desc",
                                 Id = 1,
                                 //Places = (IList<IPlace>)GenerateMockDataForPlace("Yoga", 10)
                                 //TODO: Best to lazy load these...
                            },
                            new PlaceType()
                            {
                                ImagePath = "Assets/NormalGray.png",
                                 Title = "tai chi",
                                 Subtitle = "tai chi",
                                 Id = 1,
                                 //Places = (IList<IPlace>)GenerateMockDataForPlace("tai chi", 10)
                            },

                            new PlaceType()
                            {
                                ImagePath = "Assets/DarkGray.png",
                                 Title = "Mediations",
                                 Subtitle = "Mediations",
                                 Id = 1,
                                 //Places = (IList<IPlace>)GenerateMockDataForPlace("Mediations", 10)
                            }
                        };
                    }

                case PlaceCat.Nature:
                    {
                        return new List<IPlaceType>();
                    }

                default:
                    return new List<IPlaceType>();
            }

        }
    }
}
