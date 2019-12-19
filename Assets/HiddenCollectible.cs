using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCollectible : MonoBehaviour
{

  public GameObject hatStatus;
  private Camera mc;

  void Start() {
    hatStatus = GameObject.FindGameObjectWithTag("HatState");
    mc = Camera.main;
  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      if (gameObject.tag == "CollHat") {
        hatStatus.GetComponent<GameHatState>().hatActive = true;
      } else if (gameObject.tag == "CollStraw") {
        hatStatus.GetComponent<GameHatState>().strawberryActive = true;
      } else if (gameObject.tag == "CollGlasses") {
        hatStatus.GetComponent<GameHatState>().glassesActive = true;
      }

      mc.SendMessage("UpdateHats");

      Destroy(gameObject);
    }
  }

}
