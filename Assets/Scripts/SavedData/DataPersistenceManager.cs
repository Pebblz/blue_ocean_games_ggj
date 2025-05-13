using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string gameFileName;
    [SerializeField] private string settingsFileName;
    private FileDataHandler dataHandler;

    public GameData gameData;
    private SettingsData settingsData;
    public static DataPersistenceManager instance { get; private set; }
    private List<GameDataPersistence> dataPersistenceList;
    private List<SettingDataPersistence> settingsDataList;
    private void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        //else if (instance != null)
        //{
        //    Destroy(gameObject);
        //}
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, gameFileName, settingsFileName);
        this.dataPersistenceList = FindAllDataPersistenceObjects();
        this.settingsDataList = FindAllSettingDataPersistenceObjects();
        LoadGame();
        LoadSettings();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
        dataHandler.SaveGameData(gameData);
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.LoadGameData();

        if (this.gameData == null)
        {
            NewGame();
        }
        foreach (GameDataPersistence p in dataPersistenceList)
        {
            p.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        foreach (GameDataPersistence p in dataPersistenceList)
        {
            p.SaveData(ref gameData);
        }
        dataHandler.SaveGameData(gameData);
    }
    public void LoadSettings()
    {
        this.settingsData = dataHandler.LoadSettings();
        if (settingsData == null)
        {
            return;
        }
        foreach (SettingDataPersistence p in settingsDataList)
        {
            p.LoadData(settingsData);
        }
    }
    public void SaveSettings()
    {
        if (settingsData == null)
            this.settingsData = new SettingsData();

        foreach (SettingDataPersistence p in settingsDataList)
        {
            p.SaveData(ref settingsData);
        }
        dataHandler.SaveSettings(settingsData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
        SaveSettings();
    }
    private List<GameDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<GameDataPersistence> dataPersistence = FindObjectsOfType<MonoBehaviour>().OfType<GameDataPersistence>();

        return new List<GameDataPersistence>(dataPersistence);
    }
    private List<SettingDataPersistence> FindAllSettingDataPersistenceObjects()
    {
        IEnumerable<SettingDataPersistence> dataPersistence = FindObjectsOfType<MonoBehaviour>().OfType<SettingDataPersistence>();

        return new List<SettingDataPersistence>(dataPersistence);
    }
}
