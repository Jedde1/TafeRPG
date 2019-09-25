using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        string name = "";
        string description = "";
        int amount = 0;
        int value = 0;
        int damage = 0;
        int armour = 0;
        int heal = 0;
        string iconName = "";
        string meshName = "";
        ItemTypes type = ItemTypes.Misc;
       
        switch (itemId)
        {

            #region Armour 0-99
            case 0:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Weapon 100-199
            case 100:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Potion 200-299
            case 200:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Food 300-399
            case 300:
                name = "Apple";
                description = "Munches and Crunches";
                amount = 1;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 10;
                iconName = "Food/Apple";
                meshName = "Food/Apple";
                type = ItemTypes.Food;
                break;
            case 301:
                name = "Meat";
                description = "Mmmmmmmmmmmm MMMMMMMEEEEAAAATTTTT!";
                amount = 1;
                value = 5;
                damage = 0;
                armour = 0;
                heal = 50;
                iconName = "Food/Meat";
                meshName = "Food/Meat" +
                    "";
                type = ItemTypes.Food;
                break;
            #endregion
            #region Ingredient 400-499
            case 400:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Craftable 500-599
            case 500:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Quest 600-699
            case 600:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            #region Misc 700-799
            case 700:
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
            #endregion
            default:
                itemId = 0;
                name = "";
                description = "";
                amount = 0;
                value = 0;
                damage = 0;
                armour = 0;
                heal = 0;
                iconName = "";
                meshName = "";
                type = ItemTypes.Misc;
                break;
        }
        Item temp = new Item
        {
            ID = itemId,
            Name = name,
            Description = description,
            Value = value,
            Amount = amount,
            Damage = damage,
            Armour = armour,
            Heal = heal,
            IconName = Resources.Load("Icons/"+ iconName) as Texture2D,
            MeshName = Resources.Load("Prefabs/"+ meshName)as GameObject,
            ItemTypes = type
        };
        return temp;
    }
}
