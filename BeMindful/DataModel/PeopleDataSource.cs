using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextGenSoftware.BeMindful.Models;
using NextGenSoftware.BeMindful.Models.Core;
using System.Collections.ObjectModel;
using BeMindful.ViewModels;

namespace BeMindful
{
    public static partial class DataSource
    {
        public static class People
        {
            public static IPersonDetail GetPersonDetails(long personId, bool refresh = false)
            {
                return StorageProvider.GetPersonDetails(personId);
                //GetItemFromList(placeId, CacheType.PlaceDetails, //TODO: Need to hook into my cached generic place.
            }


            public static IList<IPerson> GetPeopleForPersonType(PersonType personType = PersonType.All, PeopleSortBy sortBy = PeopleSortBy.FullName, SortDir sortDir = SortDir.Ascending, bool refresh = false)
            {
                LastSortBy = (int)sortBy;
                LastSortDir = sortDir;
                IList<IPerson> people = null;

                //if (_allPeople == null || refresh)
                //if (_peopleDataCache == null || refresh)

                //TODO: May somehow also associate the last query with the method name so can compare with this (but only if needed...)
                if (GetCache(CacheType.LastPeopleQuery) == null || refresh)
                {
                    people = StorageProvider.GetAllPeopleForType(personType);

                    if (personType == PersonType.All)
                        SetCache(CacheType.AllPeople, people);
                }

                switch (sortBy)
                {
                    case PeopleSortBy.FirstName:
                        people = sortDir == SortDir.Ascending ? people.OrderBy(x => x.FirstName).ToList() : people.OrderByDescending(x => x.FirstName).ToList();
                        break;

                    case PeopleSortBy.LastName:
                        people = sortDir == SortDir.Ascending ? people.OrderBy(x => x.LastName).ToList() : people.OrderByDescending(x => x.LastName).ToList();
                        break;

                    case PeopleSortBy.FullName:
                        people = sortDir == SortDir.Ascending ? people.OrderBy(x => x.FullName).ToList() : people.OrderByDescending(x => x.FullName).ToList();
                        break;
                }

                //return GetPeople(_peopleDataCache);
                return people;
            }


            //TODO: Do we want to cache these 3?
            public static IList<IPerson> GetPeopleAtPlace(IPlace place, bool refresh = false)
            {
                IList<IPerson> people = refresh == false ? GetCache(CacheType.PeopleAtPlace) : null;

                if (people == null || refresh)
                {
                    people = StorageProvider.GetPeopleAtPlace(place);
                    SetCache(CacheType.PeopleAtPlace, people);
                }

                return people;
            }

            public static IList<IPerson> GetPeopleGoingPlace(IPlace place, bool refresh = false)
            {
                IList<IPerson> people = refresh == false ? GetCache(CacheType.PeopleGoingPlace) : null;

                if (people == null || refresh)
                {
                    people = StorageProvider.GetPeopleGoingPlace(place);
                    SetCache(CacheType.PeopleGoingPlace, people);
                }

                return people;
            }

            public static IList<IPerson> GetPeopleNearPlace(IPlace place, bool refresh = false)
            {
                IList<IPerson> people = refresh == false ? GetCache(CacheType.PeopleNearPlace) : null;

                if (people == null || refresh)
                {
                    people = StorageProvider.GetPeopleNearPlace(place);
                    SetCache(CacheType.PeopleNearPlace, people);
                }

                return people;
            }

            //TODO: Not sure wheher it woukld be more efficient to load ALL of the place details (people, events, history, etc) in one go or have multiple hits?
            //YES LOAD ALL IN ONE GO. WHEN THEY SELECT AN ITEM IN THE SPLITVIEW PAGE/LIST IT WILL ASYNC LOAD THE DETAILS IN THE BACKGROUND SO WHEN THEY THEN WANT TO VIEW MORE DETAIL
            //EVERYTHING WILL ALREADY BE LOADED. THE QUESTION THEN IS DO WE WANT TO THEN THROW THAT AWAY AND LOAD THE NEXT ITEM DETAILS WHEN THEY CHOOSE ANOTHER ITEM IN THE SPLITVIEW LIST?
            //OR DO WE CACHE A CERTAIN NUMBER BEFORE RECYCLING? THE USUAL MEMORY VS PERFORMANCE... Maybe can detect the amount of free ram on that device? Need to look at how memory and resource management
            //works in win8 and for WP8 (seperate). Apps may only be allowed a certain quota?
            /*
            public static IList<IEvent> GetEventsForPlace(IPlace place, bool refresh = false)
            {
                IList<IEvent> events = refresh == false ? GetCache(CacheType.EventsForPlace) : null;

                if (events == null || refresh)
                {
                    events = StorageProvider.GetEventsForPlace(place);
                    SetCache(CacheType.EventsForPlace, events);
                }

                return events;
            }
            */


            public static ObservableCollection<GroupInfoList<object>> GetPeopleGroupedBy(PersonType personType = PersonType.All, PeopleSortBy sortBy = PeopleSortBy.FullName, SortDir sortDir = SortDir.Ascending, bool refresh = false)
            {
                ObservableCollection<GroupInfoList<object>> groups = new ObservableCollection<GroupInfoList<object>>();
                dynamic items = null;
                IList<IPerson> people = null;

                LastSortBy = (int)sortBy;
                LastSortDir = sortDir;

                //TODO: May make this call the other people query above (but just returns a sorted list and does not group, hope you can order before you group...)
                if (GetCache(CacheType.AllPeople) == null || refresh)
                {
                    people = StorageProvider.GetAllPeopleForType(personType);

                    if (personType == PersonType.All)
                        SetCache(CacheType.AllPeople, people);
                }
                else
                {
                    //if (_allPeople == null)
                    //TODO: What if _allPeople is null?  

                    //filter by cat
                    IQueryable<IPerson> peopleQuery = personType == PersonType.All ? people.AsQueryable() : people.Where(x => x.PersonType == personType).AsQueryable();

                    //and then by type.
                    // _peopleDataCache = type == SearchForPeople.All ? peopleQuery.ToList() : peopleQuery.Where(x => x.PlacesType == type).ToList();
                }



                switch (sortBy)
                {
                    case PeopleSortBy.FirstName:
                        {
                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in people
                                            orderby ((IPerson)item).FirstName
                                            group item by ((IPerson)item).FirstName[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in people
                                            orderby ((IPerson)item).FirstName descending
                                            group item by ((IPerson)item).FirstName[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;
                            }
                        } break;

                    case PeopleSortBy.LastName:
                        {
                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in people
                                            orderby ((IPerson)item).LastName
                                            group item by ((IPerson)item).LastName[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in people
                                            orderby ((IPerson)item).LastName descending
                                            group item by ((IPerson)item).LastName[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                            }

                        } break;

                    case PeopleSortBy.FullName:
                        {
                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    {
                                        items = from item in people
                                                orderby ((IPerson)item).FullName
                                                group item by ((IPerson)item).FullName[0] into g
                                                select new { GroupName = g.Key, Items = g };
                                    } break;

                                case SortDir.Descending:
                                    items = from item in people
                                            orderby ((IPerson)item).FullName descending
                                            group item by ((IPerson)item).FullName[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                            }

                        } break;

                }


                //TODO: May pass in a func delegate for the Collection source data.
                //TODO: needs predicate badly!!!! Like we did in CRC, need to check how to do this!!

                if (items != null)
                {
                    foreach (var g in items)
                    {
                        GroupInfoList<object> info = new GroupInfoList<object>();
                        info.Key = g.GroupName;

                        foreach (var item in g.Items)
                            //info.Add(new PersonViewModel(item)); 
                            info.Add(item);

                        groups.Add(info);
                    }
                }

                return groups;
            }





            /*
            private static IList<PersonViewModel> GetPeople(IList<IPerson> people)
            {
                List<PersonViewModel> peopleVm = new List<PersonViewModel>();

                foreach (Person person in people)
                    peopleVm.Add(new PersonViewModel(person));

                return peopleVm;
            }*/
        

        }   

    }
}
