using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Instructions for this script:
//1. Attach to player object.
//2. Tag the hazardous object as "Hazard"
//3. Create a Text UI and add it to the Dead Text spot under the Death script
//4. Test.
//Audio for the kicks and giggles.
//drag and drop the audio files into their respective slots and uncomment out the code in this script.


public class death : MonoBehaviour {

	
	//For audio
	public AudioClip die;
	public AudioClip bump;
	AudioSource audio;
	

	//For the 'You died' text
	public Text deadText;
	//player dead or nah
	bool isDead;
	//Damage counter. If player hits a hazard, counter goes up. 2 hit kill.
	private int health;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		health = 0;
		deadText.text = "";
	}

	// Update is called once per frame
	void Update () {
		
		if (isDead) {
			//cancel tempPlayer script, animation, & dispaly "You Died" text.
			deadText.text = "You Died.";
			GetComponent<playerController>().enabled = false;
			GetComponent<Animator> ().enabled = false;
		}
	
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "Hazard"
		if (other.gameObject.CompareTag("Hazard"))
		{
			//Plays audio for bumping into a hazard
			audio.PlayOneShot(bump, 0.7F);
			//Calls function
			dead();
		}
	}

	void dead()
	{
		health++;
		if (health == 2) {
			isDead = true;
			//Plays death noise
			audio.PlayOneShot(die, 0.7F);
			//Restarts level
			StartCoroutine (RestartLevel());
		}
	}

	//The code that actually restarts the level after a 3 second pause.
	IEnumerator RestartLevel() {
		yield return new WaitForSeconds(3f);
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}

