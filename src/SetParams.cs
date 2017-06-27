using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.VR;
using VRTK;
using VRTK.GrabAttachMechanics;

public class SetParams : MonoBehaviour {
	public GameObject[] mols;

	void Awake() {
		mols = GameObject.FindGameObjectsWithTag ("Mol");

		foreach (GameObject mol in mols) {
			myParam (mol);
		}

		Invoke ("resetPosition", 1f);
	}
		
	void Update() {
		if (Input.GetKeyDown(KeyCode.R)){
				resetPosition ();
		}
	}

	void myParam(GameObject mol){
		mol.AddComponent<Rigidbody>();
		mol.GetComponent<Rigidbody>().useGravity = false;
		mol.GetComponent<Rigidbody>().isKinematic = true;

		mol.AddComponent<MeshCollider>();
		mol.GetComponent<MeshCollider>().sharedMesh = mol.GetComponent<MeshFilter>().sharedMesh;

		mol.AddComponent<VRTK_InteractableObject>();
		mol.GetComponent<VRTK_InteractableObject> ().isGrabbable = true;
		mol.AddComponent<VRTK_ChildOfControllerGrabAttach> ();
		mol.GetComponent<VRTK_ChildOfControllerGrabAttach> ().precisionGrab = true;
	}

	void resetPosition(){
		foreach (GameObject mol in mols) {
			mol.transform.position = InputTracking.GetLocalPosition (VRNode.CenterEye);
		}
	}

}
