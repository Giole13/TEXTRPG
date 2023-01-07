using System;
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
            Console.WriteLine("직업을 선택해 주세요 : ");
            SetJob();
        }

        //고를 직업을 보여주는 함수
        private void ShowJobList()
        {
            Console.WriteLine("1. 의사");
            Console.WriteLine("2. 군인");
            Console.WriteLine("3. CEO");
        }


        //유저 입력을 받는 함수
        public void SetJob()
        {
            string strInput = Console.ReadLine();
            int num;
            int.TryParse(strInput, out num);
            selectJob(num);
            JobOutput();
        }

        //고른 직업을 결정하는 함수
        private void selectJob(int num)
        {
            switch (num)
            {
                case 1:
                    Player.SetPlayerJob("의사");
                    break;
                case 2:
                    Player.SetPlayerJob("군인");
                    break;
                case 3:
                    Player.SetPlayerJob("CEO");
                    break;
                default:
                    break;
            }
        }

        private void JobOutput()
        {
            Console.WriteLine("당신의 직업은 {0} 입니다!", Player.GetPlayerJob());
            Console.ReadKey();
        }


    }
}
