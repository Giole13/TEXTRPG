using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace TextRpg.Game_Object
{
    // 플레이어에 관한 모든 정보를 담고 있는 함수
    static public class Player
    {
        static private string _name;
        static private string _job;
        static public int _maxHp;
        static public int _presentHp;
        static public int _level;
        static public int _attack;
        static public int _presentExp;      //현재경험치
        static public int _needMaxExp;      //레벨업에 필요한 경험치
        static public int _money;           //가진 돈

        static public Dictionary<string, Item> inventory = new Dictionary<string, Item>();

        //int 만큼 가진 돈에 추가
        static public void MoneyPlus(int money)
        {
            _money += money;
        }

        //int 만큼 가진 돈에서 감가
        static public void MoneyMinus(int money)
        {
            _money -= money;
        }



        static public void SetPlayername(string name)
        {
            _name = name;
        }
        static public void SetPlayerJob(string job)
        {
            _job = job;
        }

        static public string GetPlayerName()
        {
            return _name;
        }

        static public string GetPlayerJob()
        {
            return _job;
        }

        //직업에 따라 플레이어의 스탯이 결정됨
        static public void SetPlayerStat()
        {
            if (_job == "의사")
            {
                _maxHp = 500;
                _presentHp = 500;
                _level = 1;
                _attack = 40;
                _presentExp = 0;      //현재경험치
                _needMaxExp = 20;
            }
            else if (_job == "군인")
            {
                _maxHp = 700;
                _presentHp = 700;
                _level = 1;
                _attack = 80;
                _presentExp = 0;      //현재경험치
                _needMaxExp = 20;
            }
            else if (_job == "CEO")
            {
                _maxHp = 400;
                _presentHp = 400;
                _level = 1;
                _attack = 40;
                _presentExp = 0;      //현재경험치
                _needMaxExp = 20;
            }
            else { /*Do nothing*/}
        }

        // 플레이어의 복합정보
        static public void PrintPlayerInfo()
        {
            Console.WriteLine("플레이어");
            Console.WriteLine("이름\t: {0}", _name);
            Console.WriteLine("직업\t: {0}", _job);
            Console.WriteLine("레벨\t: {0}", _level);
            Console.WriteLine("최대체력: {0}", _maxHp);
            Console.WriteLine("현재체력: {0}", _presentHp);
            Console.WriteLine("현재경험치: {0}",_presentExp);
            Console.WriteLine("공격력\t: {0}", _attack);
            Console.WriteLine("현재 가진돈: {0} 원", _money);
        }


    }


}
