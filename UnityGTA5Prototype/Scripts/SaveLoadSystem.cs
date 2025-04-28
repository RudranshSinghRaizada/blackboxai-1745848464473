using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public Vector3 position;
        public int health;
        public int money;
    }

    public Transform playerTransform;
    public int playerHealth = 100;
    public int playerMoney = 0;

    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/player.save";
        LoadPlayer();
    }

    public void SavePlayer()
    {
        PlayerData data = new PlayerData();
        data.position = playerTransform.position;
        data.health = playerHealth;
        data.money = playerMoney;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(savePath, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game saved.");
    }

    public void LoadPlayer()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            playerTransform.position = data.position;
            playerHealth = data.health;
            playerMoney = data.money;

            Debug.Log("Game loaded.");
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }
}
