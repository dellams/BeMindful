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
    public class GroupInfoList<T> : List<object>
    {
        public object Key { get; set; }

        public new IEnumerator<object> GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
        }
    }

    public enum CacheToClear
    {
        All,
        Places,
        People
    }

    public enum ObjetType
    {
        None,
        Place,
        Person,
        Unknown
    }

    public enum CacheType
    {
        AllPlaceTypes,
        AllPeople,
        LastPlaceTypesQuery,
        LastPlaceTypeQuery,
        LastPeopleQuery,
        PeopleAtPlace,
        PeopleGoingPlace,
        PeopleNearPlace,
        PlacePersonIsAt,
        PlacesPersonIsGoingTo,
        EventsForPlace,
        PlaceDetails //TODO: 1 record at a time or multiple? Think multiple but needs to be managed somehow (need to check resource and memory management for win 8 apps)
        //EventsForPeople
    }

    // public static partial class DataSource<TBeMindfulDataSource>
    //where TBeMindfulDataSource : IBeMindfulDataSource, new()
     public static partial class DataSource
    {
        private static IBeMindfulDataSource _storageProvider;
        private static IBaseModel _selectedItem;
        private static Dictionary<string, dynamic> _cache;
        public static int LastSortBy { get; set; }
        public static SortDir LastSortDir { get; set; }

        public static Dictionary<string, dynamic> Cache
        {
            get
            {
                if (_cache == null)
                    _cache = new Dictionary<string, dynamic>();

                return _cache;
            }
        }

        // Normally this will be used when invoking methods to use the current provider,
        // but a new type can be passed in if required.
        /*
         public static Type CurrentStorageProvider
        {
            get
            {
                return typeof(TBeMindfulDataSource);
            }
        }   */

        public static IBaseModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }



        public static ObjetType SelectedItemType
        {
            get
            {
                if (_selectedItem != null)
                {
                    if (_selectedItem is IPlace)
                        return ObjetType.Place;

                    else if (_selectedItem is IPerson)
                        return ObjetType.Person;

                    else
                        return ObjetType.Unknown;
                }

                return ObjetType.None;
            }
        }


        public static IBeMindfulDataSource StorageProvider
        {
            get
            {
                return _storageProvider;
                /*
                // if the intance is null then create a new instance.
                // or if a new provider has been passed in and the instance is off a different type, we need to create a new instance of that type
                if (_instance == null || (_instance != null && _instance.GetType() != typeof(TBeMindfulDataSource)))
                {
                    _cache = new Dictionary<string, dynamic>();
                    _instance = new TBeMindfulDataSource();
                }

                return _instance;
                */
            }
            set
            {
                _storageProvider = value;
                _cache = new Dictionary<string, dynamic>(); //TODO: Not sure whether we want to clear the cache or not?
            }
        }

        private static dynamic GetCache(CacheType cacheType)
        {
            return Cache.ContainsKey(Enum.GetName(typeof(CacheType), cacheType)) ? 
                Cache[Enum.GetName(typeof(CacheType), cacheType)]
                : null;
            /*
            //TODO: I'm pretty sure this will break if they key does not exist...
            if (Cache.ContainsKey(Enum.GetName(typeof(CacheType), cacheType)))
                return Cache[Enum.GetName(typeof(CacheType), cacheType)];
            else
                return null;*/
        }

        private static void SetCache(CacheType cacheType, dynamic value)
        {
            Cache[Enum.GetName(typeof(CacheType), cacheType)] = value;
        }
      
        public static void ClearCache(CacheToClear cacheToClear)
        {
            switch (cacheToClear)
            {
                case CacheToClear.All:
                    _cache = null;
                    break;

                case CacheToClear.People:
                    //Cache["LastPeopleQuery"] = null; //TODO: Want to also clear AllPeople?
                    SetCache(CacheType.LastPeopleQuery, null);
                    break;

                case CacheToClear.Places:
                    //Cache["LastPlacesQuery"] = null; //TODO: Want to also clear AllPeople?
                    SetCache(CacheType.LastPlaceTypesQuery, null);
                    break;
            }
        }


        public static dynamic GetItemFromList(long itemId, CacheType cacheType, Func<long, dynamic> storageCall, bool refresh = false)
        {
            List<dynamic> items = refresh == false ? GetCache(cacheType) : null;
            dynamic item = items != null ? items.FirstOrDefault(x => x.Id == itemId) : null;

            if (item == null || refresh)
            {
                item = storageCall(itemId);

                if (item != null)
                {
                    if (items == null)
                        items = new List<dynamic> { item };
                    else
                    {
                        dynamic oldItem = (dynamic)items.FirstOrDefault(x => x.Id == item.Id);

                        // First remove the old version if there is one...
                        if (oldItem != null)
                            items.Remove(oldItem);

                        items.Add(item);
                    }
                }

                SetCache(cacheType, items);
            }

            return item;
        }

    }
}
