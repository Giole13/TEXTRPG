using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextRpg.Game_Object;

namespace TextRpg.WareHouse_Scene
{
    // 창고씬
    public class WareHouse
    {
        ConsoleKeyInfo cki;
        List<string> itemname = new List<string>() { "", "", "", "", "", "", "", "", "" };

        //창고씬에 들어갈 때 인벤토리의 아이템들을 전부
        //여기로 옮길꺼임.
        public WareHouse()
        {
            WareHouseProgress();
        }

        private void WareHouseProgress()
        {
            foreach (KeyValuePair<string, Item> item in Player.inventory)
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

            foreach (Item item in Player.inventory.Values)
            {
                item.ResetStack();
            }

            Player.inventory.Clear();

            while (true)
            {
                Console.Clear();
                PrintWareHouse();
                //Console.WriteLine("1 : 장착하기\tESC : 돌아가기");


                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        //장비나 인벤토리로 옮기기
                        SelectNum1();
                        break;
                    case ConsoleKey.Escape:
                        //기지로 돌아가기
                        return;
                    default:
                        break;
                }

                PrintWareHouse();

            }       //loop: 창고

        }       //WareHouseProgress();



        #region 장착 시퀀스
        //장비아이템 출력
        private void PrintEquipment()
        {
            Console.Clear();
            Textmanager.WareHouseWindow();
            Textmanager.InventoryWindow();
            Player.PrintPlayerInfo();
            ShowEquipment();
        }

        // 장비아이템만 출력함
        private void ShowEquipment()
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1 ~ 9 바꿀 장비 선택\tESC 뒤로가기");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("장비");
            Textmanager.SetWindow();
            Console.WriteLine("개수\t아이템");
            int num = 0;
            itemname.Clear();
            foreach (var value in WareHouseDic.wareHouse)
            {
                Item items = value.Value;
                if (items.equipment == true)
                {
                    itemname.Add(value.Key);
                    
                    Textmanager.SetWindow();
                    Console.Write("{0}번 ", num + 1);
                    Console.Write("{0}\t", items.ReturnAllItemStack());
                    Console.WriteLine("{0}", value.Key);
                    ++num;
                }
                else { /*Do nothing*/}

            }
        }

        //장비고르는 함수
        private void SelectNum1()
        {
            PrintEquipment();
            

            cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                //장비나 인벤토리로 옮기기
                case ConsoleKey.D1:
                    EquipmentCheck(1);
                    break;
                case ConsoleKey.D2:
                    EquipmentCheck(2);
                    break;
                case ConsoleKey.D3:
                    EquipmentCheck(3);
                    break;
                case ConsoleKey.D4:
                    EquipmentCheck(4);
                    break;
                case ConsoleKey.D5:
                    EquipmentCheck(5);
                    break;
                case ConsoleKey.D6:
                    EquipmentCheck(6);
                    break;
                case ConsoleKey.D7:
                    EquipmentCheck(7);
                    break;
                case ConsoleKey.D8:
                    EquipmentCheck(8);
                    break;
                case ConsoleKey.D9:
                    EquipmentCheck(9);
                    break;
                case ConsoleKey.Escape:
                    //창고로 돌아가기
                    return;
                default:
                    break;
            }
        }

        //고른 아이템으로 교체하는 함수
        private void EquipmentCheck(int num)
        {
            //아이템 고를때 터지는 이슈 해결
            if (itemname.Count < num)
            {
                Textmanager.EventInfo();
                Console.SetCursorPosition(64, 30);
                Console.WriteLine("다시 선택해주세요");
                Console.ReadKey(true);
                return;
            }

            Item item = Item.allItem[itemname[num - 1]];

            if (item.equipment == true)
            {
                //원래 장비하고있던 아이템을 창고로 옮기는 작업
                foreach (KeyValuePair<string, Item> equipmentItem in Player.equipment)
                {
                    Player.equipment.Clear();
                    if (WareHouseDic.wareHouse.ContainsKey(equipmentItem.Key))
                    {
                        equipmentItem.Value.ItemStackPlus();
                    }
                    else
                    {
                        WareHouseDic.wareHouse.Add(equipmentItem.Key, equipmentItem.Value);
                    }

                    Player.GetOffEquipment(equipmentItem.Value);

                }



                //플레이어의 장비칸에 장착
                Player.equipment.Add(itemname[num - 1], item);
                //창고에서 해당 아이템 삭제
                WareHouseDic.wareHouse.Remove(itemname[num - 1]);

                Player.CheckEquipment();
                Textmanager.EventInfo();
                Console.SetCursorPosition(64, 30);
                Console.WriteLine("{0} 을(를) 장착하였습니다.", itemname[num - 1]);
                Task.Delay(1000).Wait();
            }
            else
            {
                Textmanager.EventInfo();
                Console.SetCursorPosition(64, 30);
                Console.WriteLine("\n다시 선택해주세요");
                Task.Delay(1000).Wait();
                return;
            }
        }
        #endregion


        #region 프린트 시퀀스
        private void PrintWareHouse()
        {
            Textmanager.WareHouseWindow();
            //인벤토리 출력
            Textmanager.InventoryWindow();
            Player.PrintPlayerInfo();
            //창고 전체를 출력
            ShowWareHouse();
        }

        private void ShowWareHouse()
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("1 장비\tESC 돌아가기");
            Console.SetCursorPosition(0, 2);
            Textmanager.SetWindow();
            Console.WriteLine("개수\t아이템");
            Textmanager.SetWindow();
            //int num = 0;
            foreach (var value in WareHouseDic.wareHouse)
            {
                Item items = value.Value;
                //itemname.Add(value.Key);
                //Console.Write("{0}번 ", num + 1);
                Console.Write("{0}\t", items.ReturnAllItemStack());
                Console.WriteLine("{0}", value.Key);
                Textmanager.SetWindow();

                //++num;
            }
        }
        #endregion



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
}
