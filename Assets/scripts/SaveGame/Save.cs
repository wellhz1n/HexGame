using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save
{
    private static string path = Application.persistentDataPath + "/BestScore.well";
    public static void SaveBestScore()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream f = new FileStream(path, FileMode.Create);

        formatter.Serialize(f, SaveClass.BestScore.ToString());
        f.Close();

    }
    public static void LoadBestScore()
    {
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream(path, FileMode.Open);


            SaveClass.BestScore = Convert.ToInt32(formatter.Deserialize(f));
            f.Close();

        }
        else
        {
            SaveBestScore();
        }
    }

}
public static class SaveMoney
{
    private static string pathm = Application.persistentDataPath + "/Money.well";
    public static void SaveMoneys()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream f = new FileStream(pathm, FileMode.Create);

        formatter.Serialize(f, SaveClass.Money.ToString());
        f.Close();

    }
    public static void LoadMoney()
    {
        if (File.Exists(pathm))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream f = new FileStream(pathm, FileMode.Open);


            SaveClass.Money = Convert.ToInt32(formatter.Deserialize(f));
            f.Close();

        }
        else
        {
            SaveMoneys();
        }
    }
}
