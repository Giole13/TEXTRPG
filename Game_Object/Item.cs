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



            //이하 용도별 아이템 딕셔너리
            Item.farmingItem.Add("푸른 약초", new GreenHerbs());
            Item.farmingItem.Add("수상한 버섯", new Mushrooms());

            Item.equipmentItem.Add("모자", new Hat1());
            Item.equipmentItem.Add("가죽바지", new leatherpants());

            Item.combiItem.Add("단단한 단검", new SimpleDagger());
            Item.combiItem.Add("붉은 너클", new RedKnuckle());
            Item.combiItem.Add("권총", new Pistol());


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
            this.price = 30;
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


    #endregion


}
