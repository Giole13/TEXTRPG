using System;
using TextRpg.Game_Object;
using TextRpg.In_Game_Scenes;

namespace TextRpg.Explore_Scene
{
    //몬스터와 직접 싸우는 것을 출력하는 클래스
    public class PlayerFightMonster
    {
        private int bossCount;
        //몬스터 클래스
        private Monster _monster;
        


        public PlayerFightMonster(Monster monster, int bossCountValue)
        {
            bossCount = 10 - bossCountValue;
            _monster = monster;
            FightProgress();
        }

        //전투 진행
        private void FightProgress()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("보스 출현까지 {0} 회 남았습니다.", bossCount);
                Player.PrintPlayerInfo();    //플레이어 정보 프린트
                Console.WriteLine("====================");
                _monster.PrintEnemyInfo();   //적 정보 프린트
                Console.WriteLine("====================");

                bool back = PlayerTurn();                //플레이어 턴
                if (back) { return; }

                Console.ReadKey();

                MonsterTurn();               //몬스터 턴
                if (_monster.hp <= 0)
                {
                    //플레이어의 승리 결과창으로
                    new Victory(_monster);
                    break;
                }
                else if (Player._presentHp < 0)
                {
                    Console.WriteLine("당신은 죽었습니다.");
                    Environment.Exit(0);
                }


                Console.ReadKey();
            }

        }

        //전투 함수
        private bool PlayerTurn()
        {
            Console.WriteLine("1. 공격\t2. 스킬\t3. 도망");
            ConsoleKeyInfo cki = Console.ReadKey();

            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    PlayerAttack();
                    break;
                case ConsoleKey.D2:
                    new PlayerSkill(ref _monster);
                    break;
                case ConsoleKey.D3:
                    return true;
                default:
                    break;
            }
            return false;
        }

        private void PlayerAttack()
        {
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                Player.GetPlayerName(), _monster.GetMonsterName());
            _monster.hp -= Player._attack;

        }

        private void MonsterTurn()
        {
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                 _monster.GetMonsterName(), Player.GetPlayerName());
            Player._presentHp -= _monster.attack;
        }



    }       //class PlayerFightMonster

    
}
