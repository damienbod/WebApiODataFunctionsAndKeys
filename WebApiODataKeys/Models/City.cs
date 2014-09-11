using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebAPIODataKeys.Models
{
	[DataContract(Name = "City")]
	public class City
	{
		[DataMember]
		[Key]
		public int Id { get; set; }

		[DataMember]
		public long Population { get; set; }

		[DataMember]
		public string Country { get; set; }
	}
}