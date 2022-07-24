using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserWebApi.Models
{
    public class UserInformation
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName ="nvarchar(20)")]
        public string UserFirstName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserLastName { get; set; }

        [Column(TypeName = "int")]
        public int UserAge { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string UserEmail { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string UserPhone { get; set; }

    }
}
