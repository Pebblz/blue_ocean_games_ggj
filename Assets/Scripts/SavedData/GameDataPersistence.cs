public interface GameDataPersistence
{
    void LoadData(GameData data);

    void SaveData(ref GameData data);
}