using UnityEngine;
using System.Collections;

public class LeolineControl : MonoBehaviour {
	public GameObject characterController;
	public int armAttack;
	public int arrowAttack;
	public int orbPoints;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Arm") {
			collision.gameObject.GetComponent<BoxCollider> ().enabled = false;
			characterController.GetComponent<characterController> ().character2Hp -= armAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
		if (tag == "Orb") {
			characterController.GetComponent<characterController> ().points += orbPoints;
		}
		if(tag == "Arrow"){
			characterController.GetComponent<characterController> ().character2Hp -= arrowAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
	}
	void OnCollisionStay(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Wall") {
			if (Input.GetKey (KeyCode.E)) {
				GetComponent<LeolineMovement> ().climb = true;
				GetComponent<Rigidbody> ().useGravity = false;
				GetComponent<Animator> ().SetBool ("Climb", true); 
			}
		}
	}
	void OnCollisionExit(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Wall") {
				GetComponent<LeolineMovement> ().climb = false;
				GetComponent<Rigidbody> ().useGravity = true;
				GetComponent<Animator> ().SetBool ("Climb", false); 
		}
	}
}
