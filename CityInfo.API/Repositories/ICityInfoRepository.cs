using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Repositories
{
    public interface ICityInfoRepository
    {
//        IQueryable<CityEntity> GetCities();
        IEnumerable<CityEntity> GetCities();
        CityEntity GetCity(int cityId, bool includePointsOfInterest);
        IEnumerable<PointOfInterestEntity> GetPointsOfInterest(int cityId);
        PointOfInterestEntity GetPointOfInterest(int cityId, int pointOfInterestId);
    }
}