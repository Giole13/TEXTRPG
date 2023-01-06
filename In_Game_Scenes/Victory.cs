using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpg.Game_Object;

namespace TextRpg.In_Game_Scenes
{
    public class Victory
    {
        Monster _monster;

        public Victory(Monster monster)
        {
            _monster = monster;
            WinResult();
        }

        public void WinResult()
        {
            Console.WriteLine("당신은 이겼습니다!");
            Player.inventory.Add(new Hat1(), "모자");

        }
    }
}
