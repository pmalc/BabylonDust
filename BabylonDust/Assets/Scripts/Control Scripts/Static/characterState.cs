using UnityEngine;
using System.Collections;

public class characterState: MonoBehaviour {
	//personajes 1 y 2 activos  ( posicion activa)
	public int characterActive1 = 0;
	public int characterActive2 = 1;
	//variables de activación de la IA/manua para los personajes
	public int player1Active = 1;
	public int player2Active = 0;
	public int player3Active = 0;
	public bool multiplayer = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (multiplayer) {
			//En el caso de que cambiemos a modo multijugador activamos al personaje
			switch (characterActive2) {
			case 0:
				player1Active = 2;
				break;
			case 1:
				player2Active = 2;
				break;
			case 2:
				player3Active = 2;
				break;	
			}
		}else{
			switch (characterActive2) {
			case 0:
				player1Active = 0;
				break;
			case 1:
				player2Active = 0;
				break;
			case 2:
				player3Active = 0;
				break;	
			}
		}
		if (Input.GetKeyDown (KeyCode.Tab) && !multiplayer) {
			//Cambio de presonaje en single player
			changeCharacterSingle ();
		}else if (Input.GetKeyDown (KeyCode.Tab) && multiplayer) {
			//Cambio de pesonaje del jugador 1 en multijugador
			changeCharacterMultiplayer (1 , characterActive1);
		}else if (Input.GetKeyDown (KeyCode.KeypadPlus) && multiplayer) {
			//Cambio de pesonaje del jugador 2 en multijugador
			changeCharacterMultiplayer (2, characterActive2);
		}
	}

	void changeCharacterSingle(){
		characterActive1 += 1;
		switch (characterActive1){
		case 1:
			player1Active = 0;
			player2Active = 1;
			player3Active = 0;
			break;
		case 2:
			player1Active = 0;
			player2Active = 0;
			player3Active = 1;
			break;
		case 3:
			player1Active = 1;
			player2Active = 0;
			player3Active = 0;
			characterActive1 = 0;
			break;
		}
		characterActive2 = characterActive1 + 1;
		if (characterActive2 > 2) {
			characterActive2 = 0;
		}
	}
	void changeCharacterMultiplayer (int player, int characterActive){
		int freecharacter = characterActive1 + characterActive2;
		switch (freecharacter) {
		//el libre es el tercero
		case 1:
			player3Active = player;
			if (player == 1) {
				characterActive1 = 2;
			}else{
				characterActive2 = 2;
			}
			break;
		//el libre es el segundo
		case 2:
			player2Active = player;
			if (player == 1) {
				characterActive1 = 1;
			}else{
				characterActive2 = 1;
			}
			break;
		//el libre es el primero
		case 3:
			player1Active = player;
			if (player == 1) {
				characterActive1 = 0;
			}else{
				characterActive2 = 0;
			}
			break;
		}
		//liberamos el personaje
		switch(characterActive){
		case 0:
			player1Active = 0;
			break;
		case 1:
			player2Active = 0;
			break;
		case 2:
			player3Active = 0;
			break;
		}
	}


}
