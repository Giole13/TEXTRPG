using System;

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
