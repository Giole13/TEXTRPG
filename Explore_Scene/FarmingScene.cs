using System;
using System.Collections.Generic;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    public class FarmingScene
    {
        //30퍼센트 확률로 아이템을 얻을수 있는 파밍 씬
        public FarmingScene()
        {
            FarmingSceneProgress();
        }

        private void FarmingSceneProgress()
        {
            Console.Clear();
            Player.PrintPlayerInfo();
            Console.WriteLine("====================");
            Random rand = new Random();
            List<string> itemList = new List<string>();
            //아이템 랜덤으로 하나 뽑아서 출력 (이건 파밍 템으로 가자)
            foreach(string item in Item.farmingItem.Keys)
            {
                itemList.Add(item);
            }

            string farmingItem = itemList[rand.Next(0, 2)];
            Console.WriteLine("{0} 아이템을 획득하였습니다!", farmingItem);
            Console.ReadKey();
            Item farmingItemclass = Item.farmingItem[farmingItem];

            if (Player.inventory.ContainsKey(farmingItem))
            {
                farmingItemclass.ItemStackPlus();
                farmingItemclass.ItemPreStackPlus();
            }
            else
            {
                Player.inventory.Add(farmingItem, farmingItemclass);
                farmingItemclass.ItemPreStackPlus();
            }



        }
    }
}
