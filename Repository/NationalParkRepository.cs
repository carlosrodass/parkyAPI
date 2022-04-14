﻿using System.Collections.Generic;
using System.Linq;
using ParkyApi.Data;
using ParkyApi.Models;
using ParkyApi.Models.Dtos;

namespace ParkyApi.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {

        private readonly ApplicationDbcontext _db;

        public NationalParkRepository(ApplicationDbcontext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();

        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _db.NationalParks.FirstOrDefault(x => x.Id == nationalParkId);

        }

        public IEnumerable<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(x => x.Name).ToList();

        }

        public bool NationalParkExist(string name)
        {
            bool value = _db.NationalParks.Any(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NationalParks.Any(x => x.Id == id);

        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;

        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
