using System;
using TextRpg.Game_Object;
using TextRpg.Game_Setup_Stage;
using TextRpg.In_Game_Scenes;

namespace TextRpg
{
    //가장 메인의 창!
    public class Program
    {

        static void Main(string[] args)
        {
            //디버그 모드
            //new Debug();
            //Console.SetWindowSize(121, 39);
            //Player.IamGod();
            //new Title();

            //정상적인 게임 초기 설정
            new SetGame();

            //인게임 진행
            InGame inGame = new InGame();
        }
    }
}