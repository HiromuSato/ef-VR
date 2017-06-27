using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {
	
	public void SelectScene1(){
		GameObject.Destroy (GameObject.Find ("Main Camera"));
		GameObject.Destroy (GameObject.Find ("Canvas"));
		SceneManager.LoadScene("Scene1", LoadSceneMode.Additive);
	}

}