using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public KeyCode forwardInput,backwardInput,leftwardInput,rightwardInput, sprintInput, interactionInput;
	public float walkSpeed, runSpeed, sensitivity;

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
            }else{
			    transform.Translate(0,0, walkSpeed * Time.deltaTime);
            }
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

		// transform.eulerAngles = new Vector3(0, Input.GetAxis("Mouse X")* sensitivity, 0);
        transform.Rotate(0, Input.GetAxis("Mouse X")* sensitivity, 0);
	}

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger enter : "+ other+ " tag : "+ other.tag);
    }
}
