using UnityEngine;

public class ButtonCommand : MonoBehaviour
{
    public Director director;
    private GameObject parentGO;

    void Start()
    {
        parentGO = this.transform.parent.gameObject;
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    public void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (this.GetComponent<AudioSource>())
        {
            this.GetComponent<AudioSource>().Play();
        }
        director.ButtonClicked(parentGO);
    }
}