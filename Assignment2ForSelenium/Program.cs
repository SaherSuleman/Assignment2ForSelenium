using NUnit.Framework;

namespace Assignment2_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginTest = new LoginTest();
            loginTest.Setup(); // Fixed: Use the instance 'loginTest' to call the non-static method
            loginTest.ValidLoginTest(); // Fixed: Use the instance 'loginTest' to call the non-static method
            //loginTest.InvalidLoginTest();

            var EmployeeTest = new EmployeeTests();
            EmployeeTest.Setup();
            EmployeeTest.CreateEmployeeTest();
            EmployeeTest.EditEmployeeTest();
            EmployeeTest.LogoutTest();


        }
    }
}