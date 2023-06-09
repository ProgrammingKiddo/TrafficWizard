using UnityEngine;

public class ButtonCommand : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (this.GetComponent<AudioSource>())
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}