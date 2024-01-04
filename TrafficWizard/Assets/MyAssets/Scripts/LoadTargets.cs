using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;


public class LoadTargets : MonoBehaviour, IUserDefinedTargetEventHandler {

    private string dataSetPath = "Vuforia/TrafficSign_Database.xml";
    private string targetName = "Sign_R-2";

    private UserDefinedTargetBuildingBehaviour userDefinedTargetBuildingBehaviour;

    // Use this for initialization
    void Start () {
        /*VuforiaApplication.Instance.OnVuforiaInitialized += OnVuforiaInitialized;
        userDefinedTargetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
        userDefinedTargetBuildingBehaviour = new UserDefinedTargetBuildingBehaviour();
        if (userDefinedTargetBuildingBehaviour)
        {
            Debug.Log("Target building behaviour set!");
            userDefinedTargetBuildingBehaviour.RegisterEventHandler(this);
        }*/
        //ImageTargetBehaviour targetBehaviour = GetComponent<ImageTargetBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateImageTarget()
    {
        Debug.Log("Iniciada creación del target.");
        string newTargetName = "Sign_R-2";
        userDefinedTargetBuildingBehaviour.BuildNewTarget(newTargetName, 0.5f);
    }


    // Implementation of IUserDefinedTargetEventHandler methods

    public void OnInitialized()
    {

    }

    public void OnNewTrackableSource()
    {

    }

    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality x)
    {

    }

    public void OnNewTrackableSource(TrackableSource x)
    {
        Debug.Log("Creado el target " + x.ToString());
    }
}
