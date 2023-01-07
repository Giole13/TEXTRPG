using TextRpg.Game_Object;

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
            SetItem();

        }

        private void SetItem()
        {

            Item.allItem.Add("모자", new Hat1());
            Item.allItem.Add("천 조각", new ClothPiece());
            Item.allItem.Add("무기 부품", new WeaponParts());
            Item.allItem.Add("들개의 송곳니", new dogsFangs());
            Item.allItem.Add("털 갈퀴", new FurRake());
            Item.allItem.Add("랫의 증표", new RatToken());
            Item.allItem.Add("두꺼운 가죽", new ThickLetter());
        }
    }
}
