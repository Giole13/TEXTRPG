using System;
using System.Collections.Generic;
using TextRpg.Game_Object;

namespace TextRpg.WareHouse_Scene
{
    // 창고씬
    public class WareHouse
    {
        ConsoleKeyInfo cki;
        //창고씬에 들어갈 때 인벤토리의 아이템들을 전부
        //여기로 옮길꺼임.
        public WareHouse()
        {
            WareHouseProgress();
        }

        private void WareHouseProgress()
        {
            foreach(KeyValuePair<string, Item> item in Player.inventory)
            {
                //중복 이슈 해결 방안 containsKey(키타입 변수) -> 키타입 변수를 검색해서 있다면 true를 반환
                string itemName = item.Key;
                Item items = item.Value;
                if (WareHouseDic.wareHouse.ContainsKey(itemName))
                {
                    items.ItemStackPlus();
                }
                else
                {
                    WareHouseDic.wareHouse.Add(itemName, items);
                }
                //WareHouseDic.wareHouse.Add(item.Key, item.Value);
            }

            foreach(Item item in Player.inventory.Values)
            {
                item.ResetStack();
            }

            Player.inventory.Clear();

            while (true)
            {
                Console.Clear();
                //창고 전체를 출력
                new ShowWareHouse();

                Console.WriteLine("=========================");

                //인벤토리 출력
                new ShowInventory();


                Console.WriteLine("1 : 아이템 옮기기\t2 : 돌아가기");
                Console.Write("입력해주세요 : ");

                bool backScene = false;
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        //아무것도 안함
                        
                        break;
                    case ConsoleKey.D2:
                        //기지로 돌아가기
                        backScene = true;
                        break;
                    default:
                        break;
                }

                //기지로 돌아가기
                if (backScene)
                {
                    break;
                }
            }

        }



    }

    //게임 시작할때 스태틱으로 초기화
    public class WareHouseDic
    {
        //창고 딕셔너리 초기화 ( 게임 시작할 때 초기화 해야함
        static public Dictionary<string, Item> wareHouse = new Dictionary<string, Item>();

        //창고 딕셔너리 생성자
        public WareHouseDic()
        {
            
            //wareHouse.Add("모자",new Hat1());
        }
    }
    
    //창고 출력 객체
    public class ShowWareHouse
    {
        public ShowWareHouse()
        {
            Console.WriteLine("창고");
            Console.WriteLine("개수\t아이템");
            foreach (var value in WareHouseDic.wareHouse)
            {
                Item items = value.Value;
                Console.Write("{0}\t", items.ReturnAllItemStack());
                Console.WriteLine("{0}", value.Key);
            }
        }
    }
}
