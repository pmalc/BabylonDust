using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour {
	public int character1Hp = 100;
	public int character2Hp = 100;
	public int character3Hp = 100;
	public int points = 0;
	public int numCollectables = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (character1Hp <= 0 || character2Hp <= 0 || character3Hp <= 0) {
			SceneManager.LoadScene ("DeadScene");
		}
	
	}
	void LateUpdate(){
		if (character1Hp > 100) {
			character1Hp = 100;
		}
		if (character2Hp > 100) {
			character2Hp = 100;
		}
		if (character3Hp > 100) {
			character3Hp = 100;
		}
	}
}
