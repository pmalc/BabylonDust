using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RelicController : MonoBehaviour {

	//Este script se encarga de pintar el HUD a medida que se avanza en el juego //Script en paralelo RelicsCoolDown.cs

	//Imagenes del HUD CoolDown
	public Image CoolDownLeoline;
	public Image CoolDownLinx;
	public Image CoolDownRusty;

	//Imagenes del HUD Relics
	public Image Relic1Selected;
	public Image Relic2Selected;
	public Image Relic3Selected;
	public Image Relic4Selected;
	public Image Relic5Selected;
	public Image Relic6Selected;


	//Reliquias
	public int relicNeck = 0; 
	public int relicBrazalet = 0;
	public int relicRing = 0;
	public int relicEar = 0;
	public int relicPin = 0;
	public int relicCrown = 0;

	//GameObject Canvas
	public GameObject hud;

	// Use this for initialization
	void Start () {

		//CoolDown Imagenes
		CoolDownLeoline = GameObject.Find("RelicCDLeoline").GetComponent<Image>();
		CoolDownLeoline.enabled = false;

		CoolDownLinx = GameObject.Find("RelicCDLinx").GetComponent<Image>();
		CoolDownLinx.enabled = false;

		CoolDownRusty = GameObject.Find("RelicCDRusty").GetComponent<Image>();
		CoolDownRusty.enabled = false;

		//Relics Imagenes
		Relic1Selected = GameObject.Find ("Relic1").GetComponent<Image> ();
		Relic1Selected.enabled = false;

		Relic2Selected = GameObject.Find ("Relic2").GetComponent<Image> ();
		Relic2Selected.enabled = false;

		Relic3Selected = GameObject.Find ("Relic3").GetComponent<Image> ();
		Relic3Selected.enabled = false;

		Relic4Selected = GameObject.Find ("Relic4").GetComponent<Image> ();
		Relic4Selected.enabled = false;

		Relic5Selected = GameObject.Find ("Relic5").GetComponent<Image> ();
		Relic5Selected.enabled = false;

		Relic6Selected = GameObject.Find ("Relic6").GetComponent<Image> ();
		Relic6Selected.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Keypad1)){
			relicNeck = 1;
			appearRelics ();
		}else if(Input.GetKey(KeyCode.Keypad2)){
			relicBrazalet = 1;
			appearRelics ();
		}else if(Input.GetKey(KeyCode.Keypad3)){
			relicRing = 1;
			appearRelics ();
		}else if(Input.GetKey(KeyCode.Keypad4)){
			relicEar = 1;
			appearRelics ();
		}else if(Input.GetKey(KeyCode.Keypad5)){
			relicPin = 1;
			appearRelics ();
		}else if(Input.GetKey(KeyCode.Keypad6)){
			relicCrown = 1;
			appearRelics ();
		}
	}

	void appearRelics(){

		//Leoline
		switch(relicNeck){
		case 0:
			CoolDownLeoline.enabled = false;
			Relic1Selected.enabled = false;
			break;
		case 1:
			CoolDownLeoline.enabled = true;
			Relic1Selected.enabled = true;
			break;
		case 2:
			break;
		}

		switch(relicBrazalet){
		case 0:
			Relic2Selected.enabled = false;
			break;
		case 1:
			Relic2Selected.enabled = true;
			break;
		case 2:
			break;
		}

		//Linx
		switch(relicRing){
		case 0:
			CoolDownLinx.enabled = false;
			Relic3Selected.enabled = false;
			break;
		case 1:
			CoolDownLinx.enabled = true;
			Relic3Selected.enabled = true;
			break;
		case 2:
			break;
		}
		
		switch(relicEar){
		case 0:
			Relic4Selected.enabled = false;
			break;
		case 1:
			Relic4Selected.enabled = true;
			break;
		case 2:
			break;
		}

		//Rusty
		switch(relicPin){
		case 0:
			CoolDownRusty.enabled = false;
			Relic5Selected.enabled = false;
			break;
		case 1:
			CoolDownRusty.enabled = true;
			Relic5Selected.enabled = true;
			break;
		case 2:
			break;
		}

		switch(relicCrown){
		case 0:
			Relic6Selected.enabled = false;
			break;
		case 1:
			Relic6Selected.enabled = true;
			break;
		case 2:
			break;
		}
	}
}
