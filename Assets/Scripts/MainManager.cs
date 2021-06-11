using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public Color teamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData 
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        //Create a new instance of the save data and fill its team color clss member with the teamColor variable saved in the MainManager
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        //Transform that instance to JSON
        string json = JsonUtility.ToJson(data);

        //Write string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        //Reverse to SaveColor method
        string path = Application.persistentDataPath + "/savefile.json";
        //Checks if a .json file exist
        if (File.Exists(path))
        {
            //If it does, then the method reads its content
            string json = File.ReadAllText(path);
            //Then transform it back into a SaveData instance
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            //Set the teamColor to the color saved in the SaveData
            teamColor = data.teamColor;
        }
    }
}
