using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TextRpg
{
    public class Title
    {
        private bool stopTitle = false;
        // 타이틀 화면
        // 아무 키나 누르세요! 
        public Title()
        {
            //Console.SetCursorPosition(x, y); //커서 위치 변경
            //Console.CursorVisible = false; //커서 안보이게
            //Console.CursorVisible = true; //커서 보이게
            //Console.Title 제목 설정
            //해상도 130 * 38 사이즈
            Console.CursorVisible = false;
            Console.SetWindowSize(121, 39);
            Console.Title = "텍스트 RPG";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n");

            PrintTitle();


            AnyKey();
            Console.ReadKey(true);
            stopTitle = true;
            Task.Delay(1800).Wait();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private async void AnyKey()
        {
            while (true)
            {
                Console.SetCursorPosition(110 / 2, 20);
                Console.Write("- Press Any Key -");
                if (stopTitle) { break; }
                await Task.Delay(800);          //유지되는 기간
                clearCurrentLine();
                if (stopTitle) { break; }
                await Task.Delay(500);          //사라졌을 때 기간
                if (stopTitle) { break; }
            }

            if (stopTitle)
            {
                for (int i = 0; i < 4; ++i)
                {
                    Console.SetCursorPosition(110 / 2, 20);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("- Press Any Key -");
                    await Task.Delay(90);          //유지되는 기간
                    clearCurrentLine();
                    await Task.Delay(100);          //사라졌을 때 기간
                }
                Console.SetCursorPosition(110 / 2, 20);
                Console.Write("- Press Any Key -");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private async void PrintTitle()
        {
            List<string> title = new List<string>();

            title.Add("\t\t\t'########:'########:'##::::'##:'########::::'########::'########:::'######:::\n");
            title.Add("\t\t\t... ##..:: ##.....::. ##::'##::... ##..::::: ##.... ##: ##.... ##:'##... ##::\n");
            title.Add("\t\t\t::: ##:::: ##::::::::. ##'##:::::: ##::::::: ##:::: ##: ##:::: ##: ##:::..:::\n");
            title.Add("\t\t\t::: ##:::: ######:::::. ###::::::: ##::::::: ########:: ########:: ##::'####:\n");
            title.Add("\t\t\t::: ##:::: ##...:::::: ## ##:::::: ##::::::: ##.. ##::: ##.....::: ##::: ##::\n");
            title.Add("\t\t\t::: ##:::: ##:::::::: ##:. ##::::: ##::::::: ##::. ##:: ##:::::::: ##::: ##::\n");
            title.Add("\t\t\t::: ##:::: ########: ##:::. ##:::: ##::::::: ##:::. ##: ##::::::::. ######:::\n");
            title.Add("\t\t\t:::..:::::........::..:::::..:::::..::::::::..:::::..::..::::::::::......::::\n");

            int number = 0;

            //foreach (string s in title)
            List<char> titlechar = new List<char>();


            foreach (string c in title)
            {
                foreach (char ch in c)
                {
                    titlechar.Add(ch);
                }
            }

            //수평 81
            //수직 8

            Random rand = new Random();
            int num = 0;
            for (int x = 0; x < 81; ++x)
            {
                for (int y = 0; y < 8; ++y)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(19 + x, 10 + y);
                    Console.Write(titlechar[num]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(titlechar[num]);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(titlechar[num]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(titlechar[num]);
                    num += 81;

                }
                Task.Delay(rand.Next(10, 60)).Wait();
                num = x + 1;
            }
                Console.ForegroundColor = ConsoleColor.White;



            //{
            //    foreach (string c in title)
            //    {

            //        Console.Write(c);
            //        Task.Delay(80).Wait();

            //    }


            //    //foreach (char c in title[1])
            //    //{
            //    //    Console.Write(c);
            //    //    await Task.Delay(10);
            //    //}
            //    ++number;
            //}

        }






        private void clearCurrentLine()     //지웠다가 다시 써주는 함수
        {
            string s = "\r";
            s += new string(' ', Console.CursorLeft);
            s += "\r";
            Console.Write(s);
        }







    }
}
