using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models.Core;
using Windows.UI.Xaml.Media.Imaging;

namespace NextGenSoftware.BeMindful.Models
{

    public partial class MockBeMindfulDataSource : IBeMindfulDataSource
    {
      //  public struct People
      //  {

        public IPersonDetail GetPersonDetails(long placeId)
        {
            return new PersonDetail
            {
                FirstName = "David",
                LastName = "Ellams",
                //PersonIsAt = new Place(25, 10, 100)   //TODO: Not sure whether to load counts here or not? Think I will, dont think I should load the entire collection though...
                PersonIsAt = new Place(25, 10, 100)   //TODO: Not sure whether to load counts here or not? Think I will, dont think I should load the entire collection though...
                {
                    Id = 1,
                    ParentId = 1,
                    ImagePath = "Assets/LightGray.png",
                    Title = "Mr",
                    Rating = 5,
                    Distance = 10,
                    //Title = name + " " + i, 
                    Subtitle = "David sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title sub title",
                    Content = "David desc  desc  desc  desc  desc  desc  desc  desc  desc  desc desc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  descdesc  desc  desc  desc  desc  desc  desc  desc  desc  desc",
                    Parent = new PlaceType(),
                    NextEvent = new Event{ Name =  "Dave's Aawesome Event!", Start = DateTime.Now, End = DateTime.Now.AddHours(3)} //TODO: Same as counts, think may load this up-front, will see... (but not ALL of the events, just the next one)
                },
                About = "blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah blah ",
                CreatedBy = 0,
                CreatedOn = DateTime.Now,
                Distance = 100,
                PlacesPersonIsGoingTo = GetPlacesPersonIsGoing(null),
                EventsPersonHasBeenTo = new List<IEvent>
                 {
                      new Event{ Name =  "Dave's Aawesome Event!", Start = DateTime.Now, End = DateTime.Now.AddHours(3)}, 
                      new Event{ Name =  "Dave's 2nd Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 3rd Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 4th Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                      new Event{ Name =  "Dave's 5th Aawesome Event!", Start = DateTime.Now.AddDays(-7), End = DateTime.Now.AddDays(-7).AddHours(3)}, 
                 },
                PlacesInTheArea = GetPlacesPersonIsNear(null), 
                PersonType = Core.PersonType.All,
                PeopleInTheArea = GetPeopleAtPlace(null),
                Rating = 5,
                ImagePath = "Assets/LightGray.png",
                Pictures = new List<Windows.UI.Xaml.Media.ImageSource>
                {
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/LightGray.png")),
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/MediumGray.png")),
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/DarkGray.png")),
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/LightGray.png")),
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/MediumGray.png")),
                    new BitmapImage(new Uri(BaseModel.BaseUri, "Assets/DarkGray.png"))
                }
            };
        }


            public IList<IPerson> GetAllPeopleForType(PersonType personType)
            {
                Random random = new Random();
                int distance = random.Next(1, 1500);

                switch (personType)
                {
                    case PersonType.All:
                        {
                            return new List<IPerson>
                        {
                            new Person
                            {
                                 FirstName = "David",
                                 LastName = "Ellams",
                                 PersonType = PersonType.All,
                                 Id = 1,
                                 Distance = distance,
                                 Rating = 10,
                                 About = "David The WayShower..."
                            },
                            new Person
                            {
                                 FirstName = "James",
                                 LastName = "Ellams",
                                 PersonType = PersonType.All,
                                 Id = 2,
                                 Distance = distance,
                                 Rating = 8,
                                 About = "James Ellams is David Ellams younger brother who he loves very much!"
                            },
                            new Person
                            {
                                 FirstName = "Bob",
                                 LastName = "Jones",
                                 PersonType = PersonType.All,
                                 Id = 3,
                                 Distance = distance,
                                 Rating = 5,
                                 About = "Good old bobby boy!"
                            }
                        };
                        } break;

                    case PersonType.FriendsOnly:
                        {
                            return new List<IPerson>
                        {
                            new Person
                            {
                                 FirstName = "David",
                                 LastName = "Ellams",
                                 PersonType = PersonType.All,
                                 Id = 1,
                                 Distance = distance,
                                 Rating = 10
                            },
                            new Person
                            {
                                 FirstName = "James",
                                 LastName = "Ellams",
                                 PersonType = PersonType.All,
                                 Id = 2,
                                 Distance = distance,
                                 Rating = 8
                            }
                        };
                        } break;

                    default:
                        return new List<IPerson>();

                }
            }

            public IList<IPerson> GetPeopleNearPlace(IPlace place)
            {
                return GetPeople(place, 100);
            }

            public IList<IPerson> GetPeopleGoingPlace(IPlace place)
            {
                return GetPeople(place, 50);
            }


            public IList<IPerson> GetPeople(IPlace place, int number)
            {
                List<IPerson> people = new List<IPerson>();
                Random random = new Random();
                int distance = 9;

                for (int i = 0; i < 50; i++)
                {
                    distance = random.Next(1, 1500);
                    people.Add(new Person
                    {
                        FirstName = "David Long" + i.ToString(),
                        LastName = "Ellams Long Name Test",
                        PersonType = PersonType.All,
                        Id = 1,
                        Distance = distance,
                        Rating = 10,
                        About = "David The WayShower..."
                    });
                }

                return people;

            }


            public IList<IPerson> GetPeopleAtPlace(IPlace place)
            {
                return GetPeople(place, 20);


                /*
                return new List<IPerson>
                {
                    new Person
                    {
                            FirstName = "David",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 1,
                            Distance = distance,
                            Rating = 10,
                            About = "David The WayShower..."
                    },
                    new Person
                    {
                            FirstName = "James",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 2,
                            Distance = distance,
                            Rating = 8,
                            About = "James Ellams is David Ellams younger brother who he loves very much!"
                    },
                    new Person
                    {
                            FirstName = "Bob",
                            LastName = "Jones",
                            PersonType = PersonType.All,
                            Id = 3,
                            Distance = distance,
                            Rating = 5,
                            About = "Good old bobby boy!"
                    },
                    new Person
                    {
                            FirstName = "David",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 1,
                            Distance = distance,
                            Rating = 10,
                            About = "David The WayShower..."
                    },
                    new Person
                    {
                            FirstName = "James",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 2,
                            Distance = distance,
                            Rating = 8,
                            About = "James Ellams is David Ellams younger brother who he loves very much!"
                    },
                    new Person
                    {
                            FirstName = "Bob",
                            LastName = "Jones",
                            PersonType = PersonType.All,
                            Id = 3,
                            Distance = distance,
                            Rating = 5,
                            About = "Good old bobby boy!"
                    },
                    new Person
                    {
                            FirstName = "David",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 1,
                            Distance = distance,
                            Rating = 10,
                            About = "David The WayShower..."
                    },
                    new Person
                    {
                            FirstName = "James",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 2,
                            Distance = distance,
                            Rating = 8,
                            About = "James Ellams is David Ellams younger brother who he loves very much!"
                    },
                    new Person
                    {
                            FirstName = "Bob",
                            LastName = "Jones",
                            PersonType = PersonType.All,
                            Id = 3,
                            Distance = distance,
                            Rating = 5,
                            About = "Good old bobby boy!"
                    },
                    new Person
                    {
                            FirstName = "James",
                            LastName = "Ellams",
                            PersonType = PersonType.All,
                            Id = 2,
                            Distance = distance,
                            Rating = 8,
                            About = "James Ellams is David Ellams younger brother who he loves very much!"
                    }
                };*/
            }
      //  }
    }
}
