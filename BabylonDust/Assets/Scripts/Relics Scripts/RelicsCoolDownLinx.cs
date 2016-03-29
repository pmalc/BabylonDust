using UnityEngine;
using System.Collections;

public class RelicsCoolDownLinx : MonoBehaviour {
	
	//Este script se encarga de controlar el cooldown de las reliquias de cada personaje y a su vez el cambio de reliquias (HUD)
	/*
	//Reliquias Imagenes
	public Image Relic3Selected;
	public Image Relic4Selected;

	private Image relicCDFilling;//Imagen del Hud CoolDownLeoline
	private bool reduceCD;
	private float coolDownTime;

	public float coolDownAmount;//Tiempos de los coolDown

	void Start(){
		coolDownTime = coolDownAmount;
		relicCDFilling = this.GetComponent<Image>();	
		Relic1Selected = GameObject.Find ("Relic3").GetComponent<Image> ();
		Relic2Selected = GameObject.Find ("Relic4").GetComponent<Image> ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			changeRelicImages ();
		}
		if(Input.GetKeyDown(KeyCode.Q) || reduceCD){
			reduceCD = true;
			activateRelic ();
		}	
	}

	//Activa el cooldown
	void activateRelic(){
		if(coolDownTime >= 0){
			coolDownTime -= Time.deltaTime;
			if(coolDownTime <= 0){
				reduceCD = false;
				coolDownTime = coolDownAmount;
			}
			relicCDFilling.fillAmount = coolDownTime / coolDownAmount;
		}
	}

	//Pregunta si se puede cambiar la reliquia si el cooldown esta en descenso
	void changeRelicImages(){
		//Single Player

		//if(Player1 == 1){    //Llamar al objeto state controller
		if (Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia3Selected") && coolDownTime == coolDownAmount
			&& Relic1Selected.enabled == true && Relic2Selected.enabled == true) {

			Relic1Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia3");
			Relic2Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia4Selected");

		} else if(Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia3") && coolDownTime == coolDownAmount 
			&& Relic2Selected.enabled == true){

			Relic1Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia3Selected");
			Relic2Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia4");

		}
		//}
		//if(Player2 == 1){
		//}

		//if(Player3 == 3){
		//}

		//Multiplayer
	}*/
}
