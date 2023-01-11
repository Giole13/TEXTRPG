using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using TextRpg.In_Game_Scenes;

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
        static public Job plsyerJob;
        static private int plusAttackPower;
        static private int plusHp;


        static public Dictionary<string, Item> inventory = new Dictionary<string, Item>();
        static public Dictionary<string, Item> equipment = new Dictionary<string, Item>();

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
                plsyerJob = new Doctor();
            }
            else if (_job == "군인")
            {
                _maxHp = 700;
                _presentHp = 700;
                _level = 1;
                _attack = 80;
                _presentExp = 0;      //현재경험치
                _needMaxExp = 20;
                plsyerJob = new Soldier();
            }
            else if (_job == "CEO")
            {
                _maxHp = 400;
                _presentHp = 400;
                _level = 1;
                _attack = 40;
                _presentExp = 0;      //현재경험치
                _needMaxExp = 20;
                plsyerJob = new Ceo();
            }
            else { /*Do nothing*/ }
        }

        static public void IamGod()
        {
            _maxHp = 10000;
            _presentHp = 10000;
            _level = 100;
            _attack = 1000;
            _presentExp = 0;      //현재경험치
            _needMaxExp = 0;
            plsyerJob = new Ceo();
            _name = "신";
            _job = "신";
        }

        // 플레이어의 복합정보
        static public void PrintPlayerInfo()
        {
            //─
            //＿
            //Textmanager.InventoryWindow();
            Console.SetCursorPosition(0, 0);
            LevelupCheck();
            Console.SetCursorPosition(0, 29);
            Console.Write("┌─  플레이어 스탯 ───────────────────────────────────────┐\n");
            Console.Write("  이름\t: {0}\t\t직업\t: {1}\n", _name, _job);
            Console.Write("  레벨\t: {0}\t\t공격력\t: {1}\n", _level, _attack);
            Console.Write("  돈: {0}\t\t", _money);
            Console.Write("  체력: {0} / {1}\n", _presentHp, _maxHp);
            Console.Write("  경험치: {0} / {1}\n", _presentExp, _needMaxExp);
            VerticalLine();


            //장비 슬릇 추가
            //Console.SetCursorPosition(0,21);
            ShowEquipment();
            Console.SetCursorPosition(2, 2);
        }

        static private void VerticalLine()
        {
            for (int i = 0; i < 6; ++i)
            {
                Console.SetCursorPosition(0, i + 30);
                Console.Write("│");
                Console.SetCursorPosition(57, i + 30);
                Console.Write("│");
            }

        }

        static public void GetOffEquipment(Item equipment)
        {
            _maxHp -= equipment.plusHp;
            _attack -= equipment.attackPower;
            equipment.mountItem = false;
        }

        static public void CheckEquipment()
        {
            foreach (Item equipment in Player.equipment.Values)
            {
                if (equipment.mountItem == false)
                {
                    _maxHp += equipment.plusHp;
                    _attack += equipment.attackPower;

                    equipment.mountItem = true;
                }
                else
                {
                    /*Do nothing*/
                }
            }
        }

        static private void ShowEquipment()
        {
            Console.SetCursorPosition(0, 36);
            Console.WriteLine("│ 현재 장비한 아이템");
            Console.SetCursorPosition(0, 37);
            Console.WriteLine("│ =없음=");
            Console.SetCursorPosition(57, 36);
            Console.Write("│");
            Console.SetCursorPosition(57, 37);
            Console.Write("│");
            foreach (string equipmentItem in equipment.Keys)
            {
                Console.SetCursorPosition(0, 37);
                Console.Write("         ");
                Console.SetCursorPosition(0, 37);
                Console.WriteLine("│ {0}", equipmentItem);
            }
            Console.SetCursorPosition(0, 38);
            Console.WriteLine("└────────────────────────────────────────────────────────┘");

        }

        static private void LevelupCheck()
        {
            if (_presentExp >= _needMaxExp)
            {
                ++_level;
                _presentExp = 0;            //현재 경험치 초기화 및 최대 경험치 상승
                _needMaxExp += _level * 20;

                _maxHp += _level * 10;      //체력 공격력 상승
                _attack += _level * 5;

                _presentHp = _maxHp;

                //커서는 조정
                Console.Clear();
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("레벨업■■■■■■■■■");
                Task.Delay(2000).Wait();
            }
            else { /*Do nothing*/}
        }

    }


}
