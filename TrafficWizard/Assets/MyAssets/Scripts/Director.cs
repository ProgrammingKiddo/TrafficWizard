using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class Director : MonoBehaviour {

    public GameObject VersionTextGO;
    public GameObject OptionPanelsGO;
//public GameObject testTargetGO;

    private IGameDirector gameDirector;
    private GameObject createdGO;
    private Vector3 eulerAngleVelocity = new Vector3(10f, 10f, 0f);
    // Use this for initialization
    void Start () {
        gameDirector = new DiscoveryGameDirector();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void ButtonClicked(GameObject go)
    {
        Debug.Log("Processing buttonclicked() for " + go.name);
        if (go.CompareTag("Settings_Button"))
        {
            // Turn on/off the option panels
            OptionPanelsGO.SetActive(!OptionPanelsGO.activeSelf);
        }
        else
        {
            VersionTextGO.GetComponent<Text>().text = "Current mode: " + go.GetComponentInChildren<Text>().text;
        }
        // Change text on the target button
        //gameDirector.ButtonClicked(go);
        // Change UI text
        //gameDirector.TestButtonClicked(go.GetComponentInParent<ImageTargetBehaviour>().ImageTarget.Name, TextGO);
        //Debug.Log("Done all ButtonClicked() stuff");
    }

    private void TestButtonClicked(string name)
    {
        gameDirector.TestButtonClicked(name, VersionTextGO);
    }
}
