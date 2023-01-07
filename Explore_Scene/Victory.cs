using System;
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
            Console.WriteLine("당신은 이겼습니다!");
            Console.WriteLine("{0}를 획득하였습니다!", monsterItem);
            Item item = Item.allItem[monsterItem];
            AddItemInventory(item);
            //++item.itemStack;


            //인벤토리 보여주는 창
            Console.WriteLine("{0} 의 개수 : {1}", monsterItem, item.itemStack);

            foreach (var value in Player.inventory)
            {
                Console.WriteLine(value.Key);
            }



        }

        //중복이라면 아이템 개수를 +1
        private void AddItemInventory(Item item)
        {
            if (Player.inventory.ContainsKey(monsterItem))
            {
                ++item.itemStack;
            }
            else
            {
                Player.inventory.Add(monsterItem, item);
            }
        }
    }
}
