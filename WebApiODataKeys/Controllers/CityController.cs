using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using WebAPIODataKeys.Models;

namespace WebApiODataKeys.Controllers
{
	public class CityController : ODataController
    {
		public IHttpActionResult Get()
		{
			return Ok(new List<City> { new City { Population = 2300000, Country = "Switzerland", Id=1} });
		}

		public IHttpActionResult Get(int key)
		{
			return Ok(new City { Population = 9000000, Country = "Berlin", Id = key  });
		}

		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute("City({key})/D.GetStadiumsFromCityWithFunction()")]
		[HttpGet]
		public IHttpActionResult GetStadiumsFromCityWithFunction(int key)
		{
			return Ok(new List<Stadium> { new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "FC Zug" } });
		}

    }
}
