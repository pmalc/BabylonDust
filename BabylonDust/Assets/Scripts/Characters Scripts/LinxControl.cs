using UnityEngine;
using System.Collections;

public class LinxControl : MonoBehaviour {
	public GameObject characterController;
	public int armAttack;
	public int arrowAttack;
	public int orbPoints;
	//public GameObject reliccontroller;
	//public GameObject controls;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//if pulsamos la reliquia y no está el cooldow y está activa
		/*characterController.GetComponent<characterController>().character1Hp += 100;
		characterController.GetComponent<characterController>().character2Hp += 100;
		characterController.GetComponent<characterController>().character3Hp += 100;*/
	}
	void OnTriggerEnter(Collider collision){
		string tag = collision.tag;
		if (tag == "Arm") {
			collision.gameObject.GetComponent<BoxCollider> ().enabled = false;
			characterController.GetComponent<characterController> ().character1Hp -= armAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
		if (tag == "Orb") {
			characterController.GetComponent<characterController> ().points += orbPoints;
			Destroy (collision.gameObject);
		}
		if(tag == "Arrow"){
			characterController.GetComponent<characterController> ().character1Hp -= arrowAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
	}
}
