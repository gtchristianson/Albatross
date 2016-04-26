using UnityEngine;
using System.Collections;

public class LaserOnOFF : MonoBehaviour {

    public GameObject beam;
    public float waitTime;
    

	// Use this for initialization
	void Start () {

        StartCoroutine(ChangeDirection());
	}
	
	// Update is called once per frame
	void Update () {


	}


    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            beam.SetActive(true);
            yield return new WaitForSeconds(waitTime);
            beam.SetActive(false);

        }
    }

}
