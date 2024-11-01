using System.Net;
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
            //Employee e = new Employee();
            //e.Print();
            Employee e = new Employee();

            // Пример установки значений для свойств
            e.Lastname = "Иванов";
            e.Firstname = "Иван";
            e.Patronymic = "Иванович";
            e.Address = "Москва, ул. Пушкина, д. 1";
            e.Datebirth = new DateTime(1990, 1, 1);
            e.Post = "Менеджер";

            // Попробуем установить отрицательную зарплату
            try
            {
                e.Salary = -50000; // Это вызовет исключение
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Transfer n = new Transfer();
            n.Print();
            Customer p = new Customer();
            p.Print();

            Flowers b = new Flowers();
            b.Print();
            Order order = new Order();
            order.Print();


            Console.ReadKey();

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
       Transfer[] Transfers;

        public void Print()
        {
            Console.WriteLine($"Сотрудник: {FullName}, Адрес: {address}, Дата рождения: {datebirth.ToShortDateString()}, " +
                          $"Должность: {post}, Зарплата: {salary} рублей, Возраст: {Age} лет. " +
                          $"Сведения о перемещении: ");
           

        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public DateTime Datebirth
        {
            get { return datebirth; }
            set { datebirth = value; }
        }
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата не может быть отрицательной.");
                salary = value;
            }
        }

// Свойство для полного имени
public string FullName
        {
            get
            {
                return $"{firstname} {lastname} {patronymic}";
            }
        }

        // Свойство для возраста на основе даты рождения
        public int Age
        {
            get
            {
                return DateTime.Now.Year - datebirth.Year - (DateTime.Now.DayOfYear < datebirth.DayOfYear ? 1 : 0);
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
            Transfers = new Transfer[0];
        }
        public Employee()
        {
            lastname = "Иванов";
            firstname = "Иван";
            patronymic = "Иванович";
            address = "Ленина 5";
            datebirth = new DateTime(1970, 07, 02);
            post = "флорист";
            salary = 50000;



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
            reason = "повышение";
            number = 254;
            dateorder = new DateTime(1980, 05, 05);

        }

        public void Print()
        {
         
                Console.WriteLine($"должность: {post}  + Причина перевода: {reason} +Номер: {number}  + Дата приказа:{dateorder}");

         


        }
    }
    public class Flowers
    {
        public string name;
        public string variety;
        public double price;
        public string florist;
        public string Name
        {
            get { return name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("имя не может быть пустым");
                name = value;
            }
        }
        public string Variety
        {
            get { return variety; }
            set { variety = value; }
        }
        public double Price
        {
            get { return price; }
            set {
                if (price<0)
                    throw new ArgumentException("неверно");
                price = value; 
                 }
        }
        public string Florist
        {
            get { return florist; }
            set { florist = value; }
        }

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

    public class Order
    {
        //Flowers[] flowers;
        private List<Flowers> flowers;
        public string variety; 
        public int quantity;/*кол-во*/
        public DateTime dateorder; /*дата и время  заказа*/
        public string addressdelivery; /*адрес доставки*/
        public Employee employee;
        public DateTime dateofcompletion; /*дата и время вып заказа*/
        public string numberaccount;/* номер счета*/
        

        public Order()
        {

        }
       
        public string Variety
        {
            get { return variety; }
            set { variety = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public DateTime Dateorder
        {
            get { return dateorder; }
            set { dateorder = value; }
        }
        public string Addressdelivery
        {
            get { return addressdelivery; }
            set { addressdelivery = value; }
        }
        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
        public DateTime Dateofcompletion
        {
            get { return dateofcompletion; }
            set { dateofcompletion = value; }
        }
        public string Numberaccount
        {
            get { return numberaccount; }
            set { numberaccount = value; }
        }
        public Order(DateTime Dateorder)
        {
            flowers = new List<Flowers>();
            Dateorder = dateorder;
            dateofcompletion = Dateorder; // Изначально дата выполнения совпадает с датой заказа
            addressdelivery = "Не указан"; // Изначально адрес не указан
        }

        // AddFlower, который будет добавлять цветок к заказу
        public void AddFlower(Flowers flower)
        {
            flowers.Add(flower);
        }

        // метод для вычисления количества дней (или часов), сколько заказ находился в обработке (разница между датой заказа и датой исполнения)
        public TimeSpan GetProcessingTime()
        {
            return Dateofcompletion - Dateorder;
        }

        ////Метод для вычисления стоимости заказа
        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (var flower in flowers)
            {
                totalCost += flower.price;
            }
            return totalCost;
        }

        // Метод для изменения деталей заказа
        public void ChangeOrderDetails(string newAddress, DateTime newDateOfCompletion)
        {
            addressdelivery = newAddress;
            dateofcompletion = newDateOfCompletion;
        }

        // Метод для получения названий всех цветов в заказе 
        public string[] GetFlowersNames()
        {
            List<string> flowerNames = new List<string>();
            foreach (var flower in flowers)
            {
                flowerNames.Add(flower.Name);
            }
            return flowerNames.ToArray();
        }

        // Метод для печати информации о заказе
        public void Print()
        {
            Console.WriteLine($"Order Date: {dateorder}");
            Console.WriteLine($"Completion Date: {dateofcompletion}");
            Console.WriteLine($"Delivery Address: {addressdelivery}");
            Console.WriteLine("Flowers in Order:");
            foreach (var flower in flowers)
            {
                flower.Print();
            }
        }
    }


}
    public class Customer
    {
        public string lastname;
        public string firstname;
        public string patronymic;
        public int phone;
        //public Order order;

        public Customer(string lastname)
        {
            this.lastname = lastname;
        //    this.order = order;
        }
        public Customer()
        {
            lastname = "иванов";

        }
        public void Print()
        {
            Console.WriteLine($"клиент:{lastname} ");
        }
    }
