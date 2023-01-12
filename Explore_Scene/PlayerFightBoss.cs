using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Game_Object;
using TextRpg.In_Game_Scenes;

namespace TextRpg.Explore_Scene
{
    public class PlayerFightBoss
    {
        int bossCount;
        Monster boss;
        bool backScene = false;
        public PlayerFightBoss(int bossCountNum)
        {
            bossCount = bossCountNum;
            //보스전 씬
            PlaterFightBossProgress();
        }

        private void PlaterFightBossProgress()
        {
            SelectBoss();
            if (backScene) { return; }

            Textmanager.PopupInfo();
            Console.SetCursorPosition(55, 17);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            
            string i = "보스등장!!";
            foreach (char c in i)
            {
                Console.Write(c);
                Task.Delay(600).Wait();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Task.Delay(1000).Wait();
            while (true)
            {
                //여기에 보스전 띄우기
                Textmanager.ExploreWindow();
                boss.PrintEnemyInfo();


                PlayerTurn();
                Console.ReadKey(true);

                BossTurn();
                Console.ReadKey(true);

                if (boss.hp <= 0)
                {
                    //플레이어의 승리 결과창으로
                    new Victory(boss);
                    break;
                }
                else if (Player._presentHp < 0)
                {
                    Console.SetCursorPosition(0, 2);  //왼쪽위
                    Console.Write("ㅇ");
                    Textmanager.PopupInfo();
                    Console.SetCursorPosition(55, 17);  //왼쪽위
                    Console.WriteLine("- 사 망 -");
                    Console.SetCursorPosition(0, 0);  //왼쪽위
                    Environment.Exit(0);
                }
            }
        }

        //전투 횟수에 따라 보스 결정
        private void SelectBoss()
        {
            //10번째 마다
            if ((bossCount % 10) == 0)
            {
                if (new MonsterSet().bossList.Count < bossCount / 10)
                {
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("아직 보스가 안나왔어요 ㅠ");
                    Console.ReadKey(true);
                    backScene = true;
                    return;
                }
                //10번 전투후 나오는 보스
                boss = new MonsterSet().bossList[bossCount / 10 - 1];
            }
            else { /*Do nothing*/}
        }

        int skillCnt = 3;
        //플레이어 턴
        private void PlayerTurn()
        {
            //Textmanager.SetWindow();
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1 공격\t2 스킬");
            Console.SetCursorPosition(0, 2);
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    PlayerAttack();
                    break;
                case ConsoleKey.D2:
                    new PlayerSkill(ref boss, ref skillCnt);
                    break;
                default:
                    break;

            }
        }


        private void PlayerAttack()
        {
            Textmanager.SetWindow();
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                Player.GetPlayerName(), boss.GetMonsterName());
            boss.hp -= Player._attack;
        }


        //보스의 공격
        private void BossTurn()
        {
            Textmanager.SetWindow();
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                 boss.GetMonsterName(), Player.GetPlayerName());
            Player._presentHp -= boss.attack;
        }
    }
}
