using System;

// VÕ Phi Minh Hiếu
// Giai Fibonacy bởi 3 cách: Dùng toán tính ra ngay, dùng đệ quy, và dùng quy hoạch động



namespace C_sharp_nang_cao
{
    class Program
    {
        static int Fibonacy_1(int index)
        {
            double cst1 = (1 + Math.Sqrt(5)) / 2;
            double cst2 = (1 - Math.Sqrt(5)) / 2;
            double cst3 = (5 + Math.Sqrt(5)) / 10;
            double cst4 = (5 - Math.Sqrt(5)) / 10;
            return round(Math.Pow(cst1, index) * cst3 + Math.Pow(cst2, index) * cst4);
        }
        static int round(double t)
        {
            if (t - (int)t >= 0.5)
            {
                return (int)t + 1;
            }
            return (int)t;
        }
        static int Fibonacy_2(int index)
        {
            if (index == 0 || index == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacy_2(index - 1) + Fibonacy_2(index - 2);
            }
        }
        static int Fibonacy_3(int index)
        {
            if (index == 0 || index == 1)
            {
                return 1;
            }
            int[] fibo = new int[index + 1];
            fibo[0] = 1;
            fibo[1] = 1;
            for(int i = 2; i <= index; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }
            return fibo[index];
        }
        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap index cua Fibonacy: ");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ket qua Fibonacy boi ba cach ");
            Console.WriteLine("Cach 1. S = " + Fibonacy_1(index));
            Console.WriteLine("Cach 2. S = " + Fibonacy_2(index));
            Console.WriteLine("Cach 3. S = " + Fibonacy_3(index));
        }
    }
}
