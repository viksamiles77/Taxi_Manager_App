using Models.Enums;

namespace Models
{
    public class Driver : User
    {
        public string DriverLicenceNumber { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public ValidityStatusEnum LicenceStatus
        {
            get
            {
                //if (LicenceExpiryDate == null) return ValidityStatusEnum.Red;
                if (LicenceExpiryDate == new DateTime()) return ValidityStatusEnum.Red;
                else if (LicenceExpiryDate < DateTime.Today) return ValidityStatusEnum.Red;
                else if (LicenceExpiryDate > DateTime.Today && LicenceExpiryDate <= DateTime.Today.AddMonths(3)) return ValidityStatusEnum.Yellow;
                else if (LicenceExpiryDate > DateTime.Today.AddMonths(3)) return ValidityStatusEnum.Green;
                else return ValidityStatusEnum.Red;
            }
        }
        public Driver(int id, string firstName, string lastName, string userName, string password, string driverLicenceNumber
            , DateTime licenceExpiryDate, ValidityStatusEnum licenceStatus)
            : base(id, firstName, lastName, userName, password, RoleEnum.Driver)
        {
            DriverLicenceNumber = driverLicenceNumber;
            LicenceExpiryDate = licenceExpiryDate;
        }

        public void ExtendLicenceExpiryDate(DateTime newExpirationDate)
        {
            LicenceExpiryDate = newExpirationDate;
        }
    }
}
