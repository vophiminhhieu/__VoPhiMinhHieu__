using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class Bill : IIOConsole,ITryCatchInputInteger
    {
        private string id;
        private Date invoice = new Date();
        private Customer _customer_ = new Customer();
        private List<FanMachine> listFan = new List<FanMachine>();
        private List<AirMachine> listAir = new List<AirMachine>();
        private string name = "";
        private int count;

        public int ConsoleReadlineInteger()
        {
            int xPoint = Console.CursorLeft;
            int yPoint = Console.CursorTop;
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(xPoint, yPoint + 1);
                Console.WriteLine("Bạn nhập bị lỗi gì đó. Nhập lại nha.");
                Console.SetCursorPosition(xPoint, yPoint);
                Console.Write("                               ");
                Console.SetCursorPosition(xPoint, yPoint);
                return ConsoleReadlineInteger();
            }
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write("                           ");
            return a;
        }

        public void input(ref int xStart, ref int yStart)
        {
            Console.SetCursorPosition(xStart - 2, yStart++);
            Console.Write("Nhập thông tin hóa đơn");
            Console.SetCursorPosition(xStart, yStart++);
            Console.Write("Mời bạn nhập mã hóa đơn: ");
            id = Console.ReadLine();
            invoice.input(ref xStart, ref yStart);
            Console.SetCursorPosition(xStart - 2, yStart++);
            Console.Write("Nhập thông tin khách hàng");
            _customer_.input(ref xStart, ref yStart);
            Console.SetCursorPosition(xStart - 2, yStart++);
            Console.Write("Nhập thông tin chi tiết hóa đơn");
            Console.SetCursorPosition(xStart, yStart++); yStart++;
            Console.Write("Nhập số lượng chi tiết các loại: ");
            count = ConsoleReadlineInteger();
            for (int i = 0; i < count; i++)
            {
                Console.SetCursorPosition(xStart, yStart++);
                Console.Write("Mời bạn nhập chi tiết sản phẩm thứ " + (i + 1));
                Console.SetCursorPosition(xStart, yStart++);
                Console.Write("Chọn loại thiết bị điện (1-quạt 2-máy lạnh): ");
                int option = ConsoleReadlineInteger();
                if (option == 1)
                {
                    FanMachine fan = new FanMachine();
                    Console.SetCursorPosition(xStart, yStart++);
                    Console.Write("Chọn loại quạt (1-quạt đứng 2-quạt hơi nước 3-quạt điện): ");
                    switch (ConsoleReadlineInteger())
                    {
                        case 1:
                            fan = new FanStand();
                            break;
                        case 2:
                            fan = new FanSteam();
                            break;
                        case 3:
                            fan = new FanElectric();
                            break;
                        default:
                            break;
                    }
                    fan.input(ref xStart, ref yStart);
                    listFan.Add(fan);
                }
                else if (option == 2)
                {
                    AirMachine air = new AirMachine();
                    Console.SetCursorPosition(xStart, yStart++);
                    Console.Write("Chọn loại máy lạnh (1-máy 1 chiều 2-máy 2 chiều): ");
                    switch (ConsoleReadlineInteger())
                    {
                        case 1:
                            air = new AirOneSide();
                            break;
                        case 2:
                            air = new AirTwoSide();
                            break;
                        default:
                            break;
                    }
                    air.input(ref xStart, ref yStart);
                    listAir.Add(air);
                }
                else
                {
                    Console.WriteLine("Nhập Lỗi");
                    break;
                }
                yStart++;
                if (yStart >= 25)
                {
                    //clearScreen
                    for (int j = 0; j <= 20; j++)
                    {
                        Console.SetCursorPosition(20, 10 + j);
                        Console.Write("                                                                    ");
                    }
                    yStart = 10;
                }
            }

        }
        private double costBill()
        {
            double res = 0;
            for (int i = 0; i < listFan.Count; i++)
            {
                res+=listFan[i].getCost();
            }
            for (int i = 0; i < listAir.Count; i++)
            {
                res += listAir[i].getCost();
            }
            return res;
        }
        public void output(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Mã hóa đơn: " + id);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Ngày lập hóa đơn: " + invoice.toString());
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Thông tin khách hàng: ");
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Mã khách hàng: " + _customer_.getId());
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Tên khách hàng: " + _customer_.getName());
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Địa chỉ khách hàng: " + _customer_.getAddress());
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Số điện thoại khách hàng: " + _customer_.getPhone());
            Console.SetCursorPosition(xPoint, yPoint++);
        }
        public void printProduct(ref int xPoint,ref int yPoint, int choice)
        {
            Console.SetCursorPosition(xPoint, yPoint++);
            if (choice < 0)
            {
                choice = -choice;
            }
            choice = choice % (listAir.Count + listFan.Count);
            if (choice >= listFan.Count)
            {
                choice = choice - listFan.Count;
                Console.Write("*****************  Chi tiết sản phẩm thứ "+(choice+listFan.Count+1)+"  *******************");
                listAir[choice].output(ref xPoint,ref yPoint);
            }
            else
            {
                Console.Write("*****************  Chi tiết sản phẩm thứ " + (choice + 1) + "  *******************");
                listFan[choice].output(ref xPoint, ref yPoint);
            }
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("*****************  Tổng kết hóa đơn  ****************");
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Tổng giá hóa đơn: " + costBill());
            Console.SetCursorPosition(xPoint, yPoint++);
            Console.Write("Số lượng chi tiết trong hóa đơn: " + (listAir.Count+listFan.Count));
        }

        public string[] toString()
        {
            string[] result = new string[3 + listAir.Count + listFan.Count];
            result[0] = "Thông tin hóa đơn: < " + id + " > < " + invoice.toString() + " > < " + costBill() + ">";
            result[1] = "Thông tin khách hàng: < " + _customer_.getId() + " > < " + _customer_.getName() + " > < " +
                        _customer_.getAddress() + " > < " + _customer_.getPhone() + " >";
            for (int i = 0; i < listFan.Count; i++)
            {
                result[i + 2] = listFan[i].toString();
            }
            for (int i = 0; i < listAir.Count; i++)
            {
                result[i + listFan.Count+2] = listAir[i].toString();
            }
            result[listFan.Count + listAir.Count + 2] = "";
            return result;
        }
        public string getCustomerToString()
        {
            string result = "";
            result += _customer_.getId() + "," + _customer_.getName() + "," + _customer_.getAddress() + "," + _customer_.getPhone();
            return result;
        }
    }
}
