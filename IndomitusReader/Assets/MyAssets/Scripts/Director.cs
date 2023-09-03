using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {

    public GameObject TextGO;

    private IGameDirector gameDirector;
	// Use this for initialization
	void Start () {
        gameDirector = new DiscoveryGameDirector();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
        {
            TestButtonClicked("Sign_R-2");
        }
        if (Input.GetMouseButtonDown(1))
        {
            TestButtonClicked("Sign_R-301_30kmph");
        }
	}

    public void ButtonClicked(GameObject go)
    {
        gameDirector.ButtonClicked(go);
    }

    private void TestButtonClicked(string name)
    {
        gameDirector.TestButtonClicked(name, TextGO);
    }
}
