using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Suffication : MonoBehaviour
    {
    public float timeleft = 5;
    public Text displayTime;
    // Use this for initialization
    void Start ()
    {
        
	}
	
    void SufferandDie()
    {
        displayTime.text = timeleft.ToString("n2");
        var playerObjectX = GameObject.Find("Player").transform.position.x;
        var playerObjectY = GameObject.Find("Player").transform.position.y;
        var playerPosX = playerObjectX;
        var playerPosY = playerObjectY;

        if ((playerPosX > -3 && playerPosY > -5))
        {
            timeleft -= Time.deltaTime;
            Debug.Log(timeleft.ToString("n2"));
            if (timeleft < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if ((playerPosX < -3 && playerPosY > -5))
        {
            timeleft += Time.deltaTime;
            if (timeleft > 10)
            {
                timeleft = 10;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        SufferandDie();
    }
}
