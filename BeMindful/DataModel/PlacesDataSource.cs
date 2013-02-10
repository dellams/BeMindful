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
        public static class Places
        {
            public static IPlaceType GetPlaceType(long id, bool refresh = false)
            {
                IList<IPlaceType> places = GetCache(CacheType.AllPlaceTypes);

                if (places == null || refresh)
                {
                    IPlaceType placeType = StorageProvider.GetPlaceType(id);

                    if (placeType != null)
                    {
                        if (places == null)
                            SetCache(CacheType.AllPlaceTypes, new List<IPlaceType> { placeType });
                        else
                        {
                            IPlaceType oldPlaceType = places.FirstOrDefault(x => x.Id == id);

                            if (oldPlaceType != null)
                                places.Remove(oldPlaceType);

                            places.Add(placeType);
                            SetCache(CacheType.AllPlaceTypes, places);
                        }
                    }
                }

                return places.FirstOrDefault(x => x.Id == id);
            }

            public static IPlace GetPlace(long id, bool refresh = false)
            {
                IPlace returnValue = null;
                IList<IPlaceType> places = GetCache(CacheType.AllPlaceTypes);

                if (places == null || refresh)
                {
                    IPlace place = StorageProvider.GetPlace(id);

                    if (place != null)
                    {
                        if (places == null)
                            places = new List<IPlaceType> { new PlaceType { Places = new List<IPlace> { place } } };
                        else
                        {
                            //TODO: Come back to this...
                            /*
                            IPlaceType oldPlaceType = places.FirstOrDefault(x => x.Id == id);

                            if (oldPlaceType != null)
                                places.Remove(oldPlaceType);

                            places.Add(new PlaceType { Places = new List<IPlace> { place } });
                            */
                        }
                    }
                }



                foreach (IPlaceType placeType in places)
                {
                    returnValue = placeType.Places.FirstOrDefault(x => x.Id == id);

                    if (returnValue != null)
                        break;
                }

                return returnValue;
            }

            public static IPlace GetPlacePersonIsAt(IPerson person, bool refresh = false)
            {
                IPlace place = refresh == false ? GetCache(CacheType.PlacePersonIsAt) : null;

                if (place == null || refresh)
                {
                    place = StorageProvider.GetPlacePersonIsAt(person);
                    SetCache(CacheType.PlacePersonIsAt, place);
                }

                return place;
            }

            public static IList<IPlace> GetPlacesPersonIsGoingTo(IPerson person, bool refresh = false)
            {
                IList<IPlace> places = refresh == false ? GetCache(CacheType.PlacesPersonIsGoingTo) : null;

                if (places == null || refresh)
                {
                    places = StorageProvider.GetPlacesPersonIsGoing(person);
                    SetCache(CacheType.PlacesPersonIsGoingTo, places);
                }

                return places;
            }

            public static IList<IPlace> GetPlacesPersonIsNear(IPerson person, bool refresh = false)
            {
                IList<IPlace> places = refresh == false ? GetCache(CacheType.PlacesPersonIsGoingTo) : null;

                if (places == null || refresh)
                {
                    places = StorageProvider.GetPlacesPersonIsNear(person);
                    SetCache(CacheType.PlacesPersonIsGoingTo, places);
                }

                return places;
            }
            /*
            public static IPlaceDetail GetPlaceDetails(int placeId, bool refresh = false)
            {
                List<IPlaceDetail> places = refresh == false ? GetCache(CacheType.PlaceDetails) : null;
                IPlaceDetail place = places != null ? places.FirstOrDefault(x => x.Id == placeId) : null;

                if (places == null || refresh)
                {
                    place = StorageProvider.GetPlaceDetails(placeId);

                    if (place != null)
                    {
                        if (places == null)
                            places = new List<IPlaceDetail> { place };
                        else
                        {
                            PlaceDetail oldPlace = (PlaceDetail)places.FirstOrDefault(x => x.Id == place.Id);

                            // First remove the old version if there is one...
                            if (oldPlace != null)
                                places.Remove(oldPlace);

                            places.Add(place);
                        }
                    }

                    SetCache(CacheType.EventsForPlace, places);
                }

                return place;
            }*/


            public static IPlaceDetail GetPlaceDetails(long placeId, bool refresh = false)
            {
                return StorageProvider.GetPlaceDetails(placeId);
                //GetItemFromList(placeId, CacheType.PlaceDetails,
            }

            public static ObservableCollection<GroupInfoList<object>> GetPlacesGroupedBy(PlaceCat cat = PlaceCat.All, PlaceTypes type = PlaceTypes.All, PlaceSortBy sortBy = PlaceSortBy.Type, SortDir sortDir = SortDir.Ascending, bool refresh = false)
            {
                ObservableCollection<GroupInfoList<object>> groups = new ObservableCollection<GroupInfoList<object>>();
                List<IPlaceType> placeTypes = new List<IPlaceType>();
                dynamic items = null;

                LastSortBy = (int)sortBy;
                LastSortDir = sortDir;

                //if (_placesDataCache == null || refresh)
                if (GetCache(CacheType.AllPlaceTypes) == null || refresh)
                {
                    placeTypes = (List<IPlaceType>)StorageProvider.GetAllPlaceTypesForCatAndType(cat, type);

                    //TODO: Not sure e=whether to do this here, in the IBeMindfulDataSource or just have a GetPlaceTypeFromType (will cache if it can) method to be used in SplitPage
                    foreach (PlaceType placeType in placeTypes)
                    {
                        foreach (Place place in placeType.Places)
                            place.Parent = placeType;
                    }

                    if (cat == PlaceCat.All)
                        SetCache(CacheType.AllPlaceTypes, placeTypes);
                }
                else
                {
                    IList<IPlaceType> allPlaceTypes = GetCache(CacheType.AllPlaceTypes);

                    //filter by cat
                    IQueryable<IPlaceType> placesQuery = cat == PlaceCat.All ? allPlaceTypes.AsQueryable() : allPlaceTypes.Where(x => x.CatType == cat).AsQueryable();

                    //and then by type.
                    placeTypes = type == PlaceTypes.All ? placesQuery.ToList() : placesQuery.Where(x => x.PlacesType == type).ToList();
                }

                switch (sortBy)
                {
                    case PlaceSortBy.Name:
                        {
                            List<IPlace> places = new List<IPlace>();

                            foreach (IPlaceType Placetype in placeTypes)
                                places.AddRange(Placetype.Places);


                            //places.GroupBy(x => x.Title[0]).OrderBy(x => x.

                            // items = sortDir == SortDir.Ascending ?
                            //    places.OrderBy(x => x.Title) : places.OrderByDescending(x => x.Title).GroupBy(x => x.Title[0]);


                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in places
                                            orderby ((IPlace)item).Title
                                            group item by ((IPlace)item).Title[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in places
                                            orderby ((IPlace)item).Title descending
                                            group item by ((IPlace)item).Title[0] into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;
                            }
                        } break;

                    case PlaceSortBy.Type:
                        {
                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in placeTypes
                                            orderby ((IPlaceType)item).Title
                                            group item by ((IPlaceType)item).Title into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in placeTypes
                                            orderby ((IPlaceType)item).Title descending
                                            group item by ((IPlaceType)item).Title into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;
                            }
                        } break;

                    case PlaceSortBy.Rating:
                        {
                            List<IPlace> places = new List<IPlace>();

                            foreach (IPlaceType Placetype in placeTypes)
                                places.AddRange(Placetype.Places);

                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in places
                                            orderby ((IPlace)item).Rating
                                            group item by ((IPlace)item).Rating into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in places
                                            orderby ((IPlace)item).Rating descending
                                            group item by ((IPlace)item).Rating into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;
                            }
                        } break;

                    case PlaceSortBy.Distance:
                        {
                            List<IPlace> places = new List<IPlace>();

                            foreach (IPlaceType Placetype in placeTypes)
                                places.AddRange(Placetype.Places);

                            switch (sortDir)
                            {
                                case SortDir.Ascending:
                                    items = from item in places
                                            orderby ((IPlace)item).Distance
                                            group item by ((IPlace)item).Distance into g
                                            select new { GroupName = g.Key, Items = g };
                                    break;

                                case SortDir.Descending:
                                    items = from item in places
                                            orderby ((IPlace)item).Distance descending
                                            group item by ((IPlace)item).Distance into g
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
                        {
                            if (item is IPlace)
                                info.Add(item);

                            else if (item is IPlaceType)
                            {
                                foreach (IPlace place in item.Places)
                                    info.Add(place);
                            }
                        }
                        groups.Add(info);
                    }
                }

                return groups;
            }
        }

       

       

    }
}
