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
                Lastname = "������",
                Firstname = "����",
                Patronymic = "��������"
            };
            string fullName = employee.FullName;
            Assert.AreEqual("���� ������ ��������", fullName);
        }

        [TestMethod]
        public void TestAgeCalculation()
        {

        }
    }
}