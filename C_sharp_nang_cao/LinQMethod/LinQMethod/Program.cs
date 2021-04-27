using System;
using System.Linq;
using System.Collections;

// Võ Phi Minh Hiếu
// Mô phỏng phương thức của LinQ
// Tìm những string có độ dài <=5 


namespace LinQMethod
{
    class Program
    {
        static ArrayList simulationLinQ(string[] words)
        {

            ArrayList arlist = new ArrayList();
            foreach (string word in words)
            {
                if (word.Length <= 5)
                {
                    arlist.Add(word);
                }
            }
            return arlist;
        }
        static void Main(string[] args)
        {

            string[] words = { "MaiCo", "group", "LINQ", "beautiful", "world" };
            var shortWords = from word in words
                             where word.Length <= 5
                             select word;
            var shortWords_ver2 = simulationLinQ(words);
            Console.WriteLine("Cach LinQ: ");
            foreach (string word in shortWords)
            {
                Console.Write(word + "  ");
            }
            Console.WriteLine("");
            Console.WriteLine("Cach Mo Phong: ");
            foreach (string word in shortWords_ver2)
            {
                Console.Write(word + "   ");
            }
        }
    }
}
