﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Vector2 direction;
	[SerializeField] float speed;
	float radius;
	// Use this for initialization
	void Start () {
		direction = Vector2.one.normalized;
		radius = transform.localScale.x /2;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(direction*speed*Time.deltaTime);

		if((transform.position.y < GameManager.bottomLeft.y + radius) && (direction.y < 0)){
			direction.y = -direction.y;
		}
		if((transform.position.y > GameManager.topRight.y - radius) && (direction.y > 0)){
			direction.y = -direction.y;
		}
		if((transform.position.x < GameManager.bottomLeft.x + radius) && (direction.x < 0)){
			GameManager.end();
		}
		if((transform.position.x > GameManager.topRight.x - radius) && (direction.x > 0)){
			GameManager.end();
		}
	}

    void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Paddle"){
			//bool isRight = other.GetComponent<Paddle>().isRight;
			GameManager.score++;
             direction.x = -direction.x;
		    // if((isRight == true) && (direction.x < 0) ){
			//  	direction.x = -direction.x;
			//  }
			// else if((isRight == false) && (direction.x > 0) ){
			//  	direction.x = -direction.x;
			//  }
			//Debug.Log(GameManager.score);
		}
	}
}
