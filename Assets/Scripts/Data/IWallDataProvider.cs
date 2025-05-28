using System.Collections.Generic;

// Esse script é responsável por abstrair a fonte de dados das paredes
public interface IWallDataProvider
{
    IEnumerable<WallData> LoadWalls();
}
