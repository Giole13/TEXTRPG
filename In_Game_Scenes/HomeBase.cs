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
            Console.WriteLine("1. 탐색\t2. 창고\n3. 상점\t4. 조합\nESC. 게임 종료");
        }

        //1~4까지 입력 받는 걸 반환하는 함수
        public ConsoleKeyInfo SelectScenes()
        {

            Console.Write("가고 싶은 곳을 선택해주세요 : ");
            ConsoleKeyInfo result = Console.ReadKey();
            return result;
        }


    }


}
