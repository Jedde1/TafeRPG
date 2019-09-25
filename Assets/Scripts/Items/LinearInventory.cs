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
    #endregion

    private void Start()
    {
        inv.Add(ItemData.CreateItem(300));
        inv.Add(ItemData.CreateItem(301));
        showInv = true;
    }

    private void OnGUI()
    {
        if (showInv)
        {
            
            scr = new Vector2(Screen.width / 16, Screen.height / 9);
            for (int i = 0; i < inv.Count; i++)
            {
                if (GUI.Button(new Rect(scr.x*0.5f,scr.y*0.25f+ i*(scr.y* 0.25f),scr.x*3,scr.y*0.25f),inv[i].Name))
                {
                    selectedItem = inv[i];   
                }
            }
            if (selectedItem == null)
            {
                return;
            }
            else
            {
                GUI.Box(new Rect(scr.x * 6.5f, scr.y * 3, scr.x * 3, scr.y * 3), selectedItem.IconName);
            }
        }
    }
}
