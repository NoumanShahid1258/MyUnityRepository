using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;
	private GameController gameController;


	public void SetControllerReference (GameController controller){

		gameController = controller;
	}

	public void SetSpace () {

		buttonText.text = gameController.GamePlayerSide ();
		button.interactable = false;
		gameController.EndTurn ();

	}


}
