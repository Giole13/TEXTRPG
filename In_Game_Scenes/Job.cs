using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.In_Game_Scenes
{
    //직업 클래스
    public class Job
    {
        public string _name;
    }

    //의사
    public class Doctor : Job
    {
        public Doctor()
        {
            _name = "의사";

        }
    }

    //군인
    public class Soldier : Job
    {
        public Soldier()
        {
            _name = "군인";

        }
    }

    //사장
    public class Ceo : Job
    {
        public Ceo()
        {
            _name = "사장";

        }
    }
}
