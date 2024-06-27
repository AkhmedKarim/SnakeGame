using System;
public static class DifficultController
{
	public enum Difficult
	{
		Easy,
		Medium,
		Hard
	}
	public static Difficult currentDifficult = Difficult.Easy;
}

