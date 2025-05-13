public interface SettingDataPersistence
{
    void LoadData(SettingsData data);

    void SaveData(ref SettingsData data);
}