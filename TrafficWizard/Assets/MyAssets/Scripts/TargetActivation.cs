using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetActivation : MonoBehaviour {


    void OnEnable()
    {
        Camera.main.gameObject.GetComponent<Director>().TargetTracked(transform.parent.gameObject.name);
    }
}
