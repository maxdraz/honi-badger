using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    BoxCollider2D cameraBox;
    GameObject player;

	// Use this for initialization
	void Start () {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        FollowPlayer();
	}

    void FollowPlayer()
    {
        BoxCollider2D boundary = GameObject.Find("Boundary").GetComponent<BoxCollider2D>();

        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, boundary.bounds.min.x + cameraBox.size.x / 2, boundary.bounds.max.x - cameraBox.size.x/2),
                                         Mathf.Clamp(player.transform.position.y, boundary.bounds.min.y + cameraBox.size.y / 2, boundary.bounds.max.y - cameraBox.size.y/2),
                                         transform.position.z);
    }
}
