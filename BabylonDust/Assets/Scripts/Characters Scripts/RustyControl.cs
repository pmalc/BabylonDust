using UnityEngine;
using System.Collections;

public class RustyControl : MonoBehaviour {
	public GameObject characterController;
	public int armAttack;
	public int arrowAttack;
	public int orbPoints;
	public float velPush = 0.01f;
	private GameObject Col;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GetComponent<RustyMovement> ().push) {
			if (Input.GetKey (KeyCode.W)) {
				Col.transform.position =  Col.transform.position + transform.forward * velPush;
				transform.Translate (Vector3.forward * velPush);
			}else if (Input.anyKeyDown || Input.GetKeyUp(KeyCode.W)){
				GetComponent<RustyMovement> ().push = false;
				GetComponent<NavMeshAgent> ().enabled = true;
				GetComponent<Animator> ().SetBool ("Push", false); 
			}
		}

	}
	void OnTriggerEnter(Collider collision){
		string tag = collision.tag;
		if (tag == "Arm") {
			characterController.GetComponent<characterController> ().character3Hp -= armAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
			collision.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}
		if (tag == "Orb") {
			characterController.GetComponent<characterController> ().points += orbPoints;
			Destroy (collision.gameObject);
		}
		if(tag == "Arrow"){
			characterController.GetComponent<characterController> ().character3Hp -= arrowAttack;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * 2.0f, ForceMode.Impulse);
		}
	}
	void OnCollisionStay(Collision collision){
		string tag = collision.collider.tag;
		if (tag == "Rock" && GetComponent<RustyMovement>().active !=0) {
			Col = collision.gameObject;
			if (Input.GetKeyDown (KeyCode.E)) {
				GetComponent<RustyMovement> ().push = true;
				GetComponent<NavMeshAgent> ().enabled = false;
				GetComponent<Animator> ().SetTrigger ("PushTrigger");
				GetComponent<Animator> ().SetBool ("Push", true); 

			}
			}
		}
}
