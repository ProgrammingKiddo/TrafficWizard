using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

public class Director : MonoBehaviour {

    public GameObject TextGO;
    public GameObject testTargetGO;
    public GameObject Cube;

    private IGameDirector gameDirector;
    private GameObject createdGO;
    private Vector3 eulerAngleVelocity = new Vector3(10f, 10f, 0f);
    // Use this for initialization
    void Start () {
        gameDirector = new DiscoveryGameDirector();
        //createdGO = Instantiate<GameObject>(Cube);
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
/*
    void FixedUpdate()
    {
        Debug.Log("Camera: " + Camera.main.transform.position);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
        createdGO.GetComponent<Rigidbody>().MoveRotation(createdGO.GetComponent<Rigidbody>().rotation * deltaRotation);
        Debug.Log("Cube: " + createdGO.transform.position);
    }
*/
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
