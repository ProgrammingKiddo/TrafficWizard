using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour {

    private IGameDirector gameDirector;
	// Use this for initialization
	void Start () {
        gameDirector = new DiscoveryGameDirector();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClicked(GameObject go)
    {
        gameDirector.ButtonClicked(go);
    }
}
