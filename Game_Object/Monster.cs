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
        protected string[] item;


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
        public void ShowAttack()
        {
            Console.Write(this.attack);
        }

        //HP를 보여주는 함수
        public void ShowHp()
        {
            Console.Write(this.hp);
        }

        //이름을 반환 하는 함수
        public string GetMonsterName()
        {
            return this.name;
        }

        //레벨을 보여주는 함수
        public void ShowLevel()
        {
            Console.Write(this.level);
        }

        // 적의 정보를 출력하는 함수
        public void PrintEnemyInfo()
        {
            ShowHp();
            Console.WriteLine(this.name);
            ShowLevel();
            ShowAttack();
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

        }
    }
}