using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             File sơ đồ UML mô tả những class cơ sở : https://bom.to/EiSPbs88G9r2z
             Class Manager dùng để xử lý sự kiện menu, cũng như liên kết các class đã được khởi tạo để 
             sử dụng.
             Class GUIConsole dùng để xử lý màn hình, bao gồm một số thao tác như xóa màn hình, vẽ menu,
             vẽ khung,..
             Biến choice đại diện cho chức năng của menu, menu có 4 chức năng, choice được mặc định là 1          
             */
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.SetWindowSize(127, 40);
            Manager man = new Manager();
            GUIConsole UI = new GUIConsole();
            UI.printFrame(16, 2, 95, 35);
            UI.printMenu(50, 5);
            int choice = 1;
            man.eventMenu(ref choice);
            UI.clearScreen(0, 0, 126, 39);
        }
    }
}
