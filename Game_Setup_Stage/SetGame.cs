using System.Collections.Generic;
using TextRpg.Game_Object;
using TextRpg.WareHouse_Scene;

namespace TextRpg.Game_Setup_Stage
{
    //게임 초반 설정 씬 및 초기화
    public class SetGame
    {

        //타이틀을 불러오는 씬
        public SetGame()
        {
            Title title = new Title();
            Start();
        }


        private void Start()
        {
            //이름 생성 씬
            new NameSetting();

            //직업 선택 씬
            JobSetting setJob = new JobSetting();

            //플레이어의 스탯 초기화
            Player.SetPlayerStat();

            //아이템 딕셔너리 초기화
            new SetItem();

            //창고 딕셔너리 초기화
            new WareHouseDic();
        }
    }
}
