using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.WareHouse_Scene;

namespace TextRpg.Game_Object
{
    public class Textmanager
    {
        #region 자리관련 함수
        static public void SetWindow()
        {
            int h, v;
            h = Console.CursorLeft;
            v = Console.CursorTop;
            Console.SetCursorPosition(h + 2, v);
        }

        static public void SetinventoryWindow()
        {
            int h, v;
            h = Console.CursorLeft;
            v = Console.CursorTop;
            Console.SetCursorPosition(h+64, v);
        }
        #endregion

        #region 탐색창
        static public void ExploreWindow()
        {
            Console.Clear();
            Player.PrintPlayerInfo();
            Textmanager.InventoryWindow();
            PrintExplore();
            Console.SetCursorPosition(2, 2);
        }
        static private void PrintExplore()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("┌─  탐색 ────────────────────────────────────────────────┐\n");
            VerticalLine();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(2, 2);
        }
        static private void VerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(57, i + 2);
                Console.Write("│");
            }
        }
        #endregion

        #region 인벤토리 창
        static public void InventoryWindow()
        {
            //Console.Clear();
            PrintInventory();
            ShowInventory();
            Console.SetCursorPosition(2, 2);
        }

        static private void ShowInventory()
        {
            Console.SetCursorPosition(64, 2);
            Console.WriteLine("개수\t아이템");
            SetinventoryWindow();
            //Textmanager.SetWindow();
            foreach (var value in Player.inventory)
            {
                Item items = value.Value;

                Console.Write("{0}\t", items.ReturnItemStack());
                Console.WriteLine("{0}", value.Key);
                SetinventoryWindow();
            }
        }


        static private void PrintInventory()
        {
            Console.SetCursorPosition(62, 1);
            Console.Write("┌─  인벤토리 ────────────────────────────────────────────┐\n");
            InventoryVerticalLine();
            Console.SetCursorPosition(62, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(2, 2);
        }
        static private void InventoryVerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(62, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(119, i + 2);
                Console.Write("│");
            }
        }


        #endregion

        #region 타이틀 창
        static public void TitleWindow()
        {
            Player.PrintPlayerInfo();
            PrintTitle();
            Console.SetCursorPosition(2, 2);
        }
        static private void PrintTitle()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("┌─  기지 ────────────────────────────────────────────────┐\n");
            TitleVerticalLine();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(2, 2);
        }
        static private void TitleVerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(57, i + 2);
                Console.Write("│");
            }
        }


        #endregion

        #region 창고 창
        static public void WareHouseWindow()
        {
            Player.PrintPlayerInfo();
            PrintWareHouse();
            EventInfo();
            Console.SetCursorPosition(2, 2);
        }
        static private void PrintWareHouse()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("┌─  창고 ────────────────────────────────────────────────┐\n");
            WareHouseVerticalLine();
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(2, 2);
        }
        static private void WareHouseVerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(0, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(57, i + 2);
                Console.Write("│");
            }
        }
        #endregion

        #region 상점 창
        static public void StoreWindow()
        {
            WareHouseWindow();
            Player.PrintPlayerInfo();
            PrintStore();
            EventInfo();
            Console.SetCursorPosition(2, 2);
        }
        static private void PrintStore()
        {
            Console.SetCursorPosition(62, 1);
            Console.Write("┌─  상점 ────────────────────────────────────────────────┐\n");
            StoreVerticalLine();
            Console.SetCursorPosition(62, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(62, 2);
        }
        static private void StoreVerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(62, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(119, i + 2);
                Console.Write("│");
            }
        }
        #endregion

        #region 이벤트 창
        static public void EventInfo()
        {
            Console.SetCursorPosition(62, 29);
            Console.Write("┌─  정보 ────────────────────────────────────────────────┐\n");
            EventVerticalLine();
            Console.SetCursorPosition(62, 38);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");

            //63 수평 -> 118
            //30 수직 -> 37
            //이벤트창은 부를때마다 깨끗하게 닦아주어야함
            for(int y = 30; y <= 37; ++y)
            {
                for(int x = 63; x <= 118; ++x)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(2, 2);
        }



        static private void EventVerticalLine()
        {
            for (int i = 0; i < 8; ++i)
            {
                Console.SetCursorPosition(62, i + 30);
                Console.Write("│");
                Console.SetCursorPosition(119, i + 30);
                Console.Write("│");
            }
        }
        #endregion

        #region 조합 창
        static public void CombiWindow()
        {
            WareHouseWindow();
            Player.PrintPlayerInfo();
            WareHouseWindow();
            Player.PrintPlayerInfo();
            CombiStore();
            EventInfo();
            Console.SetCursorPosition(2, 2);
        }
        static private void CombiStore()
        {
            Console.SetCursorPosition(62, 1);
            Console.Write("┌─  조합 ────────────────────────────────────────────────┐\n");
            CombiVerticalLine();
            Console.SetCursorPosition(62, 28);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");
            Console.SetCursorPosition(62, 2);
        }
        static private void CombiVerticalLine()
        {
            for (int i = 0; i < 27; ++i)
            {
                Console.SetCursorPosition(62, i + 2);
                Console.Write("│");
                Console.SetCursorPosition(119, i + 2);
                Console.Write("│");
            }
        }


        #endregion
    }
}
