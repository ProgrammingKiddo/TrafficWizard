using UnityEngine;

public class Cursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Vector3 headPosition;
    private Vector3 gazeDirection;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // FixedUpdate is called in every physics step
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
            meshRenderer.enabled = true;

            // Move the cursor to the point where the raycast hit.
            this.transform.position = hitInfo.point;

            // Rotate the cursor to hug the surface of the hologram.
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            // If the raycast did not hit a hologram, hide the cursor mesh.
            meshRenderer.enabled = false;
        }
    }
}