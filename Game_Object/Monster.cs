using System;
using System.Collections.Generic;
using System.Threading;
using TextRpg.In_Game_Scenes;

namespace TextRpg.Game_Object
{
    // 몬스터의 특징을 담은 객체
    public class Monster
    {

        public int hp;
        public int maxhp;
        public string name = "";
        public int experienceValue;      //경험치
        public int level;
        public int attack;
        public string[] item;
        public int haveMoney;
        public bool boss = false;

        //데미지를 반환하는 함수
        public int ReturnAttack()
        {
            return this.attack;
        }

        //경험치를 반환하는 함수
        public int ReturnExp()
        {
            return this.experienceValue;
        }

        //돈 반환
        public int ReturnMoney()
        {
            return this.haveMoney;
        }

        //HP를 보여주는 함수
        //public void ShowHp()
        //{
        //    Console.Write(this.hp);
        //}

        //이름을 반환 하는 함수
        public string GetMonsterName()
        {
            return this.name;
        }

        //레벨을 보여주는 함수
        //public void ShowLevel()
        //{
        //    Console.Write(this.level);
        //}

        // 적의 정보를 출력하는 함수
        public void PrintEnemyInfo()
        {

            Console.SetCursorPosition(62, 29);
            Console.Write("┌─  몬스터 스탯 ─────────────────────────────────────────┐\n");
            Console.SetCursorPosition(62, 30);
            Console.Write("  이름\t: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(this.name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.SetCursorPosition(62, 31);
            Console.Write("  레벨\t: {0}\t\t공격력\t: {1}\n", this.level, this.attack);
            Console.SetCursorPosition(62, 32);
            Console.Write("  체력\t: {0} / {1}\n", this.hp, this.maxhp);
            VerticalLine();
            Console.SetCursorPosition(62, 38);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");



            Console.SetCursorPosition(2, 2);
        }

        private void VerticalLine()
        {
            for (int i = 0; i < 8; ++i)
            {
                Console.SetCursorPosition(62, i + 30);
                Console.Write("│");
                Console.SetCursorPosition(119, i + 30);
                Console.Write("│");

            }
        }

        //배열아이템을 반환함
        public string RandomeItem()
        {
            Random rand = new Random();
            string result = this.item[rand.Next(0, this.item.Length)];
            return result;
        }
    }

    //몬스터 리스트 초기화
    public class MonsterSet
    {
        public List<Monster> monsterList = new List<Monster>();
        public List<Monster> bossList = new List<Monster>();

        public MonsterSet()
        {
            monsterList.Add(new ArmedGroup());
            monsterList.Add(new WildDog());
            monsterList.Add(new RatsPawns());
            monsterList.Add(new Hunter());

            //첫번째 부터 10번째 진행부터 등장함
            bossList.Add(new QueenOfRats());
            bossList.Add(new ScaryPerson());
            bossList.Add(new MrBreadEnvelope());
            bossList.Add(new RealMan());
            bossList.Add(new RealWoman());
        }


    }
    #region 일반 몬스터
    public class ArmedGroup : Monster
    {
        public ArmedGroup()
        {
            this.hp = this.maxhp = 200;
            this.name = "무장집단";
            this.experienceValue = 20;       //경험치
            this.level = 2;
            this.attack = 30;
            this.item = new string[] { "천 조각", "무기 부품" };
            this.haveMoney = 100;
        }
    }

    public class Hunter : Monster
    {
        public Hunter()
        {
            this.hp = this.maxhp = 300;
            this.name = "사냥꾼";
            this.experienceValue = 30;       //경험치
            this.level = 3;
            this.attack = 40;
            this.item = new string[] { "라이터", "망가진 권총" };
            this.haveMoney = 120;
        }
    }

    public class WildDog : Monster
    {
        public WildDog()
        {
            this.hp = this.maxhp = 80;
            this.name = "야생 들개";
            this.experienceValue = 10;       //경험치
            this.level = 1;
            this.attack = 15;
            this.item = new string[] { "들개의 송곳니", "털 갈퀴" };
            this.haveMoney = 50;
        }
    }

    public class RatsPawns : Monster
    {
        public RatsPawns()
        {
            this.hp = this.maxhp = 50;
            this.name = "랫의 졸개";
            this.experienceValue = 8;       //경험치
            this.level = 1;
            this.attack = 10;
            this.item = new string[] { "랫의 증표", "두꺼운 가죽" };
            this.haveMoney = 200;
        }
    }
    #endregion

    #region 보스라인
    public class QueenOfRats : Monster
    {
        //랫의 여왕 보스
        public QueenOfRats()
        {
            this.boss = true;
            this.hp = this.maxhp = 1000;
            this.name = "랫의 여왕";
            this.experienceValue = 500;       //경험치
            this.level = 5;
            this.attack = 100;
            this.item = new string[] { "랫의 증표", "여왕의 페도라", "황금 반지" };
            this.haveMoney = 500;
        }
    }

    public class ScaryPerson : Monster
    {
        //무서운 사람
        public ScaryPerson()
        {
            this.boss = true;
            this.hp = this.maxhp = 2000;
            this.name = "무서운 사람";
            this.experienceValue = 800;       //경험치
            this.level = 9;
            this.attack = 300;
            this.item = new string[] { "귀여운 인형", "깜찍한 인형" };
            this.haveMoney = 1000;
        }
    }
    public class MrBreadEnvelope : Monster
    {
        //빵 봉투 아저씨
        public MrBreadEnvelope()
        {
            this.boss = true;
            this.hp = this.maxhp = 3000;
            this.name = "빵 봉투 아저씨";
            this.experienceValue = 1000;       //경험치
            this.level = 23;
            this.attack = 500;
            this.item = new string[] { "무거운 대검", "우유", "권총" };
            this.haveMoney = 2000;
        }
    }

    public class RealMan : Monster
    {
        //상남자
        public RealMan()
        {
            this.boss = true;
            this.hp = this.maxhp = 5500;
            this.name = "상남자";
            this.experienceValue = 1500;       //경험치
            this.level = 35;
            this.attack = 700;
            this.item = new string[] { "수박", "동전", "그래픽 카드" };
            this.haveMoney = 4000;
        }
    }

    public class RealWoman : Monster
    {
        //상남자
        public RealWoman()
        {
            this.boss = true;
            this.hp = this.maxhp = 8000;
            this.name = "상여자";
            this.experienceValue = 1500;       //경험치
            this.level = 40;
            this.attack = 600;
            this.item = new string[] { "푸른 단검", "동전", "립스틱" };
            this.haveMoney = 4000;
        }
    }
    #endregion

}