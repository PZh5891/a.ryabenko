using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test_CRM
{
    internal class Program
    {
        private const string fileName = "Data.dat";

        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            Console.WriteLine("Введите команду 'go' чтобы выполнить задание");
            bool repeat = true;
            List<Partner> Data = null;
            while (repeat)
            {
                Console.Write("Command: ");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "exit":
                        repeat = false;
                        continue;
                    case "test":
                        Data = InitSomeData();
                        
                        break;
                    case "go":
                        Data = InitSomeData();
                        //------------------
                        Console.Write("п.1 и п.2");
                        if (!(Save(Data) && Load(out Data)))
                        {
                            break;
                        }
                        Console.WriteLine(" - complete!");
                        //------------------
                        Console.WriteLine("п.3");
                        ListIndividual(Data);
                        //------------------
                        Console.WriteLine("п.4 и п.5");
                        ListLegal(Data);
                        break;
                    case "init":
                        if (Data is null)
                        {
                            Data = InitSomeData();
                            Console.WriteLine("Some data create!");
                        }
                        else
                        {
                            Console.WriteLine("Error: Some data already exist!");
                        }
                        break;
                    case "save":
                        if (Data == null)
                        {
                            Console.WriteLine("Error: Data is empty!");
                        }
                        else
                        {
                            Save(Data);
                        }
                        break;
                    case "load":
                        Load(out Data);
                        break;
                    case "list":
                        if (Data != null)
                        {
                            foreach (var item in Data)
                            {
                                Console.WriteLine(item.Description);
                            }
                        }
                        break;
                    case "reset":
                        Data = null;
                        break;
                    default:
                        Console.WriteLine("unknown command {0}", command);
                        break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Program stoped. Press any key to close...");
            Console.ReadKey();
        }

        static string GetFullFilePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\" + fileName;
        }

        static bool Load(out List<Partner> data)
        {
            data = null;
            try
            {
                data = Helper.ReadFromBinaryFile<List<Partner>>(GetFullFilePath());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return true;
        }

        static bool Save(List<Partner> data)
        {
            try
            {
                Helper.WriteToBinaryFile(GetFullFilePath(), data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return true;
        }

        static void ListIndividual(List<Partner> data)
        {
            List<IndividualEntity> list = data.FindAll(x => x is IndividualEntity).ConvertAll(x => (IndividualEntity)x);
            List<IndividualEntity> sortList = list.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ThenBy(x => x.MiddleName).ToList();
            foreach (var item in sortList)
            {
                Console.WriteLine(item.Description);
            }
        }

        static void ListLegal(List<Partner> data)
        {
            List<LegalEntity> list = data.FindAll(x => x is LegalEntity).ConvertAll(x => (LegalEntity)x);
            list.Sort((x, y) => x.Contacts.Count().CompareTo(y.Contacts.Count()));
            foreach (var item in list)
            {
                Console.WriteLine(item.Description);
            }
        }
        static List<Partner> InitSomeData()
        {
            string currUser = "SomeUser";
            var result = new List<Partner>();

            Partner i1 = new IndividualEntity("0004", currUser, "Сидоров", "Сидор", "С");
            IndividualEntity i2 = new IndividualEntity("0005", currUser, "Сидоров", "Иван", "Иванович");
            IndividualEntity i3 = new IndividualEntity("0006", currUser, "Сидоров", "Иван", "Пертович");
            IndividualEntity i4 = new IndividualEntity("0007", currUser, "Иванов", "Петр", "Пертович");

            Partner l1 = new LegalEntity("0001", currUser);
            LegalEntity l2 = new LegalEntity("0002", currUser);
            l2.Adress = "some street 1";
            l2.Title = "title 2";
            l2.Contacts.Add(i1 as IndividualEntity);
            l2.Contacts.Add(i2);
            l2.Contacts.Add(i3);
            LegalEntity l3 = new LegalEntity("0003", currUser);
            l3.Title = "title 3";
            l3.Contacts.Add(i2);
            l3.Contacts.Add(i3);

            result.Add(l1);
            result.Add(l2);
            result.Add(l3);
            result.Add(i1);
            result.Add(i2);
            result.Add(i3);
            result.Add(i4);

            return result;
        }
    }
}
