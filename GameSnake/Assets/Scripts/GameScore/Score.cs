using System;

[Serializable]
public class Score
{
    public string name;
    public int points;
    public Score(int points, string name)
    {
        this.name = name;
        this.points = points;
    }
}