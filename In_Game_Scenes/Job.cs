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
}
