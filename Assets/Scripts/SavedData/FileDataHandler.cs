using System.IO;
using System;
using UnityEngine;

public class FileDataHandler
{
    private string dataPath = " ";
    private string gameDataFileName = " ";
    private string settingsDataFileName = " ";

    public FileDataHandler(string _DataPath, string _gameDataFileName, string _settingsDataFileName)
    {
        this.dataPath = _DataPath;
        this.gameDataFileName = _gameDataFileName;
        this.settingsDataFileName = _settingsDataFileName;
    }


    public GameData LoadGameData()
    {
        string fullPath = Path.Combine(dataPath, gameDataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        return loadedData;
    }
    public void SaveGameData(GameData data)
    {
        string fullPath = Path.Combine(dataPath, gameDataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
    public SettingsData LoadSettings()
    {
        string fullPath = Path.Combine(dataPath, settingsDataFileName);
        SettingsData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<SettingsData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
        return loadedData;
    }
    public void SaveSettings(SettingsData data)
    {
        string fullPath = Path.Combine(dataPath, settingsDataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
