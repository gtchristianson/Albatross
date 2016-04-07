using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour {

    public Renderer rend;
	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
	}

    void OnMouseEnter()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.cyan;
    }
	
    void OnMouseExit()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }

}
