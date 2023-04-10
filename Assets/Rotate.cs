using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody myRigidBody = GetComponent<Rigidbody>();
        myRigidBody.AddTorque(Vector3.one);
        Material myMaterial = GetComponent<MeshRenderer>().material;
        myMaterial.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
