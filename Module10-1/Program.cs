using Module10_1;
using System;
using System.Runtime.CompilerServices;

namespace Module10
{
    class Program
    {
       static ILogger Logger {  get; set; }

        static void Main ()
        {
            Logger = new Logger ();

            var worker1 = new Worker1(Logger);//на вход интерфейс от логгер
            var worker2 = new Worker2(Logger);
            var worker3 = new Worker3(Logger);

            worker1.Work();
            worker2.Work();
            worker3.Work();

            Console.ReadKey();

        }
    }

    public interface ILogger
    {
        void Event(string message);//функция
        void Error(string message);//функция
    }

    public class Logger : ILogger//класс логгер будет реализовывать интерфейс айлоггер
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            //отправка в бд
            //отправка на почту
            Console.WriteLine(message);
        }
    }

    public interface IWorker//интерфейс будет определять что они будут делать
    {
        void Work();  
    }

    public interface IWhatsApp
    {
        public void SendMessage(string message);
    }

    public interface IViber
    {
        public void SendMessage(string message);
    }

    public interface IWriter
    {
        void Write();
    }

    public interface IReader
    {
        void Read();
    }

    public interface IMailer
    {
        void SendEmail();
    }

    public class FileManager : IWriter, IMailer, IReader
    {
        void IWriter.Write()
        {
            Console.WriteLine();
        }

        void IMailer.SendEmail()
        {
            Console.WriteLine();
        }

        void IReader.Read()
        {
            Console.WriteLine();
        }
    }

    class Program3
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            ((IReader)fileManager).Read();
            ((IMailer)fileManager).SendEmail();
            ((IWriter)fileManager).Write();
        }
    }

    public class NewMessanger : IWhatsApp, IViber
    {
        void IWhatsApp.SendMessage(string message)
        {
            Console.WriteLine("{0} : {1}", "WhatsApp", message); 
        }

        void IViber.SendMessage(string message)
        {
            Console.WriteLine("{0} : {1}", "Viber", message);
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            NewMessanger newMessanger = new NewMessanger();
            ((IWhatsApp)newMessanger).SendMessage("Hello world");//особенность явной реализации интерфейсаИ сделали мы так, потому что обратиться напрямую к методу SendMessage класса NewMessenger невозможно, ибо данный метод не является методом класса NewMessenger.
            ((IViber)newMessanger).SendMessage("Hello world");

            Console.ReadKey();
        }
    }

    public interface ICalculator
    {
       //void Solve(int number);
        void Solve(int numberOne, int numberTwo);
    }

    public class BaseCalculator : ICalculator
    {
        //явная реализация
        void ICalculator.Solve(int number)//явная реализация
        {

        }

        void ICalculator.Solve(int numberOne, int numberTwo)
        {

        }
        /*public void Solve(int number)//неявная реализация
        {
            
        }

        public void Solve(int numberOne, int numberTwo)//неявная реализация
        {
            
        }*/
    }

    public interface ICreatable
    {
        void Create();
    }

    public interface IDeletable
    {
        void Delete();
    }

    public interface IUpdatable
    {
        void Update();
    }

    public class Entity : ICreatable, IDeletable, IUpdatable
    {
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public interface IBook
    {
        void Read();
    }

    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
    }

    public class ElectronicBook : IBook, IDevice
    {
        void IBook.Read()
        {

        }

        void IDevice.TurnOff()
        {

        }

        void IDevice.TurnOn()
        {

        }
    }

    public interface IMessenger <out T> //бобщенный интерфейс // Слово out указывает, что интерфейс IMessenger теперь является ковариантным.
    {
        T DeviceInfo(); //В качестве параметра T будет выступать либо класс, либо параметр, который мы укажем при реализации. 
    }

    //Контрвариация
    /*public interface IMessenger <in T> //бобщенный интерфейс // Слово out указывает, что интерфейс IMessenger теперь является контрвариантным.
    {
        void GetDeviceInfo(); //В качестве параметра T будет выступать либо класс, либо параметр, который мы укажем при реализации. 
    }*/

    public class Phone
    {

    }

    public class IPhone:Phone
    {

    }
    public class Computer
    {

    }

    public class Viber <T>: IMessenger <T> where T: Phone, new () //реализация интерфейса IMessenger через класс Phone
    {
        public T DeviceInfo() //прри вызове функции DeviceInfo
        {
            T device = new T();
            Console.WriteLine(device);
            return new T();
            //return null; //возвращает объект Phone
        }
    }

    public class Program5
    {
        static void Main(string[] args)
        {
            IMessenger<Phone> viberInPhone = new Viber<Phone>();
            IMessenger<IPhone> viberInIPhone = new Viber<IPhone>();

            IMessenger<Phone> viberInIphone = new Viber<IPhone>();//Объект интерфейса более универсального типа Phone мы можем привести к объекту интерфейса более конкретного типа IPhone следующей строкой:

            viberInPhone.DeviceInfo();
            viberInIPhone.DeviceInfo();

            Console.Read();

            //Контрвариация
            /*
             * IMessenger<Phone> viberInPhone = new Viber<Phone>();
            viberInPhone.GetDeviceInfo(new Phone());

            IMessenger<IPhone> viberInIphone = new Viber<IPhone>();
            viberInIphone.GetDeviceInfo(new IPhone());

            IMessenger<IPhone> viberInIphone = new Viber<Phone>(); Данной строкой мы выполняем приведение объекта интерфейса более универсального типа Phone к объекту интерфейса более конкретного типа IPhone.

            Console.Read();*/
        }
    }

    public class Car
    {

    }

    public class Bike : Car
    {

    }

    public class House
    {

    }

    public class Garage : House
    {
    
    }

    public interface IGarageManager<in T, out Z> //обобщенный интерфейс ин -котрвариантный, аут-ковариантный
    {
        Z GetGarageInfo(); //возвращает объеты гаража
        void Add(T car); //парамет у метода эдд, добавляет новый автомобиль в гараж
    }

    public class GarageManagerBase : IGarageManager<Car, Garage>
    {
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public Garage GetGarageInfo()
        {
            throw new NotImplementedException();
        }
    }

    public class Program6
    {
        static void Main(string[] args)
        {
            IGarageManager<Car, Garage> garageManager1 = new GarageManagerBase();
            IGarageManager<Bike, Garage> garageManager2 = new GarageManagerBase();//контрвариация в дейсвтии
            IGarageManager<Bike, House> garageManager3 = new GarageManagerBase();//ковариация в действии

            var user = new User();
            var account = new Account();
            IUpdater<Account> updater = new UserService();
            var userService = new UserService();
        }
    }

    public class User
    {

    }

    public class Account : User
    {

    }

    public interface IUpdater<in T>
    {
        void Update(T entity);
    }

    public class UserService : IUpdater<User>
    {
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}