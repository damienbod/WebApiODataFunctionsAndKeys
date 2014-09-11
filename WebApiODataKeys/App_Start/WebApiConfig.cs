using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using WebAPIODataKeys.Models;

namespace WebApiODataKeys
{
	public static class WebApiConfig
	{

		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.MapODataServiceRoute(
				routeName: "odataRoute",
				routePrefix: "odata",
				model: GetModel());
		
		}

		public static IEdmModel GetModel()
		{
			ODataModelBuilder builder = new ODataConventionModelBuilder();
			builder.Namespace = "D";
			builder.ContainerName = "Default";

			EntitySetConfiguration<City> cities = builder.EntitySet<City>("City");
			EntitySetConfiguration<Stadium> stadiums = builder.EntitySet<Stadium>("Stadium");

			// Per Collection Stadium
			FunctionConfiguration getStadiumsWithFunction = stadiums.EntityType.Collection.Function("GetStadiumsWithFunction");
			getStadiumsWithFunction.ReturnsCollectionFromEntitySet<Stadium>("Stadium");

			//  Per Collection Stadium, returns single entity
			FunctionConfiguration getStadiumsTest = stadiums.EntityType.Collection.Function("GetStadiumTest");
			getStadiumsTest.Parameter<string>("test");
			getStadiumsTest.Parameter<string>("name");
			getStadiumsTest.ReturnsFromEntitySet<Stadium>("Stadium");

			// Per Entity (Single key property) City
			FunctionConfiguration getStadiumFromCityWithFunction = cities.EntityType.Function("GetStadiumsFromCityWithFunction");
			getStadiumFromCityWithFunction.ReturnsCollectionFromEntitySet<Stadium>("Stadium");

			// Global Function
			builder.Function("GlobalFunction").ReturnsCollectionFromEntitySet<Stadium>("Stadium");

			// TODO Per Entity composite key
			
			return builder.GetEdmModel();
		}
	}
}
