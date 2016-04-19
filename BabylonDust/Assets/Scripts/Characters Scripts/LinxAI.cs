using UnityEngine;
using System.Collections;

public class LinxAI : MonoBehaviour {

    public GameObject controllerObject;
    public GameObject character2;
    public GameObject character3;
	public float activateRadius = 5.0f;
	private Vector3 destination;
	private Vector3 stopdestination;
	public bool follow = false;

    characterState control;
    GameObject charLeader;
    Animator anim;
    Animator animLeader;

    // Use this for initialization
    void Start () {
        control = controllerObject.GetComponent<characterState>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // Obtengo el valor de actividad que tiene el character 1. Si obtengo 0 el character1 esta controlado por la IA
        int active = control.player1Active;
        if(active == 0){

            // Calculo quien es el leader
            GetLeader();

            if (follow || (destination - transform.position).magnitude > activateRadius ) {
				Arrive ();
                follow = true;
            }
			animLeader = charLeader.GetComponent<Animator>();
            // Dependiendo del estado en el que se encuentre el personaje leader para ver que animacion hacemos
            if (GetComponent<NavMeshAgent>().hasPath)
            {
                anim.SetBool("Movement", true);
                anim.SetFloat("Walk/Run", animLeader.GetFloat("Walk/Run"));
            }
            else {
                anim.SetBool("Movement", false);
                follow = false;
            }
        }
        else {

			GetComponent<NavMeshAgent> ().enabled = false;
		}
        
    }



void GetLeader() {
        if (control.multiplayer){
            charLeader = character2;
        } else {

            int leader = control.characterActive1;
            switch (leader){
				case 1:
					charLeader = character2;
				GetComponent<NavMeshAgent> ().speed = charLeader.GetComponent<LeolineMovement> ().vel * (1 / Time.deltaTime);
					destination =charLeader.transform.position+  charLeader.transform.forward * -5 + charLeader.transform.right * -5;
	                break;
                case 2:
                    charLeader = character3;
				GetComponent<NavMeshAgent> ().speed = charLeader.GetComponent<RustyMovement> ().vel * (1 / Time.deltaTime);
					destination =charLeader.transform.position+ charLeader.transform.forward * -5 + charLeader.transform.right * 5;
                    break;
                default:
                    charLeader = this.gameObject;
                    break;

            }
        }

    }

    void Arrive()
    {
        if (GetComponent<NavMeshAgent>().SetDestination(destination))
        {
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
  

    }



}
