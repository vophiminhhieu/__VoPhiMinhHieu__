using System;

/// VÕ Phi Minh Hiếu. Thời gian kết thúc 11:00
// Các tính năng chưa có: GUI đẹp
//                        Xử lý đầu vào chưa hiệu quả, ví dụ nhập số thực nếu nhập tùm lum thì bug
//                        Chỉ có 4 tính năng cộng trừ nhân chia


namespace Test_C_sharp_Co_Ban
{ 
    class Program
    {
        
        static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("             May Tinh Co Ban");
            Console.WriteLine("1. Cong Hai So ");
            Console.WriteLine("2. Tru Hai So ");
            Console.WriteLine("3. Nhan Hai So ");
            Console.WriteLine("4. Chia Hai So ");
            Console.WriteLine("5. Thoat ");
            Console.Write("Moi ban nhap tinh nang: ");
        }
        static void input(ref double a, ref double b)
        {
            Console.WriteLine("");
            Console.Write("Moi ban nhap so dau tien: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Moi ban nhap so thu hai: ");
            b = Convert.ToDouble(Console.ReadLine());
        }
        static double Add(double a, double b)
        {
            return a + b;
        }
        static double Substract(double a, double b)
        {
            return a - b;
        }
        static double Multi(double a, double b)
        {
            return a * b;
        }
        static double Device(double a, double b)
        {
            return a / b;
        }
        static void OutputResult(double result)
        {
            result = Math.Round(result, 2);
            Console.WriteLine("Ket qua cua ban la: " + result);
        }
        static void ClearScreen()
        {
            Console.WriteLine("Moi ban Enter de tiep tuc");
            Console.ReadLine();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("                                           ");
            }
        }
        static void Main(string[] args)
        {
            double a = 0.0F;
            double b = 0.0F;
            Menu();
            int choice = Convert.ToInt32(Console.ReadLine());
            while (choice != 5)
            {
                input(ref a, ref b);
                if (choice == 1)
                {
                    OutputResult(Add(a, b));
                }
                if (choice == 2)
                {
                    OutputResult(Substract(a, b));
                }
                if (choice == 3)
                {
                    OutputResult(Multi(a, b));
                }
                if (choice == 4)
                {
                    OutputResult(Device(a, b));
                }
                ClearScreen();
                Console.SetCursorPosition(0, 0);
                Menu();
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
