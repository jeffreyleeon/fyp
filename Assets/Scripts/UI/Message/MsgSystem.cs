using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public sealed class MsgSystem : MonoBehaviour {

	public static List<MsgObserver> msgObservers = new List<MsgObserver>();

	public static void AddObserver(MsgObserver observer){
		msgObservers.Add (observer);
	}

	public static void RemoveObserver(MsgObserver observer){
		msgObservers.Remove (observer);
	}

	public static void ShowMsg(string msgToShow, float duration){
		foreach( MsgObserver observer in msgObservers){
			observer.ShowMessage (msgToShow, duration);
		}
	}

	public static void StopMsg(){
		foreach( MsgObserver observer in msgObservers){
			observer.StopMessage ();
		}
	}
}
