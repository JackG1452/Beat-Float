using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollect : MonoBehaviour {

	[Header ("ITEM VALUE")]
	[Range(1,10)]
	public int gemValue = 1;

	[Space(5f)]
	public GameObject collectParticles;

	void Start () {

	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Debug.Log ("Item Collected");
			CollectItem ();
			CreateParticles ();

			//find the audiomanager and play the sound
            //Either needs added/changed or deleted completely depends on if we have a collect sound
			//GameObject.FindWithTag ("AudioManager").GetComponent<AudioManager> ().PlayCollect ();

			Destroy (gameObject);
		}
	}

	private void CollectItem(){
		//add gems to the score keeper class
        //This would need to be implemented or changed to suit
		//ScoreKeeper.instance.SetGemsCollected(gemValue);

		//disable the collider
		//disable the renderer
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;

	}
	private void CreateParticles(){
		//instantiate a particle system at the objects position & rotation
		GameObject particlePrefab = Instantiate (collectParticles, transform.position, Quaternion.identity);
	}
}
