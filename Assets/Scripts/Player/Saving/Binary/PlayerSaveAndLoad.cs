using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    public PlayerHandler player;
    public float x, y, z;
    public float rotX, rotY, rotZ, rotW;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Loaded"))
        {
            PlayerPrefs.DeleteAll();
            Load(player);
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binay Data
        }
        else
        {
            //Load Binary 
        }
    }
    public void Save(PlayerHandler player)
    {
        PlayerSaveToBinary.SavePlayerData(player);
    }

    // Update is called once per frame
    public void Load(PlayerHandler player)
    {
        PlayerDataToSave data = PlayerSaveToBinary.LoadData(player);
        player.name = data.playerName;

        player.maxHealth = data.maxHealth;
        player.maxMana = data.maxMana;
        player.maxStamina = data.maxStamina;

        player.curHealth = data.curHealth;
        player.curMana = data.curMana;
        player.curStamina = data.curStamina;

        player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
        player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);

    }
}
