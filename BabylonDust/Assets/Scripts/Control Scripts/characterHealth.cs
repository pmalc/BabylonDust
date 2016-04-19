using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterHealth : MonoBehaviour {
	public Slider healthLinx;
	public Slider healthLeoline;
	public Slider healthRusty;
	public GameObject healthObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		healthLinx.value = healthObject.GetComponent<characterController> ().character1Hp;
		healthLeoline.value = healthObject.GetComponent<characterController> ().character2Hp;
		healthRusty.value = healthObject.GetComponent<characterController> ().character3Hp;
	}
}
