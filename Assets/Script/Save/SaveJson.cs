using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJson : MonoBehaviour
{
    private string path;
    private SaveData save;

    void Start()
    {
        save = SaveData.instance;
        path = Path.Combine(Application.persistentDataPath, "SaveData.json");
        LoadDados();
        save.Load();
    }

    public void SaveDados()
    {
        string stringjson = JsonUtility.ToJson(save);
        File.WriteAllText(path, stringjson);
        Debug.Log("Dados salvos: " + stringjson);
    }

    public void LoadDados()
    {
            string stringjson = File.ReadAllText(path);
            JsonUtility.FromJsonOverwrite(stringjson, save);
            
    }

    void Update()
    {
     
    }
}

   

    
