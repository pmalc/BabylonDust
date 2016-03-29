using UnityEngine;
using System.Collections;

public class Enemy1AI : MonoBehaviour {
	public Transform[] Targets; // los tres personajes objetivos
	public GameObject[] Enemys;  //enemigos que van a ser activados cuando este se active
	public float activateRange; // rango de activación del enemigo
	public float attackRange = 2.0f; //distancia cuerpo a cuerpo para atacar
	private float range; //range es una variable que uso para comparar cual de ellos está más cerca
	public bool inRange = false ; //Variable que controla si el enemigo esta en rango o no
	private int target = 0; // personaje al que va a atacar
	public float rotationVel = 5.0f; // velocidad de rotación
	private bool canAttack = true; //Variable que controla de velocidad con la que hace ataques
	private int time = 0; // contador de tiempo para volver a atacar
	public int attackVel = 3; //Tiempo en segundos para volver a atacar
	NavMeshAgent agent; // el agente de la navegación
	Animator anim;
	public int hp = 100;//Vida del enemigo
	public GameObject orbPrefab;
	private bool dead = false;



	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.stoppingDistance = attackRange;
		anim = GetComponent<Animator> ();
	
	}

	void Update () {
		if (hp <= 0) {
			if (!dead) {
				anim.SetTrigger ("Dead");
				dead = true;
				Instantiate (orbPrefab, transform.position,transform.rotation);
			}
		} else {
			FindTarget ();
			//Buscamos el objetivo mas cercano y en caso de que este por debajo del rango de activación inRange se pone a true
			if (inRange) {
				for (int i = 0; i < Enemys.Length; i++) {
					Enemys [i].GetComponent<Enemy1AI> ().inRange = true;
				}
				//En el caso de que el enemigo esté en rango hacemos las acciones pertinentes atacar o movernos hacia el
				if (range <= attackRange) {
					if (canAttack) {
						LookAtPlayer ();
						Attack ();
					}
				} else {
					Move ();
				}
			}
			//funcion encargada de descontar el tiempo hasta volver a atacar
			if (!canAttack) {
				time += 1;
				if (time == 30 * attackVel) {
					canAttack = true;
				}
			}

		}
	}

	void FindTarget(){
		range = activateRange;
		//calculamos la distancia a cada uno de los personajes y nos quedamos con la menor
		for (int i = 0; i < Targets.Length; i++){
			float distance = Vector3.Distance (Targets [i].position, transform.position);
			if (distance < range) {
				inRange = true;
				target = i;
				range = distance;
			}
		}
	}
	void Attack(){
		GetComponentInChildren<BoxCollider> ().enabled = true;
		anim.SetTrigger ("Attack");
		canAttack = false;
		time = 0;
	}
	void Move(){
		agent.SetDestination(Targets[target].position);
	}
	void LookAtPlayer(){
		//Definimos la nueva rotación que tendrá
		Quaternion rotation = Quaternion.LookRotation (new Vector3(Targets [target].position.x,0.0f,Targets [target].position.z) - new Vector3(transform.position.x,0.0f,transform.position.z));
		//Hacemos que ire con la velocidad que hemos indicado
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationVel);
	}
}