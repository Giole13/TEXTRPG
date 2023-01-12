using System.Collections.Generic;

namespace TextRpg.Game_Object
{
    public class Item
    {
        static public Dictionary<string, Item> allItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> equipmentItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> combiItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> farmingItem = new Dictionary<string, Item>();


        //아이템 스택
        private int itemStack = 1;  //아이템의 전체 스택
        private int presentStack; //아이템의 현재 스택
        public int plusHp;
        public int price;
        public int attackPower;
        public string[] needCombiItem;  //조합시 필요한 아이템 배열
        public bool equipment = false;  //장비아이템 분류 여부
        public bool mountItem = false;



        //현재 아이템 스택을 반환하는 함수 -> 인벤토리용
        public int ReturnItemStack()
        {
            return this.presentStack;
        }

        //아이템 전체 개수를 반환하는 함수 -> 창고용
        public int ReturnAllItemStack()
        {
            return this.itemStack;
        }

        //현재 개수 하나를 올려주는 함수
        public void ItemPreStackPlus()
        {
            ++this.presentStack;
        }

        //현재 아이템 스택을 초기화하는 구문
        public void ResetStack()
        {
            this.presentStack = 0;
        }

        //아이템 스택 하나를 올려주는 함수
        public void ItemStackPlus()
        {
            ++this.itemStack;
        }
    }

    public class SetItem
    {
        public SetItem()
        {
            SetItems();
        }
        private void SetItems()
        {
            //allItem.Add
            Item.allItem.Add("천 조각", new ClothPiece());
            Item.allItem.Add("무기 부품", new WeaponParts());
            Item.allItem.Add("들개의 송곳니", new dogsFangs());
            Item.allItem.Add("털 갈퀴", new FurRake());
            Item.allItem.Add("랫의 증표", new RatToken());
            Item.allItem.Add("두꺼운 가죽", new ThickLetter());
            Item.allItem.Add("푸른 약초", new GreenHerbs());
            Item.allItem.Add("수상한 버섯", new Mushrooms());
            Item.allItem.Add("모자", new Hat1());
            Item.allItem.Add("가죽바지", new leatherpants());
            Item.allItem.Add("여왕의 페도라", new QueensFedora());
            Item.allItem.Add("황금 반지", new GoldRing());
            Item.allItem.Add("단단한 단검", new SimpleDagger());
            Item.allItem.Add("붉은 너클", new RedKnuckle());
            Item.allItem.Add("라이터", new Lighter());
            Item.allItem.Add("망가진 권총", new BrokenPistol());
            Item.allItem.Add("권총", new Pistol());
            Item.allItem.Add("푸른 단검", new BlueKnife());
            Item.allItem.Add("랫여왕의 세트", new QueensSet());
            Item.allItem.Add("귀여운 인형", new CuteDoll());
            Item.allItem.Add("깜찍한 인형", new CuteDoll());
            Item.allItem.Add("석궁", new CrossBow());
            Item.allItem.Add("깜직하고 귀여운 석궁", new CuteCrossBow());
            Item.allItem.Add("무거운 대검", new HeavySword());
            Item.allItem.Add("우유", new Milk());
            Item.allItem.Add("껌", new Gum());
            Item.allItem.Add("우유와 껌이 나가는 총", new GumMilkGun());
            Item.allItem.Add("황금 지팡이", new GoldStick());
            Item.allItem.Add("망치", new Hammer());
            Item.allItem.Add("수박", new WaterMelon());
            Item.allItem.Add("동전", new Tokken());
            Item.allItem.Add("그래픽 카드", new GraphcCard());
            Item.allItem.Add("립스틱", new Lipstick());



            //이하 용도별 아이템 딕셔너리
            Item.farmingItem.Add("푸른 약초", new GreenHerbs());
            Item.farmingItem.Add("수상한 버섯", new Mushrooms());
            Item.farmingItem.Add("껌", new Gum());

            Item.equipmentItem.Add("모자", new Hat1());
            Item.equipmentItem.Add("가죽바지", new leatherpants());
            Item.equipmentItem.Add("석궁", new CrossBow());
            Item.equipmentItem.Add("망치", new Hammer());
            Item.equipmentItem.Add("황금 지팡이", new GoldStick());
            Item.equipmentItem.Add("수박", new WaterMelon());

            Item.combiItem.Add("단단한 단검", new SimpleDagger());
            Item.combiItem.Add("붉은 너클", new RedKnuckle());
            Item.combiItem.Add("푸른 단검", new BlueKnife());
            Item.combiItem.Add("랫여왕의 세트", new QueensSet());
            Item.combiItem.Add("권총", new Pistol());
            Item.combiItem.Add("깜직하고 귀여운 석궁", new CuteCrossBow());
            Item.combiItem.Add("우유와 껌이 나가는 총", new GumMilkGun());

            

        }


    }

    #region 드랍 아이템 (몬스터)
    public class ClothPiece : Item
    {
        public ClothPiece()
        {
            this.price = 10;
        }

    }
    public class WeaponParts : Item
    {
        public WeaponParts()
        {
            this.price = 50;
        }
    }
    public class dogsFangs : Item {
        public dogsFangs()
        {
            this.price = 50;
        }
    }
    public class FurRake : Item {
        public FurRake()
        {
            this.price = 50;
        }
    }
    public class RatToken : Item {
        public RatToken()
        {
            this.price = 50;
        }
    }
    public class ThickLetter : Item {
        public ThickLetter()
        {
            this.price = 60;
        }
    }

    public class Lighter : Item
    {
        public Lighter()
        {
            this.price = 70;
        }
    }

    public class BrokenPistol : Item
    {
        public BrokenPistol()
        {
            this.price = 200;
        }
    }



    #endregion 드랍아이템

    #region 드랍 아이템 (보스)
    public class QueensFedora : Item
    {
        public QueensFedora()
        {
            this.price = 1000;
            this.plusHp = 1000;
            this.equipment = true;
        }
    }

    public class GoldRing : Item
    {
        public GoldRing()
        {
            this.price = 500;
            this.plusHp = 500;
            this.equipment = true;
        }
    }
    public class CuteDoll : Item
    {
        public CuteDoll()
        {
            this.price = 800;
        }
    }
    public class CuteDoll2 : Item
    {
        public CuteDoll2()
        {
            this.price = 800;
        }
    }
    public class HeavySword : Item
    {
        public HeavySword()
        {
            this.price = 800;
            this.attackPower = 900;
            this.equipment = true;
        }
    }
    public class Milk : Item
    {
        public Milk()
        {
            this.price = 3000;
        }
    }

    public class Tokken : Item
    {
        public Tokken()
        {
            this.price = 2000;
        }
    }
    public class GraphcCard : Item
    {
        public GraphcCard()
        {
            this.price = 5000;
        }
    }
    public class Lipstick : Item
    {
        public Lipstick()
        {
            this.price = 5000;
        }
    }


    #endregion

    #region 파밍 아이템 (탐색 파밍)
    public class GreenHerbs : Item {
        public GreenHerbs()
        {
            this.price = 40;
        }
    }

    public class Mushrooms : Item {
        public Mushrooms()
        {
            this.price = 100;
        }
    }

    public class Gum : Item
    {
        public Gum()
        {
            this.price = 80;
        }
    }
    #endregion

    #region 장비아이템 상점 전용
    public class Hat1 : Item
    {
        //모자 속성
        public Hat1()
        {
            this.plusHp = 100;
            this.price = 300;
            this.equipment = true;
        }
    }
    public class leatherpants : Item
    {
        public leatherpants()
        {
            this.plusHp = 200;
            this.price = 500;
            this.equipment = true;
        }
    }
    public class CrossBow : Item
    {
        public CrossBow()
        {
            this.attackPower = 200;
            this.price = 1500;
            this.equipment = true;
        }
    }
    public class Hammer : Item
    {
        public Hammer()
        {
            this.attackPower = 1500;
            this.price = 5000;
            this.equipment = true;
        }
    }
    public class WaterMelon : Item
    {
        public WaterMelon()
        {
            this.price = 8000;
        }
    }

    public class GoldStick : Item
    {
        public GoldStick()
        {
            this.attackPower = 10000;
            this.price = 95000;
            this.equipment = true;
        }
    }



    #endregion

    #region 장비아이템 조합전용
    public class SimpleDagger : Item
    {
        public SimpleDagger()
        {
            this.price = 100;
            this.attackPower = 30;
            this.needCombiItem = new string[2] { "무기 부품", "들개의 송곳니" };
            this.equipment = true;
        }
    }

    public class RedKnuckle : Item
    {
        public RedKnuckle()
        {
            this.price = 200;
            this.attackPower = 50;
            this.needCombiItem = new string[3] { "무기 부품", "랫의 증표", "두꺼운 가죽" };
            this.equipment = true;
        }
    }

    public class Pistol : Item
    {
        public Pistol()
        {
            this.price = 500;
            this.attackPower = 130;
            this.needCombiItem = new string[3] { "무기 부품", "망가진 권총", "털 갈퀴" };
            this.equipment = true;
        }
    }

    public class BlueKnife : Item
    {
        public BlueKnife()
        {
            this.price = 400;
            this.attackPower = 500;
            this.needCombiItem = new string[3] { "단단한 단검", "푸른 약초", "라이터" };
            this.equipment = true;
        }
    }

    public class QueensSet : Item
    {
        public QueensSet()
        {
            this.price = 1500;
            this.attackPower = 900;
            this.plusHp = 1000;
            this.needCombiItem = new string[3] { "여왕의 페도라", "푸른 단검", "황금 반지" };
            this.equipment = true;
        }
    }

    public class CuteCrossBow : Item
    {
        public CuteCrossBow()
        {
            this.price = 1800;
            this.attackPower = 1500;
            this.needCombiItem = new string[3] { "귀여운 인형", "깜직한 인형", "석궁" };
            this.equipment = true;
        }
    }

    public class GumMilkGun : Item
    {
        public GumMilkGun()
        {
            this.price = 2800;
            this.attackPower = 1400;
            this.needCombiItem = new string[3] { "껌", "우유", "권총" };
            this.equipment = true;
        }
    }

    #endregion


}
