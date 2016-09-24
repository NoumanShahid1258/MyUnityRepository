using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Player {

	public Image panel;
	public Text text;


}
[System.Serializable]
public class PlayerColor {

	public Color panelColor;
	public Color textColor;

}

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	private string playerSide;
	public GameObject gameOverPanel;
	public GameObject restartButton;
	public Text gameOverText;
	private int moveCount;
	public Player playerX;
	public Player playerO;
	public PlayerColor activePlayerColor;
	public PlayerColor inactivePlayerColor;

	public void SetGameControllerReferenceOnButtons() {

		for (int i=0; i<buttonList.Length; i++) {

			buttonList[i].GetComponentInParent<GridSpace>().SetControllerReference(this);
		
		
		}

	}

	void Awake (){

		SetGameControllerReferenceOnButtons ();
		playerSide = "X";
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);
		SetPlayerColor (playerX, playerO);
	}

	public string GamePlayerSide () {

		return playerSide;

	}

	public void EndTurn () {

		moveCount++;

		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			GameOver (playerSide);
		} else if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			GameOver (playerSide);
		} else if (moveCount >= 9) {

			GameOver ("draw");
		} else {
			ChangeSide ();
		}
	}

	void GameOver (string winingPlayer) {

		SetBoardInterectable (false);
		if (winingPlayer == "draw") {
			SetGameOverText("It's draw");

		} 
		else {
			SetGameOverText (playerSide + " Wins!");
		}

		restartButton.SetActive (true);
	}

	void ChangeSide () {

		playerSide = (playerSide == "X") ? "O" : "X";

		if (playerSide == "X") {

			SetPlayerColor(playerX,playerO);
		} 
		else {

			SetPlayerColor(playerO, playerX);
		
		}

	}

	void SetGameOverText(string value){
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}

	public void RestartGame () {

		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive (false);
		SetBoardInterectable (true);
		restartButton.SetActive (false);
		SetPlayerColor (playerX, playerO);
		for (int i=0; i< buttonList.Length; i++) {
			

			buttonList[i].text = "";
		}
	}

	void SetBoardInterectable (bool toggle) {
		for (int i=0; i< buttonList.Length; i++) {
			
			buttonList[i].GetComponentInParent<Button>().interactable = toggle;
		}
	}

	void SetPlayerColor (Player newPlayer, Player oldPlayer){

		newPlayer.panel.color = activePlayerColor.panelColor;
		newPlayer.text.color = activePlayerColor.textColor;
		oldPlayer.panel.color = inactivePlayerColor.panelColor;
		oldPlayer.text.color = inactivePlayerColor.textColor;
	}




}
