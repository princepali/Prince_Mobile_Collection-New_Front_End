using PrinceApi.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace PrinceApi.Models.SiteUser
{
    public class SiteUserModel : BaseModel
    {
        [Key]
        public Guid UserId { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? UserName { get; set; }

        [MaxLength(50)]
        public string? Password { get; set; }

        public int Age { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(50)]
        public string? State { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(20)]
        public string? Mobile { get; set; }

        [MaxLength(50)]
        public string? Address1 { get; set; }

        [MaxLength(50)]
        public string? Address2 { get; set; }

        [MaxLength(250)]
        public string? Picture { get; set; }

        public DateTime? LastLogin { get; set; }

        [MaxLength(250)]
        public string? Notes { get; set; }

        public Guid? DomainId { get; set; }

        public Guid? OrganizationId { get; set; }
    }
}
