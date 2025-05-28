using UnityEngine;

// Esse script é responsável por criar instâncias de paredes

public class PrefabWallFactory : IWallFactory
{
    private GameObject wallPrefab;
    private float downScaleFactor;
    private float height = 2.5f;
    private float thickness = 0.1f;
    private Transform parentTransform;

    public PrefabWallFactory(GameObject wallPrefab, float downScaleFactor, Transform parentTransform)
    {
        this.wallPrefab = wallPrefab;
        this.downScaleFactor = downScaleFactor;
        this.parentTransform = parentTransform;
    }

    public GameObject CreateWall(WallData data)
    {
        Vector3 start = new Vector3(data.x0, 0, -data.y0) * downScaleFactor;
        Vector3 end = new Vector3(data.x1, 0, -data.y1) * downScaleFactor;

        Vector3 position = (start + end) / 2;
        position.y += height / 2f;

        float length = Vector3.Distance(start, end);

        Vector3 scale;
        if (data.orientation == "horizontal")
        {
            scale = new Vector3(length, height, thickness);
        }
        else
        {
            scale = new Vector3(thickness, height, length);
        }

        GameObject wall = GameObject.Instantiate(wallPrefab, position, Quaternion.identity, parentTransform);
        wall.transform.localScale = scale;

        return wall;
    }
}
