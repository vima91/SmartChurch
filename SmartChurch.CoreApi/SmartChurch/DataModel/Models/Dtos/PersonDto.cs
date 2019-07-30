using System;
using System.ComponentModel.DataAnnotations;
using SmartChurch.DataModel.Models.Core;
using SmartChurch.DataModel.Models.Entities;

namespace SmartChurch.DataModel.Models.Dtos
{
    public class PersonDto : ICommonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ConfessionFatherName { get; set; }

        public int BaptismTypeId { get; set; }
        public virtual BaptismType BaptismType { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Phone]
        public string WhatsappNumber { get; set; }

        //TODO: Check https://github.com/codebude/QRCoder
        public string FacebookLink { get; set; } //As QrCode

        public string Picture { get; set; }
        public string Comments { get; set; }
        public DateTime? Birthday { get; set; }

        public int? GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public string Job { get; set; }

        public int MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }

        public DateTime? MarriageAnniversary { get; set; }
        public string Address { get; set; }
        public string Weekends { get; set; }
        public string Qualifications { get; set; }

        public int ReligiousBackgroundId { get; set; }
        public virtual ReligiousBackground ReligiousBackground { get; set; }

        public int CountryOfResidenceId { get; set; }
        public virtual Country CountryOfResidence { get; set; }

        public int HomeCountryId { get; set; }
        public virtual Country HomeCountry { get; set; }

        public bool IsServant { get; set; }
        public DateTime? LastVisitDate { get; set; }
        public string BaptismCertificationPic { get; set; }
        public string MarriageCertificatePic { get; set; }
        public string SingleStatusCertificatePic { get; set; }

        public int MarriageTypeId { get; set; }
        public virtual MarriageType MarriageType { get; set; }

        public int? LastVisitYearOfMarriageAnniversary { get; set; }
        public int? LastVisitYearOfBirthday { get; set; }
    }
}
