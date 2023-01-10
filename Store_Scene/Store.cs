using System;
using System.Collections.Generic;
using TextRpg.Game_Object;
using TextRpg.WareHouse_Scene;

namespace TextRpg.Store_Scene
{
    // 상점씬
    public class Store
    {
        List<string> itemName = new List<string>();
        int[] itemNum = new int[10];
        int[] itemPrice = new int[10];
        Item[] itemList = new Item[10];
        ConsoleKeyInfo cki;

        List<string> sellItem = new List<string>();


        public Store()
        {
            StoreProgress();
        }

        private void StoreProgress()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Player.PrintPlayerInfo();
                Console.WriteLine("1. 물건 구입 및 판매\t2. 돌아가기");
                Console.Write("입력해주세요 : ");


                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        //아무것도 안함
                        BuyAndSell();
                        break;
                    case ConsoleKey.D2:
                        //기지로 돌아가기
                        return;
                    default:
                        break;
                }

            }       //loop: 상점씬
        }       //storeProgress(); 상점 메인 함수


        //아이템 살지 팔지 결정하는 함수
        private void BuyAndSell()
        {
            Console.Clear();
            ConsoleKeyInfo cki2;
            Console.WriteLine("1. 물건 구입\t2. 물건 판매\t3. 돌아가기");
            Console.Write("입력해주세요 : ");
            cki2 = Console.ReadKey();
            switch (cki2.Key)
            {
                case ConsoleKey.D1:
                    //물건 구입씬으로
                    BuyScene();
                    break;
                case ConsoleKey.D2:
                    //물건 판매씬으로
                    SellScene();
                    break;
                case ConsoleKey.D3:
                    //돌아가기
                    return;
                default:
                    break;
            }




        }

        //판매 씬
        private void SellScene()
        {
            sellItem.Clear();
            Console.Clear();
            int num = 0;
            //판매할 아이템 목록
            foreach (string name in WareHouseDic.wareHouse.Keys)
            {
                Console.Write("{0}번 ", num + 1);
                sellItem.Add(name);
                Console.WriteLine("{0}", name);
                ++num;
            }
            //아이템 선택
            SelectSellItem();

        }

        private void SelectSellItem()
        {
            Console.WriteLine("판매할 아이템을 골라주세요");
            Console.Write("입력해 주세요 : ");
            ConsoleKeyInfo cki = Console.ReadKey();

            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    SellItems(1);
                    break;
                case ConsoleKey.D2:
                    SellItems(2);
                    break;
                case ConsoleKey.D3:
                    SellItems(3);
                    break;
                case ConsoleKey.D4:
                    SellItems(4);
                    break;
                case ConsoleKey.D5:
                    SellItems(5);
                    break;
                case ConsoleKey.D6:
                    SellItems(6);
                    break;
                case ConsoleKey.D7:
                    SellItems(7);
                    break;
                case ConsoleKey.D8:
                    SellItems(8);
                    break;
                case ConsoleKey.D9:
                    SellItems(9);
                    break;
                case ConsoleKey.Escape:
                    //돌아가기
                    return;
                default:
                    break;


            }
        }

        private void SellItems(int num)
        {
            if (sellItem.Count < num)
            {
                Console.WriteLine("\n다시 선택해주세요");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("{0}을(를) 판매하시겠습니까?", sellItem[num - 1]);
            Console.WriteLine("1. 판매\t2. 취소");
            Console.Write("입력해주세요 : ");
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.D1:
                    //구입 결과 창으로
                    SellResult(num);
                    break;
                case ConsoleKey.D2:
                    break;
            }


        }

        private void SellResult(int num)
        {
            WareHouseDic.wareHouse.Remove(sellItem[num - 1]);
            Item sellitem = Item.allItem[sellItem[num - 1]];
            Player._money += sellitem.price;
            Console.WriteLine("{0} 아이템을 판매하였습니다!", sellItem[num - 1]);
            Console.WriteLine("아이템을 판매하고 {0} 만큼 받았습니다!", sellitem.price);
            Console.ReadKey();
        }


        #region 아이템 사는 시퀀스
        //아이템 목록을 보여주는 함수
        private void ShowItem()
        {

            int i = 0;
            Console.Clear();
            //아이템 불러오기
            foreach (KeyValuePair<string, Item> item in Item.equipmentItem)
            {
                Item items = item.Value;
                itemNum[i] = i + 1;
                itemName.Add(item.Key);
                itemPrice[i] = items.price;
                itemList[i] = items;

                Console.Write("{0} ", itemNum[i]);
                Console.Write("{0}\n", itemName[i]);
                Console.WriteLine("가격 : {0}\t체력 +{1}", items.price, items.plusHp);
                ++i;
                Console.WriteLine();
            }



        }

        private void BuyScene()
        {
            Console.Clear();
            ShowItem();
            Console.Write("ESC : 돌아가기\n1~9 : 구입 아이템 선택");
            Console.Write("구입 아이템을 선택해주세요 : ");
            ConsoleKeyInfo cki3;
            cki3 = Console.ReadKey();
            switch (cki3.Key)
            {
                case ConsoleKey.D1:
                    BuyAction(1);
                    break;
                case ConsoleKey.D2:
                    BuyAction(2);
                    break;
                case ConsoleKey.D3:
                    BuyAction(3);
                    break;
                case ConsoleKey.D4:
                    BuyAction(4);
                    break;
                case ConsoleKey.D5:
                    BuyAction(5);
                    break;
                case ConsoleKey.D6:
                    BuyAction(6);
                    break;
                case ConsoleKey.D7:
                    BuyAction(7);
                    break;
                case ConsoleKey.D8:
                    BuyAction(8);
                    break;
                case ConsoleKey.D9:
                    BuyAction(9);
                    break;
                case ConsoleKey.Escape:
                    //돌아가기
                    return;
                default:
                    break;
            }
        }

        private void BuyAction(int num)
        {
            if (itemName.Count < num)
            {
                Console.WriteLine("\n다시 선택해주세요");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            Console.WriteLine("{0}을(를) 구입하시겠습니까?", itemName[num - 1]);
            Console.WriteLine("1. 구입\t2. 취소");
            Console.Write("입력해주세요 : ");
            ConsoleKeyInfo cki4;
            cki4 = Console.ReadKey();
            switch (cki4.Key)
            {
                case ConsoleKey.D1:
                    //구입 결과 창으로
                    BuyResult(num);
                    break;
                case ConsoleKey.D2:
                    break;
            }

        }

        private void BuyResult(int num)
        {
            Console.Clear();

            if (Player._money < itemPrice[num - 1])
            {
                Console.Clear();
                Console.WriteLine("돈이 부족합니다!");
                Console.ReadKey();

            }
            else
            {
                string itemNames = itemName[num - 1];
                Item items = itemList[num - 1];
                //플레이어의 인벤토리에 같은 아이템이 있다면 해당 아이템의 개수를 하나 증가
                if (Player.inventory.ContainsKey(itemNames))
                {
                    //사장일 경우 반값 할인
                    if (Player.GetPlayerJob() == "CEO")
                    {
                        Player._money -= itemPrice[num - 1]/2;
                        items.ItemStackPlus();
                    }
                    else { /*Do nothing*/}
                    Player._money -= itemPrice[num - 1];
                    items.ItemStackPlus();
                }
                else
                {
                    if (Player.GetPlayerJob() == "CEO")
                    {
                        Player._money -= itemPrice[num - 1] / 2;
                        Player.inventory.Add(itemName[num - 1], itemList[num - 1]);
                    }
                    else { /*Do nothing*/}
                    Player._money -= itemPrice[num - 1];
                    Player.inventory.Add(itemName[num - 1], itemList[num - 1]);
                }
                Console.WriteLine("{0} 아이템을 구입하였습니다!", itemName[num - 1]);
                Console.ReadKey();
            }

        }
        #endregion

    }       //class Store
}
