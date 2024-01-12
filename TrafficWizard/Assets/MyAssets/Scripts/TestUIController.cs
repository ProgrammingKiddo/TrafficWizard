using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUIController : MonoBehaviour {

    public Director director;
    public GameObject questionGO;
    public GameObject[] answersGO;
    public Text currentScoreText;
    public Text maxScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateScoreText(int newCurrentTestScore, int newMaxTestScore)
    {
        currentScoreText.text = newCurrentTestScore.ToString();
        maxScoreText.text = newMaxTestScore.ToString();
    }
}
