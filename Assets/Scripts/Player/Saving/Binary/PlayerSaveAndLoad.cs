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
            FirstLoad();
            PlayerPrefs.SetInt("Loaded", 0);
            //Save Binay Data
            Save();
        }
        else
        {
            //Load Binary 
            Load();
        }
    }
    void FirstLoad()
    {
        player.maxHealth = 300;
        player.maxMana =100;
        player.maxStamina = 100;
        player.curCheckPoint = GameObject.Find("First CheckPoint").GetComponent<Transform>();

        player.curHealth = 300;
        player.curMana = 100;
        player.curStamina = 100;

        player.transform.position = new Vector3(1, 1, 1);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);

    }
    public void Save()
    {
        PlayerSaveToBinary.SavePlayerData(player);
    }

    // Update is called once per frame
    public void Load()
    {
        PlayerDataToSave data = PlayerSaveToBinary.LoadData(player);
        player.name = data.playerName;
        player.curCheckPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>();
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
