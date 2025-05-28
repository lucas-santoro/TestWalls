using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Esse script � respons�vel por ler o arquivo walls.json e fornecer os dados de parede

public class JsonWallDataProvider : IWallDataProvider
{
    private readonly string filePath;

    public JsonWallDataProvider(string filePath)
    {
        this.filePath = filePath;
    }

    public IEnumerable<WallData> LoadWalls()
    {
        var json = File.ReadAllText(filePath);
        var wrapper = JsonUtility.FromJson<WallDataList>(json);
        return wrapper?.walls ?? new List<WallData>();
    }
}
