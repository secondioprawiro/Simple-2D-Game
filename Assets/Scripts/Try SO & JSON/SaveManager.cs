using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public CharacterData characterSource;

    [System.Serializable]
    public class SaveData
    {
        public string savedName;
        public int savedLevel;
        public int savedHealth;
    }

    public void SaveGame()
    {
        //move data from SO to class
        SaveData data = new SaveData();
        data.savedName = characterSource.characterName;
        data.savedLevel = characterSource.level;
        data.savedHealth = characterSource.health;

        //change to json
        string json = JsonUtility.ToJson(data, true);

        //write into file 
        string path = Application.persistentDataPath + "/savegame.json";
        File.WriteAllText(path, json);

        Debug.Log("Game save to: " + path);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame.json";
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
