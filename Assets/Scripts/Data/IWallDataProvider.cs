using System.Collections.Generic;

// Esse script � respons�vel por abstrair a fonte de dados das paredes
public interface IWallDataProvider
{
    IEnumerable<WallData> LoadWalls();
}
