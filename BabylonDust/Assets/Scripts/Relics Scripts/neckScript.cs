using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class neckScript : MonoBehaviour {
	public UnityEvent active;
	public GameObject relicController;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider Col){
		if (Col.tag == "Player") {
			relicController.GetComponent<RelicController> ().relicNeck = 1;
			active.Invoke ();
		}
	}
}
