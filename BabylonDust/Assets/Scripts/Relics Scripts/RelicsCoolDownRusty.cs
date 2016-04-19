using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RelicsCoolDownRusty : MonoBehaviour {

	//Este script se encarga de controlar el cooldown de las reliquias de cada personaje y a su vez el cambio de reliquias (HUD)
	//Crear dos variables y de los coolDownTime y coolDownAmount, hacer un if en la función activateRelic()

	//Reliquias Imagenes
	public Image Relic1Selected;
	public Image Relic2Selected;

	private Image relicCDFilling;//Imagen del Hud CoolDownLeoline
	private bool reduceCD1;
	private bool reduceCD2;

	private float coolDownTime1;
	public float coolDownAmount1;//Timepo de coolDown de la primera reliquia

	private float coolDownTime2;
	public float coolDownAmount2;//Timepo de coolDown de la segunda reliquia

	void Start(){
		coolDownTime1 = coolDownAmount1;
		coolDownTime2 = coolDownAmount2;
		relicCDFilling = this.GetComponent<Image>();	
		Relic1Selected = GameObject.Find ("Relic1").GetComponent<Image> ();
		Relic2Selected = GameObject.Find ("Relic2").GetComponent<Image> ();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)){
			changeRelicImages ();
		}

		if(Input.GetKeyDown(KeyCode.Q)){
			if(Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia1Selected")){
				reduceCD1 = true;	
			}
			if(Relic2Selected.sprite == Resources.Load<Sprite>("Sprites/Reliquia2Selected")){
				reduceCD2 = true;
			}
		}	
		activateRelic ();
	}

	//Activa el cooldown
	void activateRelic(){
		if(coolDownTime1 >= 0 && reduceCD1){
			coolDownTime1 -= Time.deltaTime;
			if(coolDownTime1 <= 0){
				reduceCD1 = false;
				coolDownTime1 = coolDownAmount1;
			}
			//relicCDFilling.fillAmount = coolDownTime1 / coolDownAmount1;
			showCoolDown ();
		}

		if(coolDownTime2 >= 0 && reduceCD2){
			coolDownTime2 -= Time.deltaTime;
			if(coolDownTime2 <= 0){
				reduceCD2 = false;
				coolDownTime2 = coolDownAmount2;
			}
			//relicCDFilling.fillAmount = coolDownTime2 / coolDownAmount2;
			showCoolDown ();
		}
	}

	void showCoolDown(){
		if(Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia1Selected")){
			relicCDFilling.fillAmount = coolDownTime1 / coolDownAmount1;
		}
		if(Relic2Selected.sprite == Resources.Load<Sprite>("Sprites/Reliquia2Selected")){
			relicCDFilling.fillAmount = coolDownTime2 / coolDownAmount2;
		}
	}

	//Pregunta si se puede cambiar la reliquia si el cooldown esta en descenso
	void changeRelicImages(){
		//Single Player

		//if(Player1 == 1){//Llamar al objeto state controller
		if (Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia1Selected") /*&& coolDownTime == coolDownAmount*/
			&& Relic1Selected.enabled == true && Relic2Selected.enabled == true) {

			Relic1Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia1");
			Relic2Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia2Selected");

		} else if(Relic1Selected.sprite == Resources.Load<Sprite> ("Sprites/Reliquia1") /*&& coolDownTime == coolDownAmount*/
			&& Relic2Selected.enabled == true){

			Relic1Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia1Selected");
			Relic2Selected.sprite = Resources.Load<Sprite> ("Sprites/Reliquia2");

		}
		//}
		//if(Player2 == 1){
		//}

		//if(Player3 == 3){
		//}

		//Multiplayer
	}
}