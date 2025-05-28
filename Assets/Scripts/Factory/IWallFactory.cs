using UnityEngine;

// Esse script é responsável por abstrair a criação de GameObjects de parede
public interface IWallFactory
{
    GameObject CreateWall(WallData data);
}
