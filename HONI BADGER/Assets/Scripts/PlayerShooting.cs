using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public float fireDelay = 0.25f;
    public float coolDownTimer = 0;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    Animator myAnimator;
    float moveX;
    public bool facingRight = true;
	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Shoot();
        coolDownTimer -= Time.deltaTime;
        if (coolDownTimer <= 0)
            coolDownTimer = 0;

        CheckDirection();
        
	}

    void Shoot()
    {
        //Animation
        if (Input.GetButton("Fire1"))
        {
            myAnimator.SetBool("isFiring", true);
        }
        else
            myAnimator.SetBool("isFiring", false);

        //Functionality
        if (Input.GetButton("Fire1") && coolDownTimer <= 0 && facingRight)
        {
            Debug.Log("Firing Right!");
            coolDownTimer = fireDelay;
            
            
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
        else if(Input.GetButton("Fire1") && coolDownTimer <= 0 && !facingRight)
        {
            coolDownTimer = fireDelay;
            Debug.Log(bulletSpawn.rotation);
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation * Quaternion.Euler(0,0,180));
        }
        
    }

    void CheckDirection()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if(moveX > 0.1f)
        {
            facingRight = true;
        }
        if(moveX < -0.1f)
        {
            facingRight = false;
        }
    }

    
}
