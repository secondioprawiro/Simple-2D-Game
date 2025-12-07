using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Test : MonoBehaviour
{
    CharacterData characterData;
    int damage = 20;
    int damageTaken;

    [System.Serializable]
    public class SaveData
    {
        public string savedName;
        public int savedLevel;
        public int savedHealth;
    }

    void Start()
    {
        if(characterData == null)
        {
            characterData = ScriptableObject.CreateInstance<CharacterData>();
        }

        characterData.characterName = "Antimage";
        characterData.level = 10;
        characterData.health = 100;
    }   

    public void TakeDamage()
    {
        string path = Application.persistentDataPath + "/savegame2.json";
        if (File.Exists(path))
        {
            characterData.health = characterData.health - damage;
            Debug.Log("Terkena damage! Sisa HP: " + characterData.health);
        }
        else
        {
            Debug.Log("Tidak bisa mengurangkan damage file tidak ditemukan");
        }
        
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.savedName = characterData.characterName;
        data.savedLevel = characterData.level;
        data.savedHealth = characterData.health;

        string json = JsonUtility.ToJson(data, true);

        string path = Application.persistentDataPath + "/savegame2.json";
        File.WriteAllText(path, json);

        Debug.Log("Game save to: " + path);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame2.json";
        if (File.Exists(path))
        {
            //read text file
            string json = File.ReadAllText(path);

            //change into class
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded: " + data.savedName +
                "\nLevel: " + data.savedLevel +
                "\nHealth: " + data.savedHealth);
        }
        else
        {
            Debug.LogError("Save file tidak ditemukan!");
        }
    }
}