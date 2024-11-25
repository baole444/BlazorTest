﻿using System.Text.Json.Serialization;

namespace Services.Models
{
    public class GenderModel
    {
        public int? GenderID { get; set; }

        public String? GenderDescription { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmployeeModel>? Employees { get; set; } = new List<EmployeeModel>();
    }
}
