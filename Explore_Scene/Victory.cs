﻿using System;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    public class Victory
    {
        Monster _monster;
        string monsterItem;


        public Victory(Monster monster)
        {
            Console.Clear();
            _monster = monster;
            WinResult();
            Console.ReadKey();
        }

        public void WinResult()
        {
            monsterItem = _monster.RandomeItem();
            Item item = Item.allItem[monsterItem];
            AddItemInventory(item);
            //경험치랑 돈 얻는 함수도 추가
            AddExp(_monster);
            AddMoney(_monster);

            Player.PrintPlayerInfo();
            Console.WriteLine("===================");
            //몬스터 싸운 결과물 출력
            Console.WriteLine("당신은 이겼습니다!");
            Console.WriteLine("{0}를 획득하였습니다!", monsterItem);
            Console.WriteLine("===================");
            new ShowInventory();
            


        }

        //중복이라면 아이템 개수를 +1
        private void AddItemInventory(Item item)
        {
            if (Player.inventory.ContainsKey(monsterItem))
            {
                item.ItemStackPlus();
                item.ItemPreStackPlus();
            }
            else
            {
                Player.inventory.Add(monsterItem, item);
                item.ItemPreStackPlus();
            }
        }

        private void AddExp(Monster _monster)
        {
            Player._presentExp +=  _monster.ReturnExp();

        }

        private void AddMoney(Monster _monster)
        {
            Player.MoneyPlus(_monster.ReturnMoney());
        }
    }
}
