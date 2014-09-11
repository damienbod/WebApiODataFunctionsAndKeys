using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebAPIODataKeys.Models
{
    [DataContract(Name = "Stadium")]
    public class Stadium
    {
        [DataMember]
		[Key]
        public string Name { get; set; }

        [DataMember]
		[Key]
        public string Country { get; set; }

		[DataMember]
		public int Capacity { get; set; }

		[DataMember]
		public string Owner { get; set; }
    }
}
