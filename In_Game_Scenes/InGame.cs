using System;
using TextRpg.Explore_Scene;
using TextRpg.Game_Object;
using TextRpg.Store_Scene;
using TextRpg.WareHouse_Scene;

namespace TextRpg.In_Game_Scenes
{
    //인게임 안에서 무한 반복할 클래스임.
    internal class InGame
    {
        //인게임에 들어오면 실행됨
        public InGame()
        {
            Progress();
        }

        //전체적으로 진행하는 함수 - 기지씬
        public void Progress()
        {
            while (true)
            {
                bool gameover = false;

                Console.Clear();
                HomeBase homebase = new HomeBase();
                homebase.PrintBase();
                ConsoleKeyInfo num = homebase.SelectScenes();


                switch (num.Key)
                {
                    case ConsoleKey.D1:
                        //탐색
                        new Explore();
                        break;
                    case ConsoleKey.D2:
                        //창고
                        new WareHouse();
                        break;
                    case ConsoleKey.D3:
                        //상점
                        new Store();
                        break;
                    case ConsoleKey.D4:
                        //조합
                        new Combination();
                        break;
                    case ConsoleKey.Escape:
                        //게임종료
                        gameover = true;
                        break;
                    default:
                        break;
                }
                //기지로 돌아오면 체력회복
                Player._presentHp = Player._maxHp;

                if (gameover)
                {
                    Console.WriteLine("\nㅁ게임을 종료하였습니다.");
                    break;
                }

            }       // loop: 게임오버 전까지 씬들을 돌아다니며 게임을 하는 중!

        }



    }






}
