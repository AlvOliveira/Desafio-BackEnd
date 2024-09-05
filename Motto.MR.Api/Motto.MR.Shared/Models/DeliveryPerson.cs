using System.ComponentModel.DataAnnotations.Schema;

namespace Motto.MR.Shared.Models
{
    public class DeliveryPerson
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DriverLicenseType { get; set; }
        public string DriverLicenseImagePath { get; private set; }
        
        [NotMapped]
        public string DriverLicenseImageBase64 { get; set; }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetDriverLicenseImagePath(string path)
        {
            DriverLicenseImagePath = path;
        }
    }
}
