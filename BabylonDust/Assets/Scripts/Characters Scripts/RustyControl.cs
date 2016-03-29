using UnityEngine;
using System.Collections;

public class RustyControl : MonoBehaviour {
	public GameObject characterController;
	public int armAttack;
	public int arrowAttack;
	public int orbPoints;
	public float velPush = 0.01f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Arm") {
			characterController.GetComponent<characterController> ().character3Hp -= armAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
			collision.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (tag == "Orb") {
			characterController.GetComponent<characterController> ().points += orbPoints;
		}
		if(tag == "Arrow"){
			characterController.GetComponent<characterController> ().character3Hp -= arrowAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
	}
	void OnCollisionStay(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Rock") {
			if (GetComponent<RustyMovement> ().push) {
				if (Input.GetKey (KeyCode.W)) {
					transform.Translate (Vector3.forward * velPush);
					collision.gameObject.transform.Translate (transform.forward * velPush);
				}else if (Input.anyKeyDown){
					GetComponent<RustyMovement> ().push = false;
					GetComponent<NavMeshAgent> ().enabled = true;
					GetComponent<Animator> ().SetBool ("Push", false); 
				}
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				GetComponent<RustyMovement> ().push = true;
				GetComponent<NavMeshAgent> ().enabled = false;
				GetComponent<Animator> ().SetBool ("Push", true); 

			}
			}
		}
}
