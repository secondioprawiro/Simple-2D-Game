using UnityEngine;
using System.IO; // Wajib untuk tulis file

public class SaveSystem : MonoBehaviour
{
    public GameObject playerObj;

    private string saveFileName = "savegame.json";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        // get data hero
        PlayerData data = new PlayerData();

        HealthSystem health = playerObj.GetComponent<HealthSystem>();
        if (health != null) data.currentHealth = health.currentHealth;

        // Ambil Posisi
        data.positionX = playerObj.transform.position.x;
        data.positionY = playerObj.transform.position.y;
        data.positionZ = playerObj.transform.position.z;

        // change to JSON (String)
        string json = JsonUtility.ToJson(data, true);

        //write into file
        string path = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(path, json);

        Debug.Log("Game Saved ke: " + path);
    }

    public void LoadGame()
    {
        string path = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(path))
        {
            // read file
            string json = File.ReadAllText(path);

            // change JSON into Object C#
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            // 3. Terapkan ke Hero

            // Set Posisi
            Vector3 loadPos = new Vector3(data.positionX, data.positionY, data.positionZ);
            playerObj.transform.position = loadPos;

            // Set HP
            HealthSystem health = playerObj.GetComponent<HealthSystem>();
            if (health != null) health.currentHealth = data.currentHealth;

            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.Log("Save file tidak ditemukan!");
        }
    }
}