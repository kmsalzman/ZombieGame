using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDirection : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    private Vector3 heading;
    private Vector3 direction;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*target = WaveSpawner.GetComponent<>;

        heading = target.transform.position - player.transform.position;
        distance = heading.magnitude;
        direction = heading / distance;

        Debug.Log("Direction: " + direction);*/
    }
}
