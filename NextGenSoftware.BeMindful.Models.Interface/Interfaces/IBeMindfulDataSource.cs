using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenSoftware.BeMindful.Models.Core
{
    public interface IBeMindfulDataSource
    {
        IList<IPlace> GetAllPlaces(); //gets every place in the db suh as yoga1, yoga2, park 1, park2, etc,

        IList<IPlaceType> GetPlaceTypesForCat(PlaceCat cat); //gets the different place types for this cat so for PlacesToPracticeSpirituality it will list yoga, taichi, etc

        IList<IPlaceType> GetAllPlaceTypes(); //gets ALL the different place types such list yoga, taichi, rivers, etc. etc

        IList<IPlace> GetAllPlacesForCat(PlaceCat cat); //gets ALL of the actual places for this cat so for PlacesToPracticeSpirituality it will list yoga 1, yoga 2, yoga 3, tai hi 1, tai chi 2, etc

        IList<IPlace> GetAllPlacesForCatAndType(PlaceCat cat, PlaceTypes placeType);

        IList<IPerson> GetAllPeopleForType(PersonType personType);

        IList<IPerson> GetPeopleAtPlace(IPlace place);

        IList<IPerson> GetPeopleGoingPlace(IPlace place);

        IList<IPerson> GetPeopleNearPlace(IPlace place);

        IPlace GetPlacePersonIsAt(IPerson person);

        IList<IPlace> GetPlacesPersonIsGoing(IPerson person);

        IList<IPlace> GetPlacesPersonIsNear(IPerson person);
      

        IList<IPlaceType> GetAllPlaceTypesForCatAndType(PlaceCat cat, PlaceTypes type);

        //TODO: May remove this one.
        IList<IPlace> GetPlacesForType(string type); //gets ALL of the actual places for this type so for Yoga it will list yoga 1, yoga 2, yoga 3, etc.

        IPlaceType GetPlaceType(long placeTypeId); //gets the actual place type (such as yoga) along with all is places children pre-loaded.

        //IPlace GetPlace(long id);
        //Task<IPlace> GetPlace(long id);
        IPlace GetPlace(long id);

        bool UpdatePlaceDetails(IPlace place);

        bool RatePlace(int placeId, int rating);

        IPlaceDetail GetPlaceDetails(long placeId);

        IPersonDetail GetPersonDetails(long personId);
    }
}
