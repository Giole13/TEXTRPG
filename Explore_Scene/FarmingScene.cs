using System;
using System.Collections.Generic;
using TextRpg.Game_Object;

namespace TextRpg.Explore_Scene
{
    public class FarmingScene
    {
        int bossCount;
        //30퍼센트 확률로 아이템을 얻을수 있는 파밍 씬
        public FarmingScene(int num)
        {
            bossCount = num;
            FarmingSceneProgress();
        }

        private void FarmingSceneProgress()
        {
            Random rand = new Random();
            List<string> itemList = new List<string>();
            //아이템 랜덤으로 하나 뽑아서 출력 (이건 파밍 템으로 가자)
            foreach(string item in Item.farmingItem.Keys)
            {
                itemList.Add(item);
            }

            string farmingItem = itemList[rand.Next(0, itemList.Count)];
            Textmanager.ExploreWindow();
            //Textmanager.SetWindow();
            Console.WriteLine("현재 탐색 횟수 : {0}", bossCount);
            Textmanager.SetWindow();
            Console.WriteLine("{0} 아이템을 획득하였습니다!", farmingItem);
            Console.ReadKey(true);
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
