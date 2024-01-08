/*
 * Based on the code by the Microsoft Corporation (2023)
 * https://learn.microsoft.com/en-us/windows/mixed-reality/develop/unity/tutorials/holograms-101
 * 
 * Source cited as per the 'Writing Code' guidelines on Academic Integrity at MIT
 * https://integrity.mit.edu/handbook/writing-code
 */

using UnityEngine;

// This script manages the visualization of the pointer
// on top of thridimensional objects and planes
public class Cursor : MonoBehaviour
{
    private MeshRenderer cursorMeshRenderer;
    private Vector3 headPosition;
    private Vector3 gazeDirection;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        cursorMeshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // FixedUpdate is called in every physics step, and
    // since we're using Raycasts (physics) it's preferrable
    // that we operate in this method instead of Update()
    void FixedUpdate()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        headPosition = Camera.main.transform.position;
        gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram...
            // Display the cursor mesh.
            cursorMeshRenderer.enabled = true;

            // Move the cursor to the point where the raycast hit.
            this.transform.position = hitInfo.point;

            // Rotate the cursor to hug the surface of the hologram.
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            // If the raycast did not hit a 3D object, don't render the cursor's mesh.
            cursorMeshRenderer.enabled = false;
        }
    }
}