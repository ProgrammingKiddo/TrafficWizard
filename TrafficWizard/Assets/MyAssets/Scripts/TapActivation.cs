using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapActivation : MonoBehaviour {

    public GameObject directorGO;

    private Director director;

	// Use this for initialization
	void Start () {
        director = directorGO.GetComponent<Director>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            OnSelect();
        }
	}

    public void OnSelect()
    {
        director.ButtonClicked(this.gameObject);
    }
}
