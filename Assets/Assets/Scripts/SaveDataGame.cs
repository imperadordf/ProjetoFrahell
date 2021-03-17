using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveDataGame
{
    public static void SaveGame(string namePath,object saveObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + string.Format("/{0}.fun",namePath);
        FileStream stream = new FileStream(path, FileMode.Create);

        var objectSave = saveObject;

        formatter.Serialize(stream, objectSave);
        stream.Close();
    }

    public static object LoadGame(string namePath)
    {
        string path = Application.persistentDataPath+ string.Format("/{0}.fun", namePath);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            var objectData = formatter.Deserialize(stream);
            stream.Close();
            return objectData;
        }
        else
        {
            return null;
        }
       
    }
}
