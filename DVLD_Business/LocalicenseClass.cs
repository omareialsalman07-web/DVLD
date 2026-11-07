using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class LicenseClass
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte ValidityLength { get; set; }
        public float ClassFees { get; set; }

        public LicenseClass(string className,
            string classDescription, byte minimumAllowedAge,
            byte validityLength, float classFees)
        {
            LicenseClassID = -1;
            ClassName = className;
            ClassDescription = classDescription;
            MinimumAllowedAge = minimumAllowedAge;
            ValidityLength = validityLength;
            ClassFees = classFees;
        }

        private LicenseClass(int id, string className,
            string classDescription, byte minimumAllowedAge,
            byte validityLength, float classFees)
        {
            LicenseClassID = id;
        }

        public static LicenseClass Find(int id)
        {
            string className = string.Empty;
            string classDescription = string.Empty;
            byte minimumAllowedAge = 0;
            byte validityLength = 0;
            float classFees = 0;

            bool found = LicenseClassData.GetLicenseClassByID(
                id,
                ref className,
                ref classDescription,
                ref minimumAllowedAge,
                ref validityLength,
                ref classFees
            );

            if (!found)
                return null;

            return new LicenseClass(
                id,
                className,
                classDescription,
                minimumAllowedAge,
                validityLength,
                classFees
            );
        }
    }
}
