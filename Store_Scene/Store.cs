using System;
using System.Collections.Generic;
using TextRpg.Game_Object;
using TextRpg.WareHouse_Scene;

namespace TextRpg.Store_Scene
{
    // 상점씬
    public class Store
    {
        string[] itemName = new string[10];
        int[] itemNum = new int[10];
        int[] itemPrice = new int[10];
        Item[] itemList = new Item[10];
        ConsoleKeyInfo cki;
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
                    break;
                case ConsoleKey.D3:
                    //돌아가기
                    return;
                default:
                    break;
            }




        }

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
                itemName[i] = item.Key;
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
                    Player._money -= itemPrice[num - 1];
                    items.ItemStackPlus();
                }
                else
                {
                    Player._money -= itemPrice[num - 1];
                    Player.inventory.Add(itemName[num - 1], itemList[num - 1]);
                }
                Console.WriteLine("{0} 아이템을 구입하였습니다!", itemName[num - 1]);
                Console.ReadKey();
            }

        }


    }       //class Store
}
