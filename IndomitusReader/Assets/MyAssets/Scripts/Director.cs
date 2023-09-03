using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

public class Director : MonoBehaviour {

    public GameObject TextGO;
    public GameObject testTargetGO;

    private IGameDirector gameDirector;
	// Use this for initialization
	void Start () {
        gameDirector = new DiscoveryGameDirector();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            //TestButtonClicked("Sign_R-2");
            ButtonClicked(testTargetGO);
        }
        if (Input.GetMouseButtonDown(1))
        {
            TestButtonClicked("Sign_R-301_30kmph");
        }
        if (Input.GetMouseButtonDown(2))
        {
            ButtonClicked(testTargetGO);
        }
        /*if (Input.anyKeyDown)
        {
            ButtonClicked(testTargetGO);
        }*/
	}

    public void ButtonClicked(GameObject go)
    {
        Debug.Log("Processing buttonclicked() for " + go.name);
        // Change text on the target button
        gameDirector.ButtonClicked(go);
        // Change UI text
        gameDirector.TestButtonClicked(go.GetComponentInParent<ImageTargetBehaviour>().ImageTarget.Name, TextGO);
        Debug.Log("Done all ButtonClicked() stuff");
    }

    private void TestButtonClicked(string name)
    {
        gameDirector.TestButtonClicked(name, TextGO);
    }
}
