using Newtonsoft.Json;
using System;

namespace AreaManagement.ViewModel
{
    public class AreaViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("areaName")]
        public string AreaName { get; set; }

        [JsonProperty("createdBy")]
        public int CreatedBy { get; set; }

        [JsonProperty("updatedBy")]
        public int UpdatedBy { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("updatedOn")]
        public DateTimeOffset UpdatedOn { get; set; }
    }
}
