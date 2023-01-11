using System;
using System.Threading.Tasks;
using TextRpg.Game_Object;

namespace TextRpg.Game_Setup_Stage
{
    //직업 선택 씬
    public class JobSetting
    {
        //직업 선택 생성자
        public JobSetting()
        {
            Console.Clear();
            ShowJobList();
            Console.SetCursorPosition(90 / 2, 20);
            Console.Write("직업을 선택해 주세요 : ");
            SetJob();
        }

        //고를 직업을 보여주는 함수
        private void ShowJobList()
        {
            //의사 소개
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("1. 의사");
            Console.SetCursorPosition(10, 12);
            Console.Write("탐색에서 최대 3회 사용 가능한");
            Console.SetCursorPosition(10, 13);
            Console.Write("자가회복 스킬을 가지고 있지만");
            Console.SetCursorPosition(10, 14);
            Console.Write("스펙은 가장 기본적이다.");

            //군인 소개
            Console.SetCursorPosition(55, 10);
            Console.WriteLine("2. 군인");
            Console.SetCursorPosition(45, 12);
            Console.Write("모든 직업중 가장 높은 스펙을");
            Console.SetCursorPosition(45, 13);
            Console.Write("가지고 있고 평범한 공격스킬을");
            Console.SetCursorPosition(45, 14);
            Console.Write("가지고 있다.");

            //ceo 소개
            Console.SetCursorPosition(90, 10);
            Console.WriteLine("3. CEO");
            Console.SetCursorPosition(80, 12);
            Console.Write("상점에서 가격을 할인 받을 수 있다.");
            Console.SetCursorPosition(80, 13);
            Console.Write("하지만 의사보다 조금은");
            Console.SetCursorPosition(80, 14);
            Console.Write("약한 스펙을지녔다.");
        }


        //유저 입력을 받는 함수
        private void SetJob()
        {
            selectJob();
            JobOutput();
        }

        //고른 직업을 결정하는 함수
        private void selectJob()
        {
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        Player.SetPlayerJob("의사");
                        return;
                    case ConsoleKey.D2:
                        Player.SetPlayerJob("군인");
                        return;
                    case ConsoleKey.D3:
                        Player.SetPlayerJob("CEO");
                        return;
                    default:
                        break;
                }
            }
        }

        private void JobOutput()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(90 / 2, 20);
            Console.WriteLine("당신의 직업은 {0} 입니다!         ", Player.GetPlayerJob());
            Task.Delay(1000).Wait();
            //Console.CursorVisible = true;
        }


    }
}
