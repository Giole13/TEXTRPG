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
            bossCount = bossCountValue;
            _monster = monster;
            FightProgress();
        }

        //전투 진행
        private void FightProgress()
        {
            while (true)
            {
                Player.PrintPlayerInfo();    //플레이어 정보 프린트
                Textmanager.ExploreWindow();
                _monster.PrintEnemyInfo();   //적 정보 프린트
                Console.SetCursorPosition(2, 2);
                Console.WriteLine("현재 탐색 횟수 : {0}", bossCount);

                bool back = PlayerTurn();                //플레이어 턴
                if (back) { return; }

                Console.ReadKey(true);

                MonsterTurn();               //몬스터 턴
                if (_monster.hp <= 0)
                {
                    //플레이어의 승리 결과창으로
                    new Victory(_monster);
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


                Console.ReadKey(true);
            }

        }


        public int skillCnt = 3;
        //전투 함수
        private bool PlayerTurn()
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1 공격 2 스킬 ESC 도망");
            Console.SetCursorPosition(0, 3);
            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    PlayerAttack();
                    break;
                case ConsoleKey.D2:
                    new PlayerSkill(ref _monster, ref skillCnt);
                    break;
                case ConsoleKey.Escape:
                    return true;
                default:
                    break;
            }
            return false;
        }

        private void PlayerAttack()
        {
            Textmanager.SetWindow();
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                Player.GetPlayerName(), _monster.GetMonsterName());
            _monster.hp -= Player._attack;

        }

        private void MonsterTurn()
        {
            Textmanager.SetWindow();
            Console.WriteLine("{0} 이(가) {1}을(를) 공격했다!\n",
                 _monster.GetMonsterName(), Player.GetPlayerName());
            Player._presentHp -= _monster.attack;
        }



    }       //class PlayerFightMonster

    
}
