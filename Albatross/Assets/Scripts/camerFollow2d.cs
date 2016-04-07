using UnityEngine;
using System.Collections;

public class camerFollow2d : MonoBehaviour {

    public Transform target; //target to follow
    public float smoothing; //dampening

    Vector3 offset;

    float lowY; 

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;

        lowY = transform.position.y -20; 
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
	}
}
