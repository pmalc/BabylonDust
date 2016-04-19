using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerWriting : MonoBehaviour {

    public Image messageBox;
    public string message;
    public Text hudtext;
    public Sprite characterface;
    public Image characterimage;

    bool showmessage = false;
    private string subcadena = "";
    int i;
    private float destroyTime = 0;
    private bool stop = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Linx") {
            if (!showmessage){
                showmessage = true;
                i = 0;
            }
        }
       
    }

    void FixedUpdate()
    {
        if (showmessage && !stop)
        {
            subcadena = message.Substring(0, i);
            Show_Message(subcadena);
            i++;
            if (subcadena.Length == message.Length)
            {
                showmessage = false;
                destroyTime = Time.time + 5;
                stop = true;
            }
        }

        if (Time.time > destroyTime && destroyTime > 0)
        {
            Hide_Message();
            Destroy(this.gameObject);
        }

    }
    public void Show_Message(string subcadena)
    {
        hudtext.text = subcadena;
        messageBox.color = new Color(1, 1, 1, 1);
        characterimage.color = new Color(1, 1, 1, 1);
        characterimage.sprite = characterface;
    }

    public void Hide_Message()
    {
        hudtext.text = "";
        messageBox.color = new Color(1, 1, 1, 0);
        characterimage.color = new Color(1, 1, 1, 0);
        characterimage.sprite = characterface;
    }


}
