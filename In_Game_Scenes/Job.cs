using System;
using System.Threading;
using TextRpg.Game_Object;

namespace TextRpg.In_Game_Scenes
{
    //직업 클래스
    public class Job
    {
        public string _name;
        public bool _discount = false;

        public virtual int _jobSkill(int level)
        {
            return 0;
        }
    }

    //의사
    public class Doctor : Job
    {
        public Doctor()
        {
            _name = "의사";
        }

        //의사는 힐 스킬을 가지고 있음
        public override int _jobSkill(int level)
        {
            //힐 스킬
            return level*50;
        }


    }

    //군인
    public class Soldier : Job
    {
        public Soldier()
        {
            _name = "군인";
        }

        //공격 스킬
        public override int _jobSkill(int level)
        {
            return level * 30 + Player._attack;
        }
    }

    //사장
    public class Ceo : Job
    {
        //특별한 스킬이 없는 대신 상점할인 능력을 가지고 있음
        public Ceo()
        {
            _discount = true;
            _name = "사장";
        }
    }



    //스킬 구현
    public class PlayerSkill
    {
        public PlayerSkill(ref Monster monster)
        {
            PlayerSkills(ref monster);
        }

        private void PlayerSkills(ref Monster monster)
        {
            Console.WriteLine("{0} 이(가) 스킬을 사용했다!", Player.GetPlayerName());
            Job playerJob = Player.plsyerJob;
            switch (playerJob)
            {
                case Doctor:
                    //의사인 경우
                    int heal = playerJob._jobSkill(Player._level);
                    Player._presentHp += heal;
                    if (Player._presentHp > Player._maxHp)
                    {
                        Player._presentHp = Player._maxHp;
                    }
                    Console.WriteLine("{0} 만큼 치료 했다!", heal);
                    break;
                case Soldier:
                    //군인인 경우
                    int damage = playerJob._jobSkill(Player._level);
                    monster.hp -= damage;
                    Console.WriteLine("{0} 만큼 데미지를 줬다!", damage);
                    break;
                default:
                    Console.WriteLine("하지만 아무런 일도 일어나지 않았다.");
                    break;
            }
        }
    }
}
