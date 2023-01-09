﻿using System.Collections.Generic;

namespace TextRpg.Game_Object
{
    public class Item
    {
        static public Dictionary<string, Item> allItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> equipmentItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> combiItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> farmingItem = new Dictionary<string, Item>();
        static public Dictionary<string, Item> bossItem = new Dictionary<string, Item>();


        //아이템 스택
        private int itemStack = 1;  //아이템의 전체 스택
        private int presentStack; //아이템의 현재 스택
        public int plusHp;
        public int price;
        public int attackPower;
        public string[] needCombiItem;



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
            //Item.allItem.Add("천 조각", new ClothPiece());
            Item.allItem.Add("천 조각", new ClothPiece());
            Item.allItem.Add("무기 부품", new WeaponParts());
            Item.allItem.Add("들개의 송곳니", new dogsFangs());
            Item.allItem.Add("털 갈퀴", new FurRake());
            Item.allItem.Add("랫의 증표", new RatToken());
            Item.allItem.Add("두꺼운 가죽", new ThickLetter());

            Item.farmingItem.Add("푸른 약초", new GreenHerbs());
            Item.farmingItem.Add("수상한 버섯", new Mushrooms());
            
            Item.equipmentItem.Add("모자", new Hat1());
            Item.equipmentItem.Add("가죽바지", new leatherpants());

            Item.bossItem.Add("여왕의 페도라", new QueensFedora());
            Item.bossItem.Add("황금 반지", new GoldRing());
            

            Item.combiItem.Add("단단한 단검", new SimpleDagger());
            Item.combiItem.Add("붉은 너클", new RedKnuckle());


        }


    }

    #region 드랍 아이템 (몬스터)
    public class ClothPiece : Item { }
    public class WeaponParts : Item { }
    public class dogsFangs : Item { }
    public class FurRake : Item { }
    public class RatToken : Item { }
    public class ThickLetter : Item { }

    #endregion 드랍아이템

    #region 드랍 아이템 (보스)
    public class QueensFedora : Item
    {
        public QueensFedora()
        {
            this.plusHp = 1000;
        }
    }

    public class GoldRing : Item
    {
        public GoldRing()
        {
            this.plusHp = 500;
        }
    }
    #endregion

    #region 파밍 아이템 (탐색 파밍)
    public class GreenHerbs : Item { }

    public class Mushrooms : Item { }
    #endregion




    #region 장비아이템 상점 전용
    public class Hat1 : Item
    {
        //모자 속성
        public Hat1()
        {
            this.plusHp = 100;
            this.price = 300;
        }
    }

    public class leatherpants : Item
    {
        public leatherpants()
        {
            this.plusHp = 200;
            this.price = 500;
        }
    }


    #endregion

    #region 장비아이템 조합전용
    public class SimpleDagger : Item
    {
        public SimpleDagger()
        {
            this.attackPower = 30;
            this.needCombiItem = new string[2] { "무기 부품", "들개의 송곳니" };
        }
    }

    public class RedKnuckle : Item
    {
        public RedKnuckle()
        {
            this.attackPower = 50;
            this.needCombiItem = new string[3] { "무기 부품", "랫의 증표", "두꺼운 가죽" };
        }
    }


    #endregion


}
