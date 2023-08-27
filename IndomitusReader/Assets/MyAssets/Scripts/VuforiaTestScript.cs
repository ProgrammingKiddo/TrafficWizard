using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuforiaTestScript : MonoBehaviour {

    private ImageTargetBehaviour imageTargetBehaviour;
    private ImageTarget imageTarget;
    private string imageTargetName;

	// Use this for initialization
	void Start () {
        /*imageTargetBehaviour = GetComponent<ImageTargetBehaviour>();
        imageTarget = imageTargetBehaviour.ImageTarget;
        imageTargetName = imageTarget.Name;*/
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTrackedDisplayNameOnConsole()
    {

    }
}
