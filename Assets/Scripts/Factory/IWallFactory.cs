using UnityEngine;

// Esse script � respons�vel por abstrair a cria��o de GameObjects de parede
public interface IWallFactory
{
    GameObject CreateWall(WallData data);
}
