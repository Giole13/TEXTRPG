using System;
using System.Threading.Tasks;
using TextRpg.Game_Object;

namespace TextRpg.Game_Setup_Stage
{
    internal class NameSetting
    {
        private string? _name = "";

        //이름설정 출력
        public NameSetting()
        {
            Console.Clear();
            Console.SetCursorPosition(90 / 2, 20);
            Console.Write("캐릭터의 이름을 입력해주세요 : ");
            SetName();
        }

        //이름 입력후 반환 함수
        public void SetName()
        {
            _name = Console.ReadLine();
            NameAsk();
            QuestionName();
            NameOutput();
            Player.SetPlayername(_name);
        }


        // 이름이 맞으면 패스 틀리면 재설정
        public bool QuestionName()
        {

            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key == ConsoleKey.D1)
            {
                return true;
            }
            else
            {
                while (cki.Key != ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(90 / 2, 20);
                    Console.Write("이름을 다시 설정해주세요 : ");
                    _name = Console.ReadLine();
                    NameAsk();
                    cki = Console.ReadKey(true);
                }
            }

            return true;
        }


        // 이름이 맞는지 질문하는 함수
        public void NameAsk()
        {
            Console.SetCursorPosition(90 / 2, 20);
            Console.WriteLine("설정하신 이름이 {0} 이(가) 맞습니까?", _name);
            Console.SetCursorPosition(90 / 2, 21);
            Console.WriteLine("1. Yes or 2. No");
            Console.SetCursorPosition(90 / 2, 22);
        }

        public void NameOutput()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(90 / 2, 20);
            Console.WriteLine("당신의 이름은 {0} 입니다!", _name);
            Task.Delay(1000).Wait();
            Console.CursorVisible = true;
        }
    }
}
