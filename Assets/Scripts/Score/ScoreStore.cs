using UnityEngine;
using System.Collections;

public sealed class ScoreStore{

	private static ScoreStore instance = new ScoreStore();

	private ScoreStore () {
	}

	public static ScoreStore GetInstance () {
		return instance;
	}
}
