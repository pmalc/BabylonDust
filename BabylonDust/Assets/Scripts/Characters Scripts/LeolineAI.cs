using UnityEngine;
using System.Collections;

public class LeolineAI : MonoBehaviour {
    public GameObject controllerObject;
    public GameObject character1;
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
    void Start()
    {
        control = controllerObject.GetComponent<characterState>();
        anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Obtengo el valor de actividad que tiene el character 1. Si obtengo 0 el character1 esta controlado por la IA
        int active = control.player2Active;

        if (active == 0) {

            // Calculo quien es el leader
            GetLeader();
            animLeader = charLeader.GetComponent<Animator>();
            // Dependiendo del estado en el que se encuentre el personaje leader, entrare en los diferentes estados.
            if (animLeader.GetBool("Movement"))
            {
                anim.SetBool("Movement", true);
                if (isOnLeaderSight())
                {
                    Evade();
                }
                Arrive();


            }
            else {
                anim.SetBool("Movement", false);
            }


        }
    }
    bool isOnLeaderSight()
    {

        Vector3 direction = transform.position - charLeader.transform.position;
        float angle = Vector3.Angle(direction, charLeader.transform.forward);
        if (angle <= leaderSightRadius) {
            return true;
        }
        else
        {
            return false;
        }

    }

    void GetLeader() {
        if (control.multiplayer) {
            /*float x = (character1.transform.position.x + character3.transform.position.x) / 2;
            float y = (character1.transform.position.y + character3.transform.position.y) / 2;
            float z = (character1.transform.position.z + character3.transform.position.z) / 2;
            charLeader.transform.position = new Vector3(x, y, z);*/
            charLeader = character1;
        } else {

            int leader = control.characterActive1;
            switch (leader) {
                case 0:
                    charLeader = character1;
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



    void Arrive() {
        Vector3 direction = charLeader.transform.position - transform.position;
        direction.y = 0;

        float distance = direction.magnitude;

        float decelerationFactor = distance / 5;

        float speed = moveSpeed * decelerationFactor;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        Vector3 moveVector = direction.normalized * Time.deltaTime * speed;
        /*Debug.Log("Antiguo: " + moveVector);
        if (Vector3.Distance(transform.position, charOther.transform.position) <= 10)  {
            moveVector.x += charOther.transform.position.x - transform.position.x;
            moveVector.y += charOther.transform.position.y - transform.position.y;
            Debug.Log("Nuevo: " + moveVector);
        }*/
        transform.position += moveVector;
    }
    void Evade()
    {
        int iterationAhead = 30;
        Vector3 leaderSpeed = charLeader.GetComponent<Rigidbody>().velocity;
        Vector3 targetFuturePosition = charLeader.transform.position + (leaderSpeed * iterationAhead);

        Vector3 direction = transform.position - targetFuturePosition;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        if (direction.magnitude < safeDistance)
        {

            Vector3 moveVector = direction.normalized * moveSpeed * Time.deltaTime;
            
            transform.position += moveVector;

        }
    }

    /*void separation() {
        Vector3 moveVector;
        int neighborCount = 0;
 
        for (int i = 0; i<2; i++) {
            var b :Boid = Game.instance.boids[i];
 
            if (b != this && distance(b, this) <= SEPARATION_RADIUS) {
                force.x += b.position.x - this.position.x;
                force.y += b.position.y - this.position.y;
                neighborCount++;
            }
        }
 
        if (neighborCount != 0) {
            force.x /= neighborCount;
            force.y /= neighborCount;
 
            force.scaleBy( -1);
        }
 
        force.normalize();
        force.scaleBy(MAX_SEPARATION);
 
        }*/

}