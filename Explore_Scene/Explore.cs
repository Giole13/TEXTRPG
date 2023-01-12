using System;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    // 탐색 씬: 탐색이나 기지로 되돌아 갈 수 있는 선택지 씬
    public class Explore
    {
        ConsoleKeyInfo cki;
        //전 씬으로 돌아 가는 변수
        private int bossCount;
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
                Textmanager.ExploreWindow();
                
                ShowExplore();
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        //랜덤으로 전투나 파밍 씬으로 넘겨주는 함수 -> 도망친다는 선택지를 고르면
                        //backScene에 bool 형으로 반환하기
                        RandomMoveScene();
                        break;
                    case ConsoleKey.Escape:
                        //기지로 돌아가기
                        return;
                    default:
                        break;
                }
            }
        }

        //탐색씬 출력 함수
        

        private void ShowExplore()
        {
            Console.WriteLine("현재 탐색 회수 : {0}",bossCount);
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1 탐색하기\tESC 돌아가기");
        }

        


        //전투나 파밍으로 랜덤으로 보내주는 함수
        private void RandomMoveScene()
        {
            Random rand = new Random();
            //랜덤한 확률로 이동하는 방식
            int num = rand.Next(1, 100 + 1);
            if (num > 30 || (bossCount%10 == 0))
            {   //70퍼센트 확률로 전투
                new BattleScene(bossCount);
                ++bossCount;
            }
            else
            {   //30퍼센트 확률로 파밍
                new FarmingScene(bossCount);
                ++bossCount;
            }

        }


    }       //  class Explore


}
