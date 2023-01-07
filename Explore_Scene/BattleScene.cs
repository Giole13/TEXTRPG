using System;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    // 전투 씬: 랜덤하게 몬스터, 보스를 등장시는 클래스
    public class BattleScene
    {
        private Monster _MONSTER;

        public BattleScene()
        {
            BattleSystem();
        }

        // 전투 씬에서의 전체 흐름
        public void BattleSystem()
        {
            SearchEnemey();     //적 설정


            //적과 배틀
            new PlayerFightMonster(_MONSTER);


        }

        // 적을 찾는 함수
        public void SearchEnemey()
        {
            Random randmonster = new Random();
            //1부터 3까지 랜덤으로 몬스터 결정
            int monserNum = randmonster.Next(1, 3 + 1);

            switch (monserNum)
            {
                case 1:
                    _MONSTER = new ArmedGroup();
                    break;
                case 2:
                    _MONSTER = new WildDog();
                    break;
                case 3:
                    _MONSTER = new RatsPawns();
                    break;
                default:
                    break;
            }

        }


    }
}
