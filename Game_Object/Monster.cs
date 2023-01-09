using System;

namespace TextRpg.Game_Object
{
    // 몬스터의 특징을 담은 객체
    public class Monster
    {

        public int hp;
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
            Console.WriteLine("이름 : {0}", this.name);
            Console.WriteLine("레벨 : {0}", this.level);
            Console.WriteLine("공격력 : {0}", this.attack);
            Console.WriteLine("현재 체력 : {0}", this.hp);
        }

        //기본적으로 1, 2 번째 배열아이템을 반환함
        public string RandomeItem()
        {
            Random rand = new Random();
            string result = this.item[rand.Next(0, 1 + 1)];
            return result;
        }




    }

    public class ArmedGroup : Monster
    {
        public ArmedGroup()
        {
            this.hp = 200;
            this.name = "무장집단";
            this.experienceValue = 20;       //경험치
            this.level = 2;
            this.attack = 30;
            this.item = new string[] { "천 조각", "무기 부품" };
            this.haveMoney = 100;
        }
    }

    public class WildDog : Monster
    {
        public WildDog()
        {
            this.hp = 80;
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
            this.hp = 50;
            this.name = "랫의 졸개";
            this.experienceValue = 8;       //경험치
            this.level = 1;
            this.attack = 10;
            this.item = new string[] { "랫의 증표", "두꺼운 가죽" };
            this.haveMoney = 200;
        }
    }

    #region 보스라인
    public class QueenOfRats : Monster
    {
        //랫의 여왕 보스
        public QueenOfRats()
        {
            this.boss = true;
            this.hp = 1000;
            this.name = "랫의 여왕";
            this.experienceValue = 500;       //경험치
            this.level = 5;
            this.attack = 100;
            this.item = new string[] { "랫의 증표", "여왕의 페도라", "황금 반지" };
            this.haveMoney = 500;
        }
    }

    #endregion

}