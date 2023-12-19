using UnityEngine;

public class ButtonCommand : MonoBehaviour
{
    public Director director;
    private GameObject parentGO;

    void Start()
    {
        parentGO = this.transform.parent.gameObject;
        Debug.Log(parentGO.name);
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    /*public void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (this.GetComponent<AudioSource>())
        {
            this.GetComponent<AudioSource>().Play();
        }
        director.ButtonClicked(parentGO);
    }*/
    public void OnSelect()
    {
        // Disable the child
        if (this.gameObject.name == "Sprite_Walltext_30km")
        {
            Debug.Log("Called OnSelect() from 30kmh Signal");
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponentInChildren<Transform>().gameObject.SetActive(false);
            Debug.Log("Called OnSelect() from Stop Signal");
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnSelect();
        }
    }
}