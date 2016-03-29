using UnityEngine;
using System.Collections;

public class LinxAI : MonoBehaviour {

    public GameObject controllerObject;
    public GameObject character2;
    public GameObject character3;

    public float rotationSpeed = 1.0f;
    public float moveSpeed = 6.0f;
    public int minDistance = 5;
    public int safeDistance = 4;
    public float leaderSightRadius = 30.0f;

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
            animLeader = charLeader.GetComponent<Animator>();
            // Dependiendo del estado en el que se encuentre el personaje leader, entrare en los diferentes estados.
            if (animLeader.GetBool("Movement"))
            {
                //Walk/Run
                anim.SetBool("Movement", true);
                if (isOnLeaderSight())
                {
                    Evade();
                }
                Arrive();
            }
            else {
                //Idle
                anim.SetBool("Movement",false);
            }
            
        }
    }

    bool isOnLeaderSight(){
        Vector3 direction = transform.position - charLeader.transform.position;
        float angle = Vector3.Angle(charLeader.transform.forward, direction);
        if (angle < leaderSightRadius)
        {
            return true;
        }
        else {
            return false;
        }
    }

void GetLeader() {
        if (control.multiplayer){
            /*float x = (character2.transform.position.x + character3.transform.position.x)/2;
            float y = (character2.transform.position.y + character3.transform.position.y) / 2;
            float z = (character2.transform.position.z + character3.transform.position.z) / 2;
            charLeader.transform.position = new Vector3(x,y,z); */
            charLeader = character2;
        } else {

            int leader = control.characterActive1;
            switch (leader){
                case 1:
                    charLeader = character2;
                    break;
                case 2:
                    charLeader = character3;
                    break;
                default:
                    charLeader = this.gameObject;
                    break;

            }
        }

    }


    void Arrive()
    {

        Vector3 direction = charLeader.transform.position - transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        float decelerationFactor = distance / 5;

        float speed = moveSpeed * decelerationFactor;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        Vector3 moveVector = direction.normalized * Time.deltaTime * speed;
        transform.position += moveVector;


    }

    void Evade(){
        int iterationAhead = 30;
        Vector3 leaderSpeed = charLeader.GetComponent<Rigidbody>().velocity;
        Vector3 targetFuturePosition = charLeader.transform.position + (leaderSpeed * iterationAhead);

        Vector3 direction = transform.position - targetFuturePosition;
        direction.y = 0;
 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed* Time.deltaTime);
 
        if(direction.magnitude < safeDistance){
 
            Vector3 moveVector = direction.normalized* moveSpeed * Time.deltaTime;

            transform.position += moveVector;
 
        }
    }
 

}
