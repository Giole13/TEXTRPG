using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Game_Object;

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

            Console.Clear();
            Player.PrintPlayerInfo();    //플레이어 정보 프린트
            Console.WriteLine("====================");
            //여기에 보스전 띄우기
            Console.WriteLine("====================");




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

        private void 
    }
}
