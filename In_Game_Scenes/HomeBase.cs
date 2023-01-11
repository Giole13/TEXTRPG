using System;
using TextRpg.Game_Object;

namespace TextRpg.In_Game_Scenes
{
    // 여기는 내 기지에서의 상호작용
    public class HomeBase
    {
        public HomeBase()
        {
            //기지로 돌아오면 체력 회복
            Player._presentHp = Player._maxHp;
        }
        //기지에서 가고싶은 씬의 종류를 출력해 주는 함수
        public void PrintBase()
        {
            Player.PrintPlayerInfo();
            Textmanager.TitleWindow();
            Textmanager.InventoryWindow();
            Textmanager.EventInfo();
            Console.SetCursorPosition(15, 5);
            Console.Write("1. 탐색");
            Console.SetCursorPosition(30, 5);
            Console.Write("2. 창고");
            Console.SetCursorPosition(15, 8);
            Console.Write("3. 상점");
            Console.SetCursorPosition(30, 8);
            Console.Write("4. 조합");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("ESC. 게임 종료");

            //Console.SetCursorPosition(0, 15);
        }

        //1~4까지 입력 받는 걸 반환하는 함수
        public ConsoleKeyInfo SelectScenes()
        {
            ConsoleKeyInfo result = Console.ReadKey();
            return result;
        }


    }


}
