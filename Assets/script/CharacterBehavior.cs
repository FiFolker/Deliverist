using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace FiFolker{

	public class CharacterBehavior : MonoBehaviour
	{
		public KeyCode forwardInput,backwardInput,leftwardInput,rightwardInput, sprintInput, interactionInput;
		public float walkSpeed, runSpeed, sensitivity;
		public GameObject playerView;
		private float pitch, yaw = 0.0f;

		CapsuleCollider playerCollider;
		BoxCollider interactionArea;

		void Start() {
			playerCollider = gameObject.GetComponent<CapsuleCollider>();
			interactionArea = gameObject.GetComponent<BoxCollider>();
			Cursor.lockState = CursorLockMode.Locked;
		}

		void Update()
		{

			if(Input.GetKey(forwardInput)){
				if(Input.GetKey(sprintInput)){
					transform.Translate(0,0, runSpeed * Time.deltaTime);
					if(playerView.GetComponent<Camera>().fieldOfView <= 70) StartCoroutine(Lerp(playerView.GetComponent<Camera>().fieldOfView, 75, .8f));
				}else{
					transform.Translate(0,0, walkSpeed * Time.deltaTime);
				}
			}
			if(Input.GetKeyUp(sprintInput)){
				StartCoroutine(Lerp(playerView.GetComponent<Camera>().fieldOfView, 60, .8f));
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

			yaw += Input.GetAxis("Mouse X")* sensitivity;
			transform.eulerAngles = new Vector3(0f, yaw, 0f);
	
			pitch -= Input.GetAxis("Mouse Y")*sensitivity;			
			pitch = Mathf.Clamp(pitch, -10f, 30f);
			playerView.transform.eulerAngles = new Vector3(pitch,transform.eulerAngles.y,0f);
		}

		private void OnTriggerEnter(Collider other) {
			Debug.Log("Trigger enter : "+ other+ " tag : "+ other.tag);
			if(other.GetType().IsSubclassOf(typeof(Interaction))){
				Debug.Log("Press '"+interactionInput.ToString()+"' to interact");
			}
		}

		IEnumerator Lerp(float startValue, float endValue, float lerpDuration){
			float elapsedTime = 0f;
			while(elapsedTime < lerpDuration){
				playerView.GetComponent<Camera>().fieldOfView = Mathf.Lerp(startValue, endValue, elapsedTime/lerpDuration);
				Debug.Log(playerView.GetComponent<Camera>().fieldOfView);
				elapsedTime += Time.deltaTime;
				yield return null;
			}

			playerView.GetComponent<Camera>().fieldOfView = endValue;
			
		}
	}
}
