using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    //public List<Sprite> _ListSpriteArmor = new List<Sprite>();
    public List<Sprite> _ListSpriteFood = new List<Sprite>();
    public List<Sprite> _ListSpriteWeapon = new List<Sprite>();
}

public enum MergeItem
{
    /*ItemArmor1,
    ItemArmor2,
    ItemArmor3,
    ItemArmor4,
    ItemArmor5,
    ItemArmor6,*/
    ItemFood1,
    ItemFood2,
    ItemFood3,
    ItemFood4,
    ItemFood5,
    ItemFood6, 
    ItemWeapon1,
    ItemWeapon2,
    ItemWeapon3,
    ItemWeapon4,
    ItemWeapon5,
    ItemWeapon6,
}

public enum MergeItemType
{
    //Armor,
    Food,
    Weapon
}

public class MergeItemData
{
    public int mergeLevel;
    public MergeItemType itemType;
    public Sprite itemSprite;
}

public class MergeItemList
{
    private Dictionary<MergeItem, MergeItemData> items;

    public MergeItemList(/*List<Sprite> spritesArmor,*/ List<Sprite> spritesFood, List<Sprite> spritesWeapon)
    {
        items = new Dictionary<MergeItem, MergeItemData>();
        //Armor
        /*items.Add(MergeItem.ItemArmor1, new MergeItemData { mergeLevel = 0, itemType = MergeItemType.Armor, itemSprite = spritesArmor[0] });
        items.Add(MergeItem.ItemArmor2, new MergeItemData { mergeLevel = 1, itemType = MergeItemType.Armor, itemSprite = spritesArmor[1] });
        items.Add(MergeItem.ItemArmor3, new MergeItemData { mergeLevel = 2, itemType = MergeItemType.Armor, itemSprite = spritesArmor[2] });
        items.Add(MergeItem.ItemArmor4, new MergeItemData { mergeLevel = 3, itemType = MergeItemType.Armor, itemSprite = spritesArmor[3] });
        items.Add(MergeItem.ItemArmor5, new MergeItemData { mergeLevel = 4, itemType = MergeItemType.Armor, itemSprite = spritesArmor[4] });
        items.Add(MergeItem.ItemArmor6, new MergeItemData { mergeLevel = 5, itemType = MergeItemType.Armor, itemSprite = spritesArmor[5] });*/
        //Food
        items.Add(MergeItem.ItemFood1, new MergeItemData { mergeLevel = 0, itemType = MergeItemType.Food, itemSprite = spritesFood[0] });
        items.Add(MergeItem.ItemFood2, new MergeItemData { mergeLevel = 1, itemType = MergeItemType.Food, itemSprite = spritesFood[1] });
        items.Add(MergeItem.ItemFood3, new MergeItemData { mergeLevel = 2, itemType = MergeItemType.Food, itemSprite = spritesFood[2] });
        items.Add(MergeItem.ItemFood4, new MergeItemData { mergeLevel = 3, itemType = MergeItemType.Food, itemSprite = spritesFood[3] });
        items.Add(MergeItem.ItemFood5, new MergeItemData { mergeLevel = 4, itemType = MergeItemType.Food, itemSprite = spritesFood[4] });
        items.Add(MergeItem.ItemFood6, new MergeItemData { mergeLevel = 5, itemType = MergeItemType.Food, itemSprite = spritesFood[5] });
        //Weapon
        items.Add(MergeItem.ItemWeapon1, new MergeItemData { mergeLevel = 0, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[0] });
        items.Add(MergeItem.ItemWeapon2, new MergeItemData { mergeLevel = 1, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[1] });
        items.Add(MergeItem.ItemWeapon3, new MergeItemData { mergeLevel = 2, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[2] });
        items.Add(MergeItem.ItemWeapon4, new MergeItemData { mergeLevel = 3, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[3] });
        items.Add(MergeItem.ItemWeapon5, new MergeItemData { mergeLevel = 4, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[4] });
        items.Add(MergeItem.ItemWeapon6, new MergeItemData { mergeLevel = 5, itemType = MergeItemType.Weapon, itemSprite = spritesWeapon[5] });
    }

    public MergeItemData GetItemData(MergeItem item)
    {
        return items[item];
    }
}
