using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.In_Game_Scenes
{
    // 여기는 내 기지 씬
    public class HomeBase
    {
        //기지에서 가고싶은 씬의 종류를 출력해 주는 함수
        public void PrintBase()
        {
            Console.WriteLine("1. 탐색\t2. 창고\n3. 상점\t4. 조합\n-1. 게임 종료");
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
