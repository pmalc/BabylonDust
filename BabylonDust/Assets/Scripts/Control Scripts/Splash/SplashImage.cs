using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashImage : MonoBehaviour {

    public int seg;
    public int numScene;


    // Use this for initialization
    void Start () {
        StartCoroutine("Countdown");
	}

    private IEnumerator Countdown() {
        yield return new WaitForSeconds(seg);
        SceneManager.LoadScene(numScene);
    }
}
