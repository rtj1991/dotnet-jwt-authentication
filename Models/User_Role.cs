using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProductAPI.Models
{
    public partial class User_Role
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? Users { get; set; }

        public int RoleId { get; set; }
        [JsonIgnore]
        public Role? Roles { get; set; }


    }
}
