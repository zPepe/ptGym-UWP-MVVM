using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //        // ---------------------------------- CREATE TABLES ---------------------------------------------------------------------------------------##
            //        Database.CreateTables();



            //        //----------------------------------- DATETIME --------------------------------------------------------------------------------------------##
            //        DateTime classDate = new DateTime(2015, 11, 16, 18, 0, 0);
            //        DateTime registrationDate = new DateTime(2015, 11, 16, 18, 0, 0);


            //        //----------------------------------- DADOS -----------------------------------------------------------------------------------------------##

            //        Coach coach1 = new Coach();
            //        coach1.Name = "Pepe";
            //        coach1.Age = 25;
            //        coach1.CC = 123456;
            //        coach1.Create();

            //        Room room1 = new Room();
            //        room1.Name = "Sala de Yoga";
            //        room1.Capacity = 30;
            //        room1.Create();

            //        Class class1 = new Class();
            //        class1.Name = "Aula1";
            //        class1.Type = "Yoga";
            //        class1.Date = classDate;
            //        class1.Price = 50;
            //        class1.IdCoach = coach1.Id;
            //        class1.IdRoom = room1.Id;
            //        //class1.IdCoach = Coach.GetByCC(123456).First().Id;
            //        //class1.IdRoom = Room.GetByName("Sala de Yoga").First().Id;
            //        class1.Create();

            //        Client client1 = new Client();
            //        client1.Name = "Paulo";
            //        client1.CC = 12345;
            //        client1.Phone = "932899664";
            //        client1.HomeAddress = "Rua Rainha Santa Isabel";
            //        client1.Locality = "Bragança";
            //        client1.Create();


            //        Registration registration1 = new Registration();
            //        registration1.Date = registrationDate;
            //        registration1.Value = 20;
            //        registration1.Ref = 123;
            //        registration1.IdClass = class1.Id;
            //        registration1.IdClient = client1.Id;
            //        registration1.Create();

            //        Thread.Sleep(1000);

            //        //----------------------------------- CREATE ----------------------------------------------------------------------------------------------##

            //        //----------------------------------- UPDATE -----------------------------------------------------------------------------------------------##
            //        //class1.Type = "Musculação"; class1.Update();
            //        //client1.Name = "Carlos"; client1.Update();
            //        //coach1.Name = "Joaquim"; coach1.Update();
            //        //registration1.Value = 40; registration1.Update();
            //        //room1.Capacity = 100; room1.Update();

            //        //----------------------------------- DELETE ------------------------------------------------------------------------------------------------##
            //        //class1.Delete();
            //        //client1.Delete();
            //        //coach1.Delete();
            //        //registration1.Delete();
            //        //room1.Delete();


            //        //Console.WriteLine("--->{0}<---", class1.GetByName());
            //        //Console.WriteLine("--->{0}<---", client1.GetByCC());
            //        //Console.WriteLine("--->{0}<---", coach1.GetByCC());
            //        //Console.WriteLine("--->{0}<---", room1.GetByName());
            //        //Console.WriteLine("--->{0}<---", registration1.GetByRef());


            //        //----------------------------------- GETALL -----------------------------------------------------------------------------------------------##
            //        ObservableCollection<Class> classes = Class.GetAll();
            //        ObservableCollection<Client> clients = Client.GetAll();
            //        ObservableCollection<Coach> coaches = Coach.GetAll();
            //        ObservableCollection<Registration> registrations = Registration.GetAll();
            //        ObservableCollection<Room> rooms = Room.GetAll();


            //        //----------------------------------- MOSTRAR DADOS ----------------------------------------------------------------------------------------##
            //        Console.WriteLine("---Teste Class:");

            //        foreach (var item in classes)
            //        {
            //            Console.WriteLine(item.Name);
            //            Console.WriteLine(item.Type);
            //            Console.WriteLine(item.Date);
            //            Console.WriteLine(item.Price);

            //        }

            //        Console.WriteLine("----Teste Client:");

            //        foreach (var item in clients)
            //        {
            //            Console.WriteLine(item.Name);
            //            Console.WriteLine(item.CC);
            //            Console.WriteLine(item.Phone);
            //            Console.WriteLine(item.HomeAddress);
            //            Console.WriteLine(item.Locality);
            //        }

            //        Console.WriteLine("----Teste Coach:");

            //        foreach (var item in coaches)
            //        {
            //            Console.WriteLine(item.Name);
            //            Console.WriteLine(item.Age);
            //            Console.WriteLine(item.CC);
            //        }

            //        Console.WriteLine("----Teste Registration");

            //        foreach (var item in registrations)
            //        {
            //            Console.WriteLine(item.Date.ToString("dd-MM-yyyy"));
            //            Console.WriteLine(item.Value);
            //            Console.WriteLine(item.Ref);
            //        }


            //        Console.WriteLine("-----Teste Room");

            //        foreach (var item in rooms)
            //        {
            //            Console.WriteLine(item.Capacity);
            //            Console.WriteLine(item.Name);
            //        }
        }
    }
}

