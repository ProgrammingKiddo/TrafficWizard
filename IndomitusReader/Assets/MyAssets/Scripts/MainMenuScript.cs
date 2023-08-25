using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(Camera.main);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene(string SceneName)
    {
        Debug.Log("Changing from scene " + SceneManager.GetActiveScene().name + " to scene " + SceneName + ".");
        SceneManager.LoadScene(SceneName);
    }
}
