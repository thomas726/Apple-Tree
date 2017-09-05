﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	// prefab for instanting apples
	public GameObject applePrefab;

	//speed at which the AppleTree move in Meters / second
	public float speed = 1f;
	//distance where apple tree turns around
	public float leftAndRightEdge = 10f;
	//chance that tree will chaneg direction
	public float chanceToChangeDirection = 0.1f;
	//rate at which apples will be insantiated
	public float secondsBetweenAppleDrops = 1f;


	// Use this for initialization
	void Start () {
		//start dropping apples every second
		InvokeRepeating( "DropApple" , 2f, secondsBetweenAppleDrops );
	}

	void DropApple(){
		GameObject apple = Instantiate ( applePrefab ) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//handle basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//change direction
		if (pos.x < -leftAndRightEdge ) {
			speed = Mathf.Abs (speed); //move right
				} 
		else if (pos.x > leftAndRightEdge ) {
			speed = -Mathf.Abs (speed); // move left
			}

	}
	void FixedUpdate(){
	if (Random.value < chanceToChangeDirection ) {
		speed *= -1; //change direction
	}
	}
}
