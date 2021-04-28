using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

// Võ Phi Minh Hiếu
// Mô phỏng phương thức của LinQ
// Tìm những string có độ dài <=5 


namespace LinQMethod
{
    class Program
    {
        struct Dev
        {
            public string Name;
            public int Age;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Test select method: ");
            IList<Dev> devList = new List<Dev>()
            {
                new Dev(){Name="Hieu",Age=5},
                new Dev(){Name="Linh",Age=6},
                new Dev(){Name="Dang",Age=7}
            };
            foreach (var name in devList.MySelect(Dev => Dev.Name))
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Console.WriteLine("Test Where method: ");
            string[] students = { "Maico", "Group", "MinhHieu","O_O","^_^" };
            foreach (var result in students.MyWhere(stu => stu.Length < 5))
            {
                Console.WriteLine(result);
            }
        }
    }
}
