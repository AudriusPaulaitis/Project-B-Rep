using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Autorisatie
{ 
    class Login
    {

    //Method voor inlogverificatie
        public bool loginScreen()
        {
            Console.WriteLine("Voer uw werknemers ID en wachtwoord in");
            Console.WriteLine("--------------------------------------");
            Console.Write("Werknemers ID: ");
            string werknemersId = Console.ReadLine();
            Console.Write("Wachtwoord: ");
            string wachtwoord = Console.ReadLine();

            List<Employee> employees;
            using (var stream = File.OpenText("employees.json"))
            {
                var json = stream.ReadToEnd();
                employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            }

            //Voor als een employee toegevoegd moet worden
            //var newEmployee = new Employee
            //{
            //    WorkId = "test1",
            //    Password = "hallo!"
            //};
            //employees.Add(newEmployee);
            //using (var stream = File.CreateText("employees.json"))
            //{
            //    stream.Write(JsonConvert.SerializeObject(employees, Formatting.Indented));
            //}


            var employee = employees.FirstOrDefault(emp => emp.WorkId == werknemersId);
            if (employee == null) return false;

            if (employee.Password != wachtwoord) return false;

            return true;

        }

    }
}
