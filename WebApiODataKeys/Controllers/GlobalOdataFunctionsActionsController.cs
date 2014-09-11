using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using WebAPIODataKeys.Models;

namespace WebApiODataKeys.Controllers
{
	public class GlobalOdataFunctionsActionsController : ODataController
    {
		[EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
		[ODataRoute("GlobalFunction()")]
		[HttpGet]
		public IHttpActionResult GlobalFunction()
		{
			return Ok(new List<Stadium>{ new Stadium { Capacity = 2300, Country = "Switzerland", Name = "Times Stadium", Owner = "Global Owner" } });
		}
    }
}
