using UnityEngine;
using System.Collections;



public class LeolineMovement : MonoBehaviour {
	public float velWalk = 0.05f;
	public float velRun= 0.075f;
	public float velRotation = 2.0f;
	public float vel;
	public float velClimb = 0.01f;
	public GameObject controlOject;
	public GameObject controls;
	public bool climb = false;
	public float jumpForce = 2.0f;
    private Rigidbody rigi;
    // Use this for initialization
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
		//Vemos si esta activo el personaje
		//Si es 0 no estará activo, si es 1 lo controla el jugador 1 y si es 2 lo controla el jugador 2
		int active = controlOject.GetComponent<characterState> ().player2Active;



		switch (active) {
		//Si está descativado
		case 0:
                rigi.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                GetComponent<NavMeshAgent> ().enabled = true;
			break;
			//Si lo controla el jugador 1
		case 1:
                rigi.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

                //antes de cambair el movimiento lo iniciamos a falso
                GetComponent<Animator> ().SetBool ("Movement", false); 
			if (Input.anyKey) {
				GetComponent<NavMeshAgent> ().enabled = false;
				movement(active);
			}
			break;
		case 2:
                rigi.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

                //antes de cambair el movimiento lo iniciamos a falso
                GetComponent<Animator> ().SetBool ("Movement", false); 
			if (Input.anyKey) {
				GetComponent<NavMeshAgent> ().enabled = false;
				movement(active);
			}
			break;
		}

	}



	void movement(int player){
		//En el caso de que estemos escalando tenemos un caso especial
		if (climb) {
			switch (player) {
			//Controles del jugador 1
			case 1:
				if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Move_Forward1)) {
					transform.Translate (Vector3.up * velClimb);
				}
				break;
			case 2:
				if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Move_Forward2)) {
					transform.Translate (Vector3.up * velClimb);
				}
				break;
				} 
		
		} else {

			switch (player) {
			//Controles del jugador 1
			case 1:
				if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Move_Forward1)) {
					GetComponent<Animator> ().SetBool ("Movement", true);
					transform.Translate (Vector3.forward.normalized * vel);
				}if (Input.GetKey (controls.GetComponent<controlsController> ().PC_Sprint1) && GetComponent<Animator> ().GetBool ("Movement")) {
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
					GetComponent<Rigidbody> ().AddForce ((transform.forward + transform.up)*jumpForce, ForceMode.Impulse);
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
					GetComponent<Rigidbody> ().AddForce ((transform.forward + transform.up)*jumpForce, ForceMode.Impulse);
				}
				break;

			}
		}
	}
}