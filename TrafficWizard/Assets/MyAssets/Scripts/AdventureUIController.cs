using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureUIController : MonoBehaviour {

    public Text targetSignText;
    public Text currentScoreText;
	
    public void UpdateTargetSignText(string signName)
    {
        targetSignText.text = "Señal a encontrar: " + signName;
    }

    public void UpdateCurrentScoreText(int score)
    {
        currentScoreText.text = "Puntuación actual: " + score;
    }
}
