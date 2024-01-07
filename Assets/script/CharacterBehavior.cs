using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FiFolker{

	public class CharacterBehavior : MonoBehaviour
	{
		public GameObject playerView;
		public KeyCode forwardInput,backwardInput,leftwardInput,rightwardInput, sprintInput, interactionInput;
		[Header("Characteristics")]
		public float walkSpeed;
		public float runSpeed;
		public float sensitivity;
		public Inventory inventory;

		// PRIVATE FIELDS 
		private Rigidbody rb;
		private float elapsedTime, pitch, yaw = 0.0f;
		private readonly float lerpDuration = 1.2f;
		private Interaction interativectObject;
		public GameObject playerModel;
		private BoxCollider interactionArea;

		void Start() {
			interactionArea = gameObject.GetComponent<BoxCollider>();
			rb = gameObject.GetComponent<Rigidbody>();
			rb.freezeRotation = true;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			interativectObject = null;
		}

		void Update()
		{
			// reset elapsed time when sprint key is pressed
			if(Input.GetKeyDown(sprintInput)){
				elapsedTime = 0f;
			}
			// Reset elapsed time when sprint key is released
			if(Input.GetKeyUp(sprintInput)){
				elapsedTime = 0f;
			}

			if(interativectObject != null){
				interativectObject.draw();
				if(Input.GetKeyDown(interactionInput)){
					interativectObject.interact(this);
				}
			}
		}

		void FixedUpdate() {
			Movement();
			CameraMovement();	
		}

		private void OnTriggerEnter(Collider other) {
			if(other.gameObject.GetComponent<Interaction>() != null){
				interativectObject = other.gameObject.GetComponent<Interaction>();
			}
		}

		private void OnTriggerExit(Collider other) {
			if(other.gameObject.GetComponent<Interaction>() != null){
				interativectObject = null;
				Debug.Log("Out of range");
			}
		}

		private void LerpCamera(float endValue, float lerpDuration){
			if(elapsedTime < lerpDuration){
				playerView.GetComponent<Camera>().fieldOfView = Mathf.Lerp(playerView.GetComponent<Camera>().fieldOfView, endValue, elapsedTime/lerpDuration);
				elapsedTime += Time.deltaTime;
			}else{
				playerView.GetComponent<Camera>().fieldOfView = endValue;

			}
		}

		private void Movement(){
			if(Input.GetKey(forwardInput)){
				
				if(Input.GetKey(sprintInput)){
					transform.Translate(0,0, runSpeed * Time.deltaTime);
					LerpCamera(75, lerpDuration);
				}else{
					transform.Translate(0,0, walkSpeed * Time.deltaTime);
				}
			}

			

			if(!Input.GetKey(sprintInput)){
				LerpCamera(60, lerpDuration);
			}
			
			if(Input.GetKey(backwardInput)){
				transform.Translate(0,0, - (walkSpeed / 2) * Time.deltaTime);
			}

			
			if(Input.GetKey(leftwardInput)){
				transform.Translate(- (walkSpeed /2 ) * Time.deltaTime,0, 0);
			}
			
			if(Input.GetKey(rightwardInput)){
				transform.Translate(walkSpeed /2 * Time.deltaTime, 0, 0);
			}
		}

		private void CameraMovement(){
			yaw += Input.GetAxis("Mouse X")* sensitivity;
			transform.eulerAngles = new Vector3(0f, yaw, 0f);
		
			pitch -= Input.GetAxis("Mouse Y")*sensitivity;			
			pitch = Mathf.Clamp(pitch, -10f, 30f);
			playerView.transform.eulerAngles = new Vector3(pitch,transform.eulerAngles.y,0f);
		}
	}

	
}
