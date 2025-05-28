using System;

[Serializable]
// Esse script é o responsável por armazenar os dados de uma parede lidos do JSON

public class WallData
{
    public float x0;
    public float y0;
    public float x1;
    public float y1;
    public float width;
    public float height;
    public string orientation;
    public string @class;
}
