using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public string forward,backward,leftward,rightward;
	public float walkSpeed, runSpeed;

	CapsuleCollider playerCollider;

	void Start() {
		playerCollider = gameObject.GetComponent<CapsuleCollider>();
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Z)){
			transform.Translate(0,0, walkSpeed * Time.deltaTime);
			Debug.Log("Avance");
		}

		
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0,0, - (walkSpeed / 2) * Time.deltaTime);
			Debug.Log("Arrière");
		}

		
		if(Input.GetKey(KeyCode.Q)){
			transform.Translate(0,0, walkSpeed * Time.deltaTime);
			Debug.Log("Gauche");
		}

		
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(0,0, walkSpeed * Time.deltaTime);
			Debug.Log("Droite");
		}

		if(Input.GetAxis("Mouse X") < 0){
			Debug.Log("Mouse left");
		}

		if(Input.GetAxis("Mouse X") > 0){
			print("Mouse right");
		}
	}
}
