using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public static class SaveSystem
{
    public static void SaveData(CurrentGameDatatoconfig Datacontainers, string savename)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        var folder = Directory.CreateDirectory(Application.persistentDataPath+"/Save");
        string path = Application.persistentDataPath + "/Save/" + savename;
        FileStream stream = new FileStream(path, FileMode.Create);

        CurrentData data = new CurrentData(Datacontainers);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CurrentData LoadSave(string savename)
    {
        string path = Application.persistentDataPath + "/Save/" + savename;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CurrentData data = formatter.Deserialize(stream) as CurrentData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("save not found ");
            return null;
        }
    }

    public static void DeleteSave(string savename)
    {
        File.Delete(Application.persistentDataPath + "/Save/" + savename);
    }
}
