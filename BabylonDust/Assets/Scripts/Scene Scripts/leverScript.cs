using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class leverScript : MonoBehaviour {
	public UnityEvent Activate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			GetComponent<Animator> ().enabled = true;
			Activate.Invoke ();
		}
	}
}
