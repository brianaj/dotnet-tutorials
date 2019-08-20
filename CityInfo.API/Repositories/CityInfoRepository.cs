using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Repositories
{
    public class CityInfoRepository: ICityInfoRepository
    {
        public CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }
        public IEnumerable<CityEntity> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public CityEntity GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities
                    .Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
            }

            return _context.Cities.FirstOrDefault(c => c.Id == cityId);

        }

        public IEnumerable<PointOfInterestEntity> GetPointsOfInterest(int cityId)
        {
            throw new System.NotImplementedException();
        }

        public PointOfInterestEntity GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.FirstOrDefault(p => p.City.Id == cityId && p.Id == pointOfInterestId);
        }
    }
}