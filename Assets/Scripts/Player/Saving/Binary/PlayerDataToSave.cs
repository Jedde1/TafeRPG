[System.Serializable]
public class PlayerDataToSave 
{
    //Data....Get from Game
    public string playerName;
    public int level;

    public float maxHealth, maxMana, maxStamina;
    public float curHealth, curMana, curStamina;
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    public PlayerDataToSave(PlayerHandler player)
    {
        playerName = player.name;
        level = 0;

        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        maxStamina = player.maxStamina;

        curHealth = player.curHealth;
        curMana = player.curMana;
        curStamina = player.curStamina;

        pX = player.transform.position.x;
        pY = player.transform.position.z;
        pZ = player.transform.position.z;

        rX = player.transform.rotation.x;
        rY = player.transform.rotation.y;
        rZ = player.transform.rotation.z;
        rW = player.transform.rotation.w;

    }
}
