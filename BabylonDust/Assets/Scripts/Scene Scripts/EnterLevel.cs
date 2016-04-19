using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour {

	public int numScene = 6;
    void OnTriggerEnter(Collider col) {
		SceneManager.LoadScene(numScene);
    }
}
