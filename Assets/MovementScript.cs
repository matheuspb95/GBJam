using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	Rigidbody2D body;
	public float VelocityMultiplier;

	float SwipeTime = 0.1f, StartSwipe;
	Vector3 StartMouse;
	bool swiping,moving;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		swiping = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && body.velocity == Vector2.zero){
			swiping = true;
			StartSwipe = Time.time;
			StartMouse = Input.mousePosition;
		}

		if(Time.time > StartSwipe + SwipeTime && swiping){
			Vector2 swipe = StartMouse - Input.mousePosition;
			if(swipe.y > swipe.x){
				if(swipe.y > -swipe.x){
					body.velocity = Vector2.down * VelocityMultiplier;
					transform.eulerAngles = Vector3.zero;
				} else {
					body.velocity = Vector2.right * VelocityMultiplier;
					transform.eulerAngles = new Vector3(0,0,90);
				}
			} else {
				if(swipe.y > -swipe.x){
					body.velocity = Vector2.left * VelocityMultiplier;
					transform.eulerAngles = new Vector3(0,0,-90);
				} else {
					body.velocity = Vector2.up * VelocityMultiplier;
					transform.eulerAngles = new Vector3(0,0,180);
				}
			}
			swiping = false;
		}
	}
}
