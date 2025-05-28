// Esse script é responsável por carregar o JSON de paredes e instanciar os GameObjects na cena.
using System.IO;
using UnityEngine;

public class WallLoader : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private float downScaleFactor = 0.04f;
    [SerializeField] private string jsonFileName = "walls.json";

    private IWallDataProvider provider;
    private IWallFactory factory;

    private void Start()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        provider = new JsonWallDataProvider(filePath);
        GameObject parent = new GameObject("Walls");
        factory = new PrefabWallFactory(wallPrefab, downScaleFactor, parent.transform);

        foreach (WallData data in provider.LoadWalls())
        {
            factory.CreateWall(data);
        }
    }
}
