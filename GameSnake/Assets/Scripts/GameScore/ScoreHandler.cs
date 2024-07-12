using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class ScoreHandler
{
	public static string scoresFilePath => Application.persistentDataPath + "/score.snakeScoreData";

	static ScoreHandler()
	{
    }

	public static void SaveScore(Score score)
	{
		Score[] oldScores = LoadScorese();
		Score[] newScores = new Score[oldScores.Length];

		newScores[0] = score;
		for (int i = 1; i < newScores.Length; i++)
		{
			newScores[i] = oldScores[i-1];
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(scoresFilePath, FileMode.Create);

        formatter.Serialize(stream, newScores);
        stream.Close();
    }

    public static Score[] LoadScorese()
	{
		if (File.Exists(scoresFilePath))
		{
			FileStream stream = new FileStream(scoresFilePath, FileMode.Open);

			BinaryFormatter formatter = new BinaryFormatter();
			Score[] scores = formatter.Deserialize(stream) as Score[];

			stream.Close();

			return scores;
		}


		var emptyScoreArray = new Score[5];
		for (int i = 0; i < emptyScoreArray.Length; i++)
		{
			emptyScoreArray[i] = new Score(0, "\t");
        }

		return emptyScoreArray;

	}
}