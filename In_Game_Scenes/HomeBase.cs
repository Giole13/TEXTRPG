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
            Console.SetCursorPosition(2, 2);
            Console.Write("1 탐색");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("전투 및 파밍");
            Console.SetCursorPosition(31, 2);
            Console.Write("2 창고");
            Console.SetCursorPosition(31, 4);
            Console.WriteLine("장비 아이템 장착");
            Console.SetCursorPosition(2, 16);
            Console.Write("3 상점");
            Console.SetCursorPosition(2, 18);
            Console.WriteLine("아이템 구입 및 판매");
            Console.SetCursorPosition(31, 16);
            Console.Write("4 조합");
            Console.SetCursorPosition(31, 18);
            Console.WriteLine("아이템 조합");

            //Console.SetCursorPosition(15, 10);
            //Console.WriteLine("ESC. 게임 종료");

            //Console.SetCursorPosition(0, 15);
        }

        //1~4까지 입력 받는 걸 반환하는 함수
        public ConsoleKeyInfo SelectScenes()
        {
            ConsoleKeyInfo result = Console.ReadKey(true);
            return result;
        }


    }


}
