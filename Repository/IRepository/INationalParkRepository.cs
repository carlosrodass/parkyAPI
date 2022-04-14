using System.Collections.Generic;
using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;

namespace ParkyApi.Repository
{
    public interface INationalParkRepository
    {
        IEnumerable<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int nationalParkId);
        bool NationalParkExist(string name);
        bool NationalParkExists(int id);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();
    }
}
