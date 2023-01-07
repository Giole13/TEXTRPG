using System.Collections.Generic;

namespace TextRpg.Game_Object
{
    public class Item
    {
        static public Dictionary<string, Item> allItem = new Dictionary<string, Item>();
        //아이템 스택
        public int itemStack = 1;
    }

    public class Hat1 : Item { }
    public class ClothPiece : Item { }
    public class WeaponParts : Item { }
    public class dogsFangs : Item { }
    public class FurRake : Item { }
    public class RatToken : Item { }
    public class ThickLetter : Item { }
}
