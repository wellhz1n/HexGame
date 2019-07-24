using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public static class Save
{

    public static void SaveGame<T>(T obj, string name)
    {
        string named = name ?? "Temp";
        string caminho = Application.persistentDataPath + "/" + named +".well";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream f = new FileStream(caminho, FileMode.Create);

        formatter.Serialize(f, obj);
        f.Close();

    }
    public static T LoadGame<T>(string name)
    {
        string named = name ?? "Temp";
        string caminho = Application.persistentDataPath + "/" + named + ".well";
        T classe = default(T);
        if (File.Exists(caminho))
        {

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream f = new FileStream(caminho, FileMode.Open))
            {
                classe = (T)formatter.Deserialize(f);
            }
        }
        else
            Debug.LogWarning($"Arquivo {name} não existe no caminho {caminho}");

        return classe;
    }
}

