using UnityEngine;
using System.Collections;

public class rockScript : MonoBehaviour {
	public GameObject Character;
	public NavMesh nav;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "EndRock") {
			Character.GetComponent<RustyMovement> ().push = false;
			Character.GetComponent<Animator> ().SetBool ("Push", false); 

		}
	}
}
