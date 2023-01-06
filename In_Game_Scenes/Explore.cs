using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.In_Game_Scenes
{
    // 탐색 씬: 탐색이나 기지로 되돌아 갈 수 있는 선택지 씬
    public class Explore
    {
        //전 씬으로 돌아 가는 변수
        private bool backScene = false;
        
        public Explore()
        {
            ExploreProgress();
        }


        // 탐색의 전체적인 구조
        public void ExploreProgress()
        {
            //탐색 씬은 돌아가기 전까지 반복한다.
            while (true)
            {
                ExplorePrint();
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        //랜덤으로 전투나 파밍 씬으로 넘겨주는 함수 -> 도망친다는 선택지를 고르면
                        //backScene에 bool 형으로 반환하기
                        RandomMoveScene();
                        break;
                    case ConsoleKey.D2:
                        //기지로 돌아가기 -> 파밍한 것들을 결과로 보여주는 함수
                        backScene = true;
                        break;
                    default:
                        break;
                }

                //기지로 돌아가기
                if (backScene)
                {
                    break;
                }
            }
        }

        //탐색에서 할 것을 출력해주는 함수
        private void ExplorePrint()
        {
            Console.Clear();
            Console.WriteLine("1. 탐색하기\t2. 돌아가기");
        }

        //전투나 파밍으로 랜덤으로 보내주는 함수
        private void RandomMoveScene()
        {
            Random rand = new Random();
            //랜덤한 확률로 이동하는 방식
            int num = rand.Next(1, 100 + 1);
            if (num > 30)
            {   //70퍼센트 확률로 전투
                new BattleScene();
            }
            else
            {   //30퍼센트 확률로 파밍
                new FarmingScene();
            }

        }
    }       //  class Explore


}
