using greenhouse;

namespace TestGreenhouse
{
    [TestClass]
    public class employeeTest
    {
        [TestMethod]
        public void TestFullName()
        {
            Employee employee = new Employee
            {
                Lastname = "Иванов",
                Firstname = "Иван",
                Patronymic = "Иванович"
            };
            string fullName = employee.FullName;
            Assert.AreEqual("Иван Иванов Иванович", fullName);
        }

        [TestMethod]
        public void TestAgeCalculation()
        {

        }
    }
}