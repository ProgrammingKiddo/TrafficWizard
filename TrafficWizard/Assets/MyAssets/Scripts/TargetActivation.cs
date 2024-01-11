using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetActivation : MonoBehaviour {


    void OnEnable()
    {
        Debug.Log("Target " + transform.parent.gameObject.name + " activated.");
        Camera.main.gameObject.GetComponent<Director>().TargetTracked(transform.parent.gameObject.name);
    }
}
