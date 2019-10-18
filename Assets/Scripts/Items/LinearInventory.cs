using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInventory : MonoBehaviour
{
    #region Variables
    public static List<Item> inv = new List<Item>();
    public static bool showInv;
    public Item selectedItem;
    public Vector2 scr;

    public int money;
    public Vector2 scrollPos;

    public string sortType = "All";

    public Transform dropLocation;
    [System.Serializable]
    public struct EquippedItems
    {
        public string slotName;
        public Transform location;
        public GameObject equippedItem;
    };
    public EquippedItems[] equippedItems;
    #endregion

    private void Start()
    {
        showInv = false;
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(1));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(3));
        inv.Add(ItemData.CreateItem(100));
        inv.Add(ItemData.CreateItem(101));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(200));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        inv.Add(ItemData.CreateItem(400));
        inv.Add(ItemData.CreateItem(401));
        inv.Add(ItemData.CreateItem(402));
        inv.Add(ItemData.CreateItem(500));
        inv.Add(ItemData.CreateItem(501));
        inv.Add(ItemData.CreateItem(502));
        inv.Add(ItemData.CreateItem(600));
        inv.Add(ItemData.CreateItem(700));
    }
    private void Update()
    {
        if (Input.GetButtonDown("Inventory") && !PauseMenu.isPaused)
        {
            showInv = !showInv;
            if (showInv)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                selectedItem = null;
            }
        }
        if (Input.GetKey(KeyCode.I))
        {
            inv.Add(ItemData.CreateItem(Random.Range(0, 3)));
        }
    }
    private void OnGUI()
    {
        if (showInv && !PauseMenu.isPaused)
        {

            scr = new Vector2(Screen.width / 16, Screen.height / 9);
            DisplayInv();
            if (selectedItem == null)
            {
                return;
            }
            else
            {
                UseItem();
            }
        }
    }

    void DisplayInv()
    {
        //If we have a Type Selected (Filter)
        if (!(sortType == "All" || sortType == ""))
        {

        }
        //All items shown
        else
        {
            if (inv.Count <= 34)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(scr.x * 0.5f, scr.y * 0.25f + i * (scr.y * 0.25f), scr.x * 3, scr.y * 0.25f), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
            }
            //We have more Items than Screen Space
            else
            {
                //Our Move position of our scroll window 
                scrollPos =
                //The Start of our scroll view
                GUI.BeginScrollView(
                //Our position and size of window    
                new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.5f * scr.y),
                //our current position in the scroll view
                scrollPos,
                //viewable area 
                new Rect(0, 0, 0, inv.Count * (0.25f * scr.y)),
                //Can we see our horizontal bar?
                false,
                //can we see our Vertical bar?
                 true);
                #region Scrollable View
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(scr.x * 0.5f, i * (scr.y * 0.25f), scr.x * 3, scr.y * 0.25f), inv[i].Name))
                    {
                        selectedItem = inv[i];
                    }
                }
                #endregion
                GUI.EndScrollView();

            }
        }
    }

    void UseItem()
    {
        GUI.Box(new Rect(scr.x * 4, scr.y * 0.5f, scr.x * 3, scr.y * .25f), selectedItem.Name);
        GUI.Box(new Rect(scr.x * 4, scr.y * 1.5f, scr.x * 3, scr.y * 3), selectedItem.IconName);
        GUI.Box(new Rect(scr.x * 4, scr.y * 1, scr.x * 3, scr.y * .25f), selectedItem.Description + "\nValue" + selectedItem);
        switch (selectedItem.ItemTypes)
        {
            case ItemTypes.Armour:
                if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Equip"))
                {

                }
                break;
            case ItemTypes.Weapon:
                {
                    if (equippedItems[1].equippedItem == null || selectedItem.Name != equippedItems[1].equippedItem.name)
                    {
                        if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Equip"))
                        {
                            if (equippedItems[1].equippedItem == null)
                            {
                                Destroy(equippedItems[1].equippedItem);
                            }
                            equippedItems[1].equippedItem = Instantiate(selectedItem.MeshName, equippedItems[1].location);
                            equippedItems[1].equippedItem.name = selectedItem.Name;
                        }

                    }
                    else
                    {
                        if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Unequip"))
                        {
                            Destroy(equippedItems[1].equippedItem);
                            equippedItems[1].equippedItem = null;
                        }
                    }
                }
                break;
            case ItemTypes.Potion:
                if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Use"))
                {

                }
                break;
            case ItemTypes.Food:
                if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Use"))
                {

                }
                break;
            case ItemTypes.Ingredient:
                if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Cook"))
                {

                }
                break;
            case ItemTypes.Craftable:
                if (GUI.Button(new Rect(4 * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Craft"))
                {

                }
                break;
            default:
                break;
        }
        if (GUI.Button(new Rect(5.5f * scr.x, 5 * scr.y, scr.x * 1.5f, scr.y * .25f), "Discard"))
        {
            //Check if Item is Equipped
            for (int i = 0; i < equippedItems.Length; i++)
            {
                if (equippedItems[i].equippedItem != null && selectedItem.Name == equippedItems[i].equippedItem.name)
                {
                    //if so Destroy from Scene
                    Destroy(equippedItems[i].equippedItem);
                }
            }
            //Spawn Item at drop location
            GameObject itemToDrop = Instantiate(selectedItem.MeshName, dropLocation.position, Quaternion.identity);
            //apply gravity and make sure its name corrrectly
            itemToDrop.name = selectedItem.Name;
            itemToDrop.AddComponent<Rigidbody>().useGravity = true;
            //is amount greater then 1 if so reduce list
            if (selectedItem.Amount > 1)
            {
                selectedItem.Amount--;
            }
            else //else remove from list
            {
                inv.Remove(selectedItem);
                selectedItem = null;
                return;
            }
        }
    }
}
