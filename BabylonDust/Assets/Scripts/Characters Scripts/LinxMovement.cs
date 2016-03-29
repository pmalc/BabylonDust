using UnityEngine;
using System.Collections;


public class LinxMovement : MonoBehaviour {
	public float velWalk = 0.05f;
	public float velRun= 0.075f;
	public float velRotation = 2.0f;
	public float vel;
	public GameObject controlOject;
	public GameObject controls;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//Vemos si esta activo el personaje
	//Si es 0 no estará activo, si es 1 lo controla el jugador 1 y si es 2 lo controla el jugador 2
		int active = controlOject.GetComponent<characterState> ().player1Active;

		//antes de cambair el movimiento lo iniciamos a falso
		GetComponent<Animator> ().SetBool ("Movement", false); 

		switch (active) {
		//Si está descativado
		case 0:
			GetComponent<Animator> ().SetBool ("Movement", false);
			GetComponent<NavMeshAgent> ().enabled = true;
			break;
		//Si lo controla el jugador 1
		case 1:
			if (Input.anyKey) {
				movement(active);
				GetComponent<NavMeshAgent> ().enabled = false;
			}
			break;
		case 2:
			if (Input.anyKey) {
				movement(active);
				GetComponent<NavMeshAgent> ().enabled = false;
			}
			break;
		}

	}



	void movement(int player){
		switch (player) {

		//Controles del jugador 1
		case 1:
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Move_Forward1)) {
				GetComponent<Animator> ().SetBool ("Movement", true);
				transform.Translate (Vector3.forward * vel);
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Sprint1) && GetComponent<Animator> ().GetBool ("Movement")) {
				GetComponent<Animator> ().SetFloat ("Walk/Run", 100f);
				vel = velRun;
			} else if (GetComponent<Animator> ().GetBool ("Movement")) {
				GetComponent<Animator> ().SetFloat ("Walk/Run", 0.0f);
				vel = velWalk;
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Rotate_Left1)) {
				transform.Rotate (Vector3.up * velRotation * -1);
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Rotate_Right1)) {
				transform.Rotate (Vector3.up * velRotation);
			}
			if (Input.GetKeyDown (controls.GetComponent<controlsController> ().PC_Jump1)) {
				GetComponent<Animator> ().SetTrigger ("Jump");
			}
			break;

		//Controles del jugador 2
		case 2:
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Move_Forward2)) {
				GetComponent<Animator> ().SetBool ("Movement", true);
				transform.Translate (Vector3.forward * vel);
			} else {
				GetComponent<Animator> ().SetBool ("Movement", false); 
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Sprint2) && GetComponent<Animator> ().GetBool ("Movement")) {
				GetComponent<Animator> ().SetFloat ("Walk/Run", 100f);
				vel = velRun;
			} else if (GetComponent<Animator> ().GetBool ("Movement")) {
				GetComponent<Animator> ().SetFloat ("Walk/Run", 0.0f);
				vel = velWalk;
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Rotate_Left2)) {
				transform.Rotate (Vector3.up * velRotation * -1);
			}
			if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Rotate_Right2)) {
				transform.Rotate (Vector3.up * velRotation);
			}
			if (Input.GetKeyDown (controls.GetComponent<controlsController> ().PC_Jump2)) {
				GetComponent<Animator> ().SetTrigger ("Jump");
			}
			break;
		
				}
	}
}