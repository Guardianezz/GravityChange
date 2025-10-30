using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlateformMouvement : MonoBehaviour
{
    public Transform[] wayPoints;
    [SerializeField] private float speed;
    private int currentPoint;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[currentPoint].position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoints[i].position) < 0.02f)
        {
            i++;
            if(i == wayPoints.Length)
            {
                i = 0;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[i].position, speed * Time.deltaTime);   

    }

}


