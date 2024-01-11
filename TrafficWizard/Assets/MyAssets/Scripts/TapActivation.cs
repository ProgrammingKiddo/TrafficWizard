using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapActivation : MonoBehaviour {

    public GameObject directorGO;
    public int settingsUIId;

    private Director director;

	// Use this for initialization
	void Start () {
        director = directorGO.GetComponent<Director>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnSelect()
    {
        director.FixedUIButtonClicked(settingsUIId);
    }
}
