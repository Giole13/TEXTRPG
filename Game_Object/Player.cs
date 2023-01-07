using System;
using System.Collections.Generic;

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

        static public Dictionary<string, Item> inventory = new Dictionary<string, Item>();


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
            Console.WriteLine(_name);
            Console.WriteLine(_job);
            Console.WriteLine(_level);
            Console.WriteLine(_maxHp);
            Console.WriteLine(_presentExp);
            Console.WriteLine(_presentHp);
            Console.WriteLine(_attack);
        }


    }


}
