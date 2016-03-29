using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerMessage : MonoBehaviour {
    public string message;
    public Text hudtext;

    void OnTriggerEnter(Collider col){
        hudtext.text = message;
    }

    void OnTriggerExit(Collider col)
    {
        hudtext.text = "";
    }
}
