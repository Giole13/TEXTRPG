using System;
using System.Collections.Generic;
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
        public PlayerFightBoss(int bossCountNum)
        {
            bossCount = bossCountNum;
            //보스전 씬
            PlaterFightBossProgress();
        }

        private void PlaterFightBossProgress()
        {
            SelectBoss();

            while (true)
            {
                Console.Clear();
                Player.PrintPlayerInfo();    //플레이어 정보 프린트
                Console.WriteLine("====================");
                //여기에 보스전 띄우기
                boss.PrintEnemyInfo();
                Console.WriteLine("====================");
                PlayerTurn();
                Console.ReadKey();

                BossTurn();
                Console.ReadKey();

                if (boss.hp <= 0)
                {
                    //플레이어의 승리 결과창으로
                    new Victory(boss);
                    break;
                }
                else if (Player._presentHp < 0)
                {
                    Console.WriteLine("당신은 죽었습니다.");
                    Environment.Exit(0);
                }
            }
        }

        //전투 횟수에 따라 보스 결정
        private void SelectBoss()
        {
            if (bossCount == 10)
            {
                //10번 전투후 나오는 보스
                boss = new QueenOfRats();
            }
            else { /*Do nothing*/}
        }


        //플레이어 턴
        private void PlayerTurn()
        {
            Console.WriteLine("1. 공격\t2. 스킬");
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    PlayerAttack();
                    break;
                case ConsoleKey.D2:
                    new PlayerSkill(ref boss);
                    break;
                default:
                    break; 

            }
        }


        private void PlayerAttack()
        {
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                Player.GetPlayerName(), boss.GetMonsterName());
            boss.hp -= Player._attack;
        }


        //보스의 공격
        private void BossTurn()
        {
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                 boss.GetMonsterName(), Player.GetPlayerName());
            Player._presentHp -= boss.attack;
        }
    }
}
