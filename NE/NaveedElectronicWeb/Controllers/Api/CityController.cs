using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NaveedElectronicWeb.NEModel;

namespace NaveedElectronicWeb.Controllers.Api
{
    public class CityController : ApiController
    {
        NEDataBaseEntities Db = new NEDataBaseEntities();


        // GET: api/City
        public IEnumerable<City> Get()
        {
            var data = Db.Cities.OrderBy(c => c.CityName);

            List<City> cities = new List<City>();

            foreach(var city in data)
            {
                cities.Add(new City()
                {
                    Id= city.Id,
                    CityName = city.CityName
                });
            }


            return cities;
        }

        // GET: api/City/5
        public string Get(int id)
        {
            return "value";
        }

      
        public void Post(City city)
        {
            City _city = Db.Cities.Where(c => c.CityName.ToLower() == city.CityName.ToLower()).FirstOrDefault();

            if(_city==null)
            {
                City cityIDb = new City();
                cityIDb.CityName = city.CityName;
                Db.Cities.Add(cityIDb);
                Db.SaveChanges();
            }
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
