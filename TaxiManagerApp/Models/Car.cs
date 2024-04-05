using Models.Enums;

namespace Models
{
    public class Car : BaseEntity
    {
        public string LicencePlate { get; set; }
        public DateTime LicencePlateExpiryDate { get; set; }
        public string Model { get; set; }
        public Dictionary<ShiftEnum, Driver> Drivers { get; set; }
        public ValidityStatusEnum LicencePlateStatus
        {
            get
            {

                if (LicencePlateExpiryDate == new DateTime()) return ValidityStatusEnum.Red;
                else if (LicencePlateExpiryDate < DateTime.Today) return ValidityStatusEnum.Red;
                else if (LicencePlateExpiryDate > DateTime.Today && LicencePlateExpiryDate <= DateTime.Today.AddMonths(3)) return ValidityStatusEnum.Yellow;
                else if (LicencePlateExpiryDate > DateTime.Today.AddMonths(3)) return ValidityStatusEnum.Green;
                else return ValidityStatusEnum.Red;
            }
        }

        public Car(int id, string licencePlate, DateTime licencePlateExpiryDate, string model) : base(id)
        {
            LicencePlate = licencePlate;
            LicencePlateExpiryDate = licencePlateExpiryDate;
            Model = model;
            Drivers = new Dictionary<ShiftEnum, Driver>();
        }

        public void ExtendLicencePlateExpiryDate()
        {
            LicencePlateExpiryDate = LicencePlateExpiryDate.AddMonths(6);
        }
    }
}
