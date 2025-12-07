using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSaveData
    {
        public string name;
        public int currentLevel;
    }

    private void Start()
    {
        //data dummy
        PlayerSaveData myData = new PlayerSaveData();
        myData.name = "Arthur";
        myData.currentLevel = 10;

        //serialize
        string jsonString = JsonUtility.ToJson(myData, true);

        Debug.Log("JSON Result: \n" + jsonString);
    }
}
