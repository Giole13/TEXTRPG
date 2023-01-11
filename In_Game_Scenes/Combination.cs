using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        bool backScene = true;

        public Combination()
        {
            CombinationProgress();
        }


        //조합씬
        private void CombinationProgress()
        {
            while (backScene) { 
            Console.Clear();
            Textmanager.CombiWindow();
            ShowWare();
            PrintCombi();
            SelectCombi();
            }
        }


        private void ShowWare()
        {
            Console.SetCursorPosition(2, 2);
            foreach (string name in WareHouseDic.wareHouse.Keys)
            {

                Console.WriteLine("{0}", name);
                Textmanager.SetWindow();
            }
        }
        private void PrintCombi()
        {
            ShowCombiItem();
            Textmanager.EventInfo();
            Console.SetCursorPosition(64, 30);
            Console.WriteLine("조합할 아이템을 선택해주세요");
            Console.SetCursorPosition(64, 27);
            Console.WriteLine("1~9 아이템 선택 ESC 뒤로가기");
        }

        private void ShowCombiItem()
        {
            int i = 0;
            Console.SetCursorPosition(64, 2);
            foreach (KeyValuePair<string, Item> item in Item.combiItem)
            {
                Item items = item.Value;
                itemNum[i] = i + 1;
                itemName[i] = item.Key;
                itemList[i] = items;

                //여기에서 확인해보고 아니다 싶으면 회색으로 넣고 기다 싶으면 흰색으로 넣기!
                if (items.needCombiItem.Length == 2)
                {
                    //필요한 조합아이템의 개수가 2개이고
                    //창고에 두개가 존재하는경우
                    if (WareHouseDic.wareHouse.ContainsKey(items.needCombiItem[0]) && WareHouseDic.wareHouse.ContainsKey(items.needCombiItem[1]))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                }
                else if (items.needCombiItem.Length == 3)
                {
                    if (WareHouseDic.wareHouse.ContainsKey(items.needCombiItem[0]) && WareHouseDic.wareHouse.ContainsKey(items.needCombiItem[1])
                        && WareHouseDic.wareHouse.ContainsKey(items.needCombiItem[2]))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                }

                Console.Write("{0}번 ", itemNum[i]);      //번호
                Console.Write("{0}\n", itemName[i]);    //아이템 이름
                NeedCombiItemShow(items);
                ++i;
                //글자색을 원래대로 돌려놓기
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        //조합 아이템 출력
        private void NeedCombiItemShow(Item item)
        {
            Textmanager.SetinventoryWindow();
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
            Textmanager.SetinventoryWindow();
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
                case ConsoleKey.D3:
                    CombinationItem(3);
                    break;
                case ConsoleKey.D4:
                    CombinationItem(4);
                    break;
                case ConsoleKey.D5:
                    CombinationItem(5);
                    break;
                case ConsoleKey.D6:
                    CombinationItem(6);
                    break;
                case ConsoleKey.D7:
                    CombinationItem(7);
                    break;
                case ConsoleKey.D8:
                    CombinationItem(8);
                    break;
                case ConsoleKey.D9:
                    CombinationItem(9);
                    break;
                case ConsoleKey.Escape:
                    backScene = false;
                    return;
                default:
                    break;

            }
        }

        //조합 아이템을 조합하는 함수
        private void CombinationItem(int num)
        {
            num = num - 1;
            if(itemList[num] == null) { return; }
            
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
                    Textmanager.EventInfo();
                    Console.SetCursorPosition(64, 30);
                    Console.WriteLine("아이템 조합에 성공하셨습니다!");
                    Textmanager.SetinventoryWindow();
                    Console.WriteLine("{0} 아이템이 창고에 추가되었습니다!", itemName[num]);
                    Task.Delay(1200).Wait();
                }
                else
                {
                    Textmanager.EventInfo();
                    Console.SetCursorPosition(64, 30);
                    Console.WriteLine("아이템이 충분하지 않아 조합이 불가능합니다.");
                    Task.Delay(1200).Wait();
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
                    Textmanager.EventInfo();
                    Console.SetCursorPosition(64, 30);
                    Console.WriteLine("아이템 조합에 성공하셨습니다!");
                    Textmanager.SetinventoryWindow();
                    Console.WriteLine("{0} 아이템이 창고에 추가되었습니다!", itemName[num]);
                    Task.Delay(1200).Wait();
                }
                else
                {
                    Textmanager.EventInfo();
                    Console.SetCursorPosition(64, 30);
                    Console.WriteLine("아이템이 충분하지 않아 조합이 불가능합니다.");
                    Task.Delay(1200).Wait();
                }
            }
            else { /*Do nothing*/}
        }



    }       //class Combination();
}
