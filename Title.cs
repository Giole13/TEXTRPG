using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    public class Title
    {
        // 타이틀 화면
        // 아무 키나 누르세요!
        public Title()
        {
            Console.Clear();
            Console.WriteLine("TXET RPG");
            Console.WriteLine("Press Any Key");
            Console.ReadKey();
        }

    }
}
