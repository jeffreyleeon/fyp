using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace FYP.Score{
	
	[System.Serializable]
	public class PlayerScore {
		public string name;
		public int score;
	};

	public sealed class Scoreboard : MonoBehaviour {

		static List<ScoreObserver> scoreObservers = new List<ScoreObserver>();

		public static void AddObserver(ScoreObserver observer){
			scoreObservers.Add (observer);
		}

		public static void RemoveObserver(ScoreObserver observer){
			scoreObservers.Remove (observer);
		}
			
		public static void  AddLocalPlayerScore(int score){
			PhotonNetwork.player.AddScore (score);
			NotifyAllObservers ();
		}

		public static int GetLocalPlayerScore(){
			return PhotonNetwork.player.GetScore ();
		}

		public static List<PlayerScore> GetAllPlayerScore(){
			List<PlayerScore> scoreList = new List<PlayerScore> ();
			foreach (PhotonPlayer player in PhotonNetwork.playerList) {
				PlayerScore temp = new PlayerScore ();
				temp.name = player.name;
				temp.score = player.GetScore ();
				scoreList.Add (temp);
			}
			return scoreList;
		}

		/// <summary>
		/// Notifies all observers by GetLocalPlayerScore()
		/// </summary>
		private static void NotifyAllObservers(){
			foreach (ScoreObserver observer in scoreObservers) {
				observer.UpdateScore (GetLocalPlayerScore ());
			}
		}
	}

}