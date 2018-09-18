using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {
    Transform player;   //reference player transform
    BoxCollider2D managerBox;   //reference box collider 2D of this
    public GameObject boundary; //reference boundary GO
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        managerBox = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        ManageBoundary();
	}

    void ManageBoundary()
    {
        // if player within box collider, set boundary active, else inactive
        if (player.position.x > managerBox.bounds.min.x && player.position.x < managerBox.bounds.max.x
            && player.position.y > managerBox.bounds.min.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
        }
        else boundary.SetActive(false);

    }
}
