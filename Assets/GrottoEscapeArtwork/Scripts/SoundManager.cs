using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip jump, fire, coin, teleport, portal;
	static AudioSource audioSrc;
	static float jumpSoundDelay=0, coinSoundDelay=0, teleportSoundDelay=0, portalSoundDelay=0;

	// Use this for initialization
	void Start () {
		jump = Resources.Load<AudioClip> ("jump");
		fire = Resources.Load<AudioClip> ("fire");
		coin = Resources.Load<AudioClip> ("coin");
		teleport = Resources.Load<AudioClip> ("teleport");
		portal = Resources.Load<AudioClip> ("portal");

		audioSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip) {
		
		switch (clip) {
		case "jump":
			if (Time.time >= jumpSoundDelay) {
				audioSrc.PlayOneShot (jump);
				jumpSoundDelay = Time.time + jump.length;
			}
			break;
		case "fire":
			audioSrc.PlayOneShot (fire);
			break;
		case "coin":
			if (Time.time >= coinSoundDelay) {
				audioSrc.PlayOneShot (coin);
				coinSoundDelay = Time.time + coin.length;
			}
			break;
		case "teleport":
			if (Time.time >= teleportSoundDelay) {
				audioSrc.PlayOneShot (teleport);
				teleportSoundDelay = Time.time + teleport.length;
			}
			break;
		case "portal":
			if (Time.time >= portalSoundDelay) {
				audioSrc.PlayOneShot (portal);
				portalSoundDelay = Time.time + portal.length;
			}
			break;
		}
		
	}
}
