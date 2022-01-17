using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;
    public string namePlayer;
    public string newName;
    public int points;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }

    [System.Serializable]
    class SaveData {
        public string name;
        public int maxPoints;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.name = namePlayer;
        data.maxPoints = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "savefileBlock.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "savefileBlock.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("nombre: "+data.name);
            Debug.Log("puntos: " + data.maxPoints);
            namePlayer = data.name;
            points = data.maxPoints;
        }
    }
}
