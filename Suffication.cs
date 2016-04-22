using UnityEngine;
using System.Collections;

public class Suffication : MonoBehaviour
    {
    float timeleft = 10;
    // Use this for initialization
    void Start ()
    {
        
	}
	
    void SufferandDie()
    {
        
        var playerObjectX = GameObject.Find("Player").transform.position.x;
        var playerObjectY = GameObject.Find("Player").transform.position.y;
        var playerPosX = playerObjectX;
        var playerPosY = playerObjectY;

        if ((playerPosX > -3 && playerPosY > -5))
        {
            timeleft -= Time.deltaTime;
            Debug.Log(timeleft);
            if (timeleft < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        SufferandDie();
    }
}
