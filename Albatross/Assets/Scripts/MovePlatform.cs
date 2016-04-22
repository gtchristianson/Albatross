using UnityEngine;
using System.Collections;

public class MovePlatform: MonoBehaviour
{

    public Transform platform;
    private Vector3 newPosition;
    public Vector3 start = new Vector3(-5, 1, 0);
    public Vector3 end = new Vector3(5, 1, 0);
    public string currentState;
    public float smooth = 1;
    public float resetTime = 5;

    void Start()
    {
        ChangeTarget();
    }

    void FixedUpdate()
    {
        platform.position = Vector3.Lerp(platform.position, newPosition, smooth * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (currentState == "Moving To Start")
        {
            currentState = "Moving To End";
            newPosition = end;
        }
        else if (currentState == "Moving To End")
        {
            currentState = "Moving To Start";
            newPosition = start;
        }
        else if (currentState == "")
        {
            currentState = "Moving To End";
            newPosition = end;
        }

        Invoke("ChangeTarget", resetTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(start, platform.localScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(end, platform.localScale);
    }

}



