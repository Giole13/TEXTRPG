using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Game_Object
{
    internal class ShowInventory
    {
        //인벤토리 출력문
        public ShowInventory()
        {
            Console.WriteLine("현재 인벤토리");
            Console.WriteLine("개수\t아이템");
            foreach (var value in Player.inventory)
            {
                Item items = value.Value;


                Console.Write("{0}\t", items.ReturnItemStack());
                Console.WriteLine("{0}", value.Key);
            }
        }
    }
}
