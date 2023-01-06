using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Game_Object;
using TextRpg.In_Game_Scenes;

namespace TextRpg.Game_Setup_Stage
{
    //게임 초반 설정 씬
    internal class SetGame
    {
        //타이틀을 불러오는 씬
        public SetGame()
        {
            Title title = new Title();
            Start();
        }


        public void Start()
        {
            //이름 생성 씬
            new NameSetting();

            //직업 선택 씬
            JobSetting setJob = new JobSetting();

            //플레이어의 스탯 초기화
            Player.SetPlayerStat();




        }
    }
}
