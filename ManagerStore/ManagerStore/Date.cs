using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class Date : IIOConsole
    {
        private int _day_;
        private int _month;
        private int _year;
        private int _hour = 0;
        private int _minutes = 0;
        private int _seconds = 0;
        public void input(ref int xPoint, ref int yPoint)
        {
            Console.SetCursorPosition(xPoint, yPoint + 1);
            Console.Write(" (theo định dạng dd/mm/yyyy)");
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("Mời bạn nhập ngày hóa đơn : ");
            string inp = Console.ReadLine();
            if (isInvalid(inp))
            {
                input(inp);
                if (isInvalid()==true)
                {
                    Console.SetCursorPosition(xPoint, yPoint + 1);
                    Console.Write("                                           ");
                    Console.SetCursorPosition(xPoint, yPoint + 2);
                    Console.Write("                                           ");
                    yPoint++;
                    return;
                }
            }
            Console.SetCursorPosition(xPoint, yPoint + 2);
            Console.Write("Bạn nhập không hợp lệ ! Mời nhập lại");
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write("                                                       ");
            input(ref xPoint, ref yPoint);
        }
        public void output(ref int xPoint, ref int yPoint)
        {

        }
        public bool isInvalid(string d)
        {
            if (d.Length < 10)
            {
                return false;
            }
            return true;
        }
        public void input(string d)
        {
            _day_ = int.Parse(d.Substring(0, 2));
            _month = int.Parse(d.Substring(3, 2));
            _year = int.Parse(d.Substring(6, 4));
        }
        public string toString()
        {
            string result = "" + _day_ + "/" + _month + "/" + _year;
            return result;
        }
        public bool isInvalid()
        {
            if (_day_ < 0 || _month < 0 || _year < 0 || _hour < 0 || _minutes < 0 || _seconds < 0 || _day_ > 31 || _month > 12 || _hour > 24 || _minutes > 59 || _seconds > 59)
            {
                return false;
            }
            if (_month == 2)
            {
                if (isLeapYear(_year))
                {
                    if (_day_ > 29)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_day_ > 28)
                    {
                        return false;
                    }
                }
            }
            if (_month == 4 || _month == 6 || _month == 9 || _month == 11)
            {
                if (_day_ > 30)
                {
                    return false;
                }
            }
            DateTime _day = new DateTime(_year, _month, _day_, _hour, _minutes, _seconds);
            if (_day > DateTime.Now)
            {
                return false;
            }
            return true;
        }
        private bool isLeapYear(int _year_)
        {
            if ((_year_ % 4 == 0 && _year_ % 100 != 0) || (_year_ % 400 == 0))
            {
                return true;
            }
            return false;
        }
    }
}
