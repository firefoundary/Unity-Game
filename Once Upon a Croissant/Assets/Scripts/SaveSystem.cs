using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem {
    
    public static void SaveProgress (bool beatBoss) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.lel";
        FileStream stream = new FileStream(path, FileMode.Create);

        ProgressData data = new ProgressData();
        
        if (beatBoss) {
            data.beatBoss = true;
        }
        

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("progress saved");
    }

    public static ProgressData LoadProgress () 
    {
        string path = Application.persistentDataPath + "/progress.lel";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            ProgressData data = formatter.Deserialize(stream) as ProgressData;
            stream.Close();

            return data;

        } 
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
