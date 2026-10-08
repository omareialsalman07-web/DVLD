using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public static class TestTypeService
    {
        public static TestType Find(int ID)
        {
            TestType testType = null;
            try
            {
                string Title = "";
                string Description = "";
                float Fees = 0;
                if (TestTypeData.GetTestType(ID, ref Title, ref Description, ref Fees))
                {
                    testType = new TestType(ID, Title, Description, Fees);
                }
            }
            catch (Exception ex)
            {
                testType = null;
                throw;
            }

            return testType;
        }

        public static DataTable GetAllTestTypes_ToTable()
        {
            DataTable dt = null;

            try
            {
                dt = TestTypeData.GetAllTestTypes();
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }

            return dt;
        }

        public static List<TestType> GetAllTestTypes()
        {
            List<TestType> TestTypeServices = new List<TestType>();

            DataTable dt = null;
            try
            {
                dt = TestTypeData.GetAllTestTypes();
            }
            catch (Exception ex)
            {
                dt = null;
                throw;
            }

            if (dt == null) return null;

            foreach (DataRow row in dt.Rows)
            {
                TestTypeServices.Add(new TestType(Convert.ToInt32(row["ID"]), row["Title"].ToString(), row["Description"].ToString(), Convert.ToSingle(row["Fees"])));
            }

            return TestTypeServices;
        }

        public static bool UpdateTestInfo(in TestType testType)
        {
            bool success = false;
            try
            {
                success = TestTypeData.UpdateTestTypeInfo(testType.ID, testType.Title, testType.Description, testType.Fees);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }

        public static bool UpdateTestInfo(int ID, string Title, string Description, float Fees)
        {
            bool success = false;
            try
            {
                success = TestTypeData.UpdateTestTypeInfo(ID, Title, Description, Fees);
            }
            catch (Exception ex)
            {
                success = false;
                throw;
            }

            return success;
        }
    }
}
