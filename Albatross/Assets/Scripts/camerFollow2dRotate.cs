using UnityEngine;
using System.Collections;

public class camerFollow2dRotate : MonoBehaviour {

    public Transform target; //target to follow
    public float smoothing; //dampening
    private float ypsilon;
    private playerController script; 
    Vector3 offset;
    Rigidbody2D myRB;
    float lowY; 

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;

        lowY = transform.position.y -20;

       script = (playerController)FindObjectOfType(typeof(playerController));
       

       myRB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        
        ypsilon = script.ypsilon;
        
        myRB.rotation = ypsilon + (float)90; 
        
        



	}
}
