using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath;

    public static void savePlayer(PlayerAttributes playerAttr, PlayerInventory playerInv, GameObject playerObj)
    {
        BinaryFormatter bin = new BinaryFormatter();
        string currentPath = path + "/player.bin";
        FileStream stream = new FileStream(currentPath, FileMode.Create);

        PlayerData data = new PlayerData(playerAttr, playerInv, playerObj);
   
        bin.Serialize(stream, data);
        stream.Close();

    }

    public static void savePlayerQuests(PlayerAttributes playerAttr)
    {
        BinaryFormatter bin = new BinaryFormatter();
        string currentPath = path + "/quests.bin";
        FileStream stream = new FileStream(currentPath, FileMode.Create);

        QuestData data = new QuestData(playerAttr.activeQuests);

        bin.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData loadPlayer()
    {
        string currentPath = path + "/player.bin";

        if (File.Exists(currentPath))
        {
            BinaryFormatter bin = new BinaryFormatter();
            
            FileStream stream = new FileStream(currentPath, FileMode.Open);


            PlayerData data = bin.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }

        return null;
    }

    public static QuestData loadQuests()
    {
        string currentPath = path + "/quests.bin";

        if (File.Exists(currentPath))
        {
            BinaryFormatter bin = new BinaryFormatter();

            FileStream stream = new FileStream(currentPath, FileMode.Open);

            QuestData data = bin.Deserialize(stream) as QuestData;
            stream.Close();
            return data;
        }

        return null;
    }

}
