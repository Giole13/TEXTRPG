using System;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    // 전투 씬: 랜덤하게 몬스터, 보스를 결정하는 클래스
    public class BattleScene
    {
        private int bossCount;
        private Monster _MONSTER;

        public BattleScene(int bossCnt)
        {
            this.bossCount = bossCnt;
            BattleSystem();
        }

        // 전투 씬에서의 전체 흐름
        public void BattleSystem()
        {
            if (bossCount == 10)    //10번 전투 달성시 랫의 여왕 등장
            {
                //boss배틀
                new PlayerFightBoss(bossCount);
            }
            else { /*Do noting*/}

            SearchEnemey();     //적 설정
            //적과 배틀
            new PlayerFightMonster(_MONSTER, bossCount);
            

        }

        // 적을 찾는 함수
        public void SearchEnemey()
        {
            MonsterSet mList = new MonsterSet();

            Random randmonster = new Random();
            //랜덤으로 몬스터 결정
            _MONSTER = mList.monsterList[randmonster.Next(0, mList.monsterList.Count)];
        }
    }
}
