using System.Xml.Linq;

////ОРАНЖЕРЕЯ
////База данных должна содержать сведения о следующих объектах:
////Сотрудники - фамилия, имя, отчество, адрес, дата рождения, должность, оклад, сведения о перемещении 
///(долж-ность, причина перевода, номер и дата приказа).
////Цветы – название цветка, сорт, цена с градацией по партиям (до 10 штук, до 50, до 100, свыше 100), ответствен - ный цветовод.
////Клиенты - фамилия, имя, отчество, телефон, заказа 
///(цветок, сорт, количество, дата заказа, адрес доставки, работ - ник, доставивший заказ, дата выполнения, номер счета).

namespace greenhouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            e.Print();

            Flowers b= new Flowers();
            b.Print();
        }
    }
    public class Employee
    {
        public string lastname;
        public string firstname;
        public string patronymic;
        public string address;
        DateTime datebirth;
        public string post;
        public double salary;
      public Transfer[] Transfers=new Transfer[0] { };

        public void Print()
        {
            Console.WriteLine($"Сотрудник1: {lastname} {firstname} {patronymic} {address} {datebirth} {post} зарплата:{salary} рублей  сведения о перемещении:");
            foreach (Transfer transfer in Transfers)
            {
                Console.WriteLine($"Пост: {transfer.post} Причина: {transfer.reason} Номер: {transfer.number} Дата заказа:");

            }
           

        }
        public Employee(string lastname, string firstname, string patronymic, string address, DateTime datebirth, string post, double salary)
        {
            this.lastname = lastname;
            this.firstname = firstname; 
            this.patronymic = patronymic;
            this.address = address;
            this.datebirth = datebirth;
            this.post = post;
            this.salary = salary;
            //Transfers = new Transfer[0];
        }
       
        public Employee()
        {
            lastname = "Циммер";
            firstname = "Дарья";
            patronymic = "Александровна";
            address = "Проспект Карла Маркса 26";
            datebirth= new DateTime(2003,05,02);
            post = "флорист";
            salary = 50000;
            Transfers = new Transfer[0] { };


        }
    }
    public class Transfer
    {
        public string post;
        public string reason;
        public int number;
        DateTime dateorder;


        public Transfer()
        {
            
            post = "доставщик";
            reason = "потому что";
            number = 254;
            dateorder = new DateTime(1980, 05, 05);

        }
    }
    public class Flowers
    {
        public string name;
        public string variety;
        public double price;
        public string florist;

        public void Print()
        {
            Console.WriteLine($"цветок: {name} {variety}{price}{florist}");
        }

        public Flowers(string name,string variety, double price, string florist)
        {
            this.florist = florist;
            this.price = price;
            this.variety = variety;
            this.name = name;
        }
        public Flowers()
        {
            name = "Роза";
            variety = "опр";
            price = 50;
            florist = "hghjh";
           
        }

    }
    public class Customer
    {
        public string lastname;
        public string firstname;
        public string patronymic;
        public int phone;
        public order order;

    }
    public class order
    {
        public Flowers flowers;
        public string variety;
        public int quantity;
        public DateTime dateorder;
        public string addressdelivery;
        public Employee employee;
        public DateTime dateofcompletion;
        public string numberaccount;

    }
  
}