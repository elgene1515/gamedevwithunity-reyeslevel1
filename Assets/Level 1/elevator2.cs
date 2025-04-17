using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator2 : MonoBehaviour
{
    public Transform upperPos;
    public Transform lowerPos;
    public Transform elevatorPos;

    public float speed;
    bool goingUp = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startElevator();

    }

    private void startElevator()
    {
        if (goingUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
            if (Vector2.Distance(upperPos.position, elevatorPos.position) < 0.1)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, lowerPos.position, speed * Time.deltaTime);
            if (Vector2.Distance(lowerPos.position, elevatorPos.position) < 0.1)
            {
                goingUp = true;
            }
        }
    }
}
