using System;
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
            Console.SetWindowSize(130,39);
            Console.Title = "텍스트 RPG";
            Console.Clear();
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t'########:'########:'##::::'##:'########::::'########::'########:::'######:::");
            Console.WriteLine("\t\t\t... ##..:: ##.....::. ##::'##::... ##..::::: ##.... ##: ##.... ##:'##... ##::");
            Console.WriteLine("\t\t\t::: ##:::: ##::::::::. ##'##:::::: ##::::::: ##:::: ##: ##:::: ##: ##:::..:::");
            Console.WriteLine("\t\t\t::: ##:::: ######:::::. ###::::::: ##::::::: ########:: ########:: ##::'####:");
            Console.WriteLine("\t\t\t::: ##:::: ##...:::::: ## ##:::::: ##::::::: ##.. ##::: ##.....::: ##::: ##::");
            Console.WriteLine("\t\t\t::: ##:::: ##:::::::: ##:. ##::::: ##::::::: ##::. ##:: ##:::::::: ##::: ##::");
            Console.WriteLine("\t\t\t::: ##:::: ########: ##:::. ##:::: ##::::::: ##:::. ##: ##::::::::. ######:::");
            Console.WriteLine("\t\t\t:::..:::::........::..:::::..:::::..::::::::..:::::..::..::::::::::......::::");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.CursorVisible = false;
            AnyKey();
            Console.ReadKey(true);
            stopTitle = true;
            Task.Delay(1000).Wait();
            Console.CursorVisible = true;
        }



        private async void AnyKey()
        {
            while (true)
            {
                Console.SetCursorPosition(110/2, 20);
                Console.Write("Press Any Key");
                await Task.Delay(1000);          //유지되는 기간
                clearCurrentLine();
                await Task.Delay(500);          //사라졌을 때 기간
                if (stopTitle) { break; }
            }
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
