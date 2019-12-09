using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXEffects : MonoBehaviour {

public AudioSource Munch;
public AudioSource Bees;
public AudioSource Hat;
public AudioSource Rustle;

public void PlayMunch() {
	Munch.Play ();
}

public void PlayBees() {
	Bees.Play ();
}

public void PlayHat() {
	Hat.Play ();
}

public void PlayRustle() {
	Rustle.Play ();
}

}
