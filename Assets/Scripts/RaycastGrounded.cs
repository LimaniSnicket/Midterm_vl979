﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastGrounded : MonoBehaviour {

	public Toggle walletToggle;
	public Toggle ticketToggle;
	public Toggle bagToggle;
	public Toggle keyToggle;
	public Toggle questToggle;
	public GameObject memeParticle;
	bool wallet = false;
	bool ticket = false;
	bool bag = false;
	bool key = false;
	bool quest = false;

	public score playerTracker;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (wallet) {
			walletToggle.isOn = true;
		} else {
			walletToggle.isOn = false;
		}
		if (bag) {
			bagToggle.isOn = true;
		} else {
			bagToggle.isOn = false;
		}
		if (key) {
			keyToggle.isOn = true;
		} else {
			keyToggle.isOn = false;
		}
		if (quest) {
			questToggle.isOn = true;
		} else {
			questToggle.isOn = false;
		}
		if (ticket) {
			ticketToggle.isOn = true;
		} else {
			ticketToggle.isOn = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//step one, declare ray object
		Ray myRay = new Ray(transform.position, transform.right *-1f);

		RaycastHit rayHit = new RaycastHit ();

		//max distance for raycast
		float maxDistance = 4f;

		//optional but recommended, visualize raycast in scene debug
		Debug.DrawRay(myRay.origin, myRay.direction*maxDistance, Color.red);

		//step 4 actually shoot raycast
		if (Physics.Raycast (myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Wallet") && (Input.GetMouseButton (0))) {
			Debug.Log ("wallet");
			Destroy (rayHit.collider.gameObject);
			wallet = true;
		} else if(Physics.Raycast(myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Bag") && (Input.GetMouseButton(0))){
			Debug.Log ("Bag");
			bag = true;
			Destroy (rayHit.collider.gameObject);
		} else if(Physics.Raycast(myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Key")&& (Input.GetMouseButton(0))){
			key = true;
			Destroy (rayHit.collider.gameObject);
		} else if(Physics.Raycast(myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Food") && (Input.GetMouseButton(0))){
			quest = true;
			Destroy (rayHit.collider.gameObject);
		} else if(Physics.Raycast(myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Tickets") && (Input.GetMouseButton(0))){
			ticket = true;
			Destroy (rayHit.collider.gameObject);
		}

		 if (Physics.Raycast (myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Meme") && (Input.GetMouseButton (0))) {
			Debug.Log ("sick meme bro");
			Destroy (rayHit.collider.gameObject);
			playerTracker.brotherPatience = playerTracker.brotherPatience + 5f;
			//Instantiate (memeParticle);
		} else if(Physics.Raycast (myRay, out rayHit, maxDistance) && (rayHit.collider.gameObject.tag == "Dog") && (Input.GetMouseButton (0))){
			Destroy (rayHit.collider.gameObject);
			playerTracker.brotherPatience = playerTracker.brotherPatience + 5f;
		} else {
			playerTracker.brotherPatience = playerTracker.brotherPatience - Time.deltaTime *0.5f;
		}

	}
}
