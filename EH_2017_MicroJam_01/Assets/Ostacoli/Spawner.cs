using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> Obstacles;
    public float ObstacleDelay = 5f;
    float currentDelay = 0;

	// Use this for initialization
	void Start () {
        currentDelay = ObstacleDelay;
	}
	
	// Update is called once per frame
	void Update () {
        currentDelay -= Time.deltaTime;
        if(currentDelay <= 0)
        {
            Instantiate(Obstacles[Random.Range(0, Obstacles.Count)], transform).transform.parent = null;
            currentDelay = ObstacleDelay;
        }
	}
}
