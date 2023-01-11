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
            // 게임 초기 설정
            // 플레이어 이름, 직업 설정
            //디버그
            //new Debug();
            //Console.SetWindowSize(130, 39);
            //Player.IamGod();



            new SetGame();
            //인게임 진행
            InGame inGame = new InGame();


        }
    }
}