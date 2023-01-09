using System;
using System.Collections.Generic;
using TextRpg.Game_Object;
using TextRpg.WareHouse_Scene;

namespace TextRpg.In_Game_Scenes
{
    // 조합씬
    public class Combination
    {
        string[] itemName = new string[10];
        int[] itemNum = new int[10];
        Item[] itemList = new Item[10];
        ConsoleKeyInfo cki;
        public Combination()
        {
            CombinationProgress();
        }


        //조합씬
        private void CombinationProgress()
        {
            Console.Clear();
            PrintCombi();
            SelectCombi();


        }

        private void PrintCombi()
        {
            ShowCombiItem();

            Console.WriteLine("\n\n조합할 아이템을 선택해주세요");
            Console.Write("입력해주세요 : ");
        }

        private void ShowCombiItem()
        {
            int i = 0;
            foreach (KeyValuePair<string, Item> item in Item.combiItem)
            {
                Item items = item.Value;
                itemNum[i] = i + 1;
                itemName[i] = item.Key;
                itemList[i] = items;



                Console.Write("{0} ", itemNum[i]);      //번호
                Console.Write("{0}\n", itemName[i]);    //아이템 이름
                NeedCombiItemShow(items);
                ++i;
            }
        }


        //조합 아이템 출력
        private void NeedCombiItemShow(Item item)
        {
            int i = 0;
            foreach (string need in item.needCombiItem)
            {
                if (i == 1)
                {
                    Console.Write(" + ");
                }
                Console.Write(need);
                i = 1;
            }
            Console.WriteLine();
            Console.WriteLine("============");
        }

        //조합 아이템 선택
        private void SelectCombi()
        {
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    CombinationItem(1);
                    break;
                case ConsoleKey.D2:
                    CombinationItem(2);
                    break;
                default:
                    break;

            }
        }

        //조합 아이템을 조합하는 함수
        private void CombinationItem(int num)
        {
            num = num - 1;
            Item combiItem = itemList[num];
            string[] needItems = combiItem.needCombiItem;

            if (needItems.Length == 2)
            {
                //필요한 조합아이템의 개수가 2개이고
                //창고에 두개가 존재하는경우
                if (WareHouseDic.wareHouse.ContainsKey(needItems[0]) && WareHouseDic.wareHouse.ContainsKey(needItems[1]))
                {
                    WareHouseDic.wareHouse.Remove(needItems[0]);
                    WareHouseDic.wareHouse.Remove(needItems[1]);
                    if (WareHouseDic.wareHouse.ContainsKey(itemName[num]))
                    {
                        itemList[num].ItemStackPlus();
                    }
                    else
                    {
                        WareHouseDic.wareHouse.Add(itemName[num], itemList[num]);
                    }
                    Console.WriteLine("아이템 조합에 성공하셨습니다!");
                    Console.WriteLine("{0} 아이템이 창고에 추가되었습니다!", itemName[num]);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("아이템이 충분하지 않아 조합이 불가능합니다.");
                    Console.ReadKey();
                }

            }
            else if (needItems.Length == 3)
            {
                //필요한 조합아이템의 개수가 2개이고
                //창고에 두개가 존재하는경우
                if (WareHouseDic.wareHouse.ContainsKey(needItems[0]) && WareHouseDic.wareHouse.ContainsKey(needItems[1])
                    && WareHouseDic.wareHouse.ContainsKey(needItems[2]))
                {
                    WareHouseDic.wareHouse.Remove(needItems[0]);
                    WareHouseDic.wareHouse.Remove(needItems[1]);
                    WareHouseDic.wareHouse.Remove(needItems[2]);
                    //WareHouseDic.wareHouse.Add(itemName[num], itemList[num]);
                    if (WareHouseDic.wareHouse.ContainsKey(itemName[num]))
                    {
                        itemList[num].ItemStackPlus();
                    }
                    else
                    {
                        WareHouseDic.wareHouse.Add(itemName[num], itemList[num]);
                    }
                    Console.WriteLine("아이템 조합에 성공하셨습니다!");
                    Console.WriteLine("{0} 아이템이 창고에 추가되었습니다!", itemName[num]);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("아이템이 충분하지 않아 조합이 불가능합니다.");
                    Console.ReadKey();
                }

            }



        }



    }       //class Combination();
}
