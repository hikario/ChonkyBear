using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminescenceCollider : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      Light lumi = gameObject.transform.parent.gameObject.GetComponentInChildren(typeof(Light)) as Light;

      if (lumi != null) {
        // Debug.Log("Something went right");
        lumi.intensity = 4.0f;
      } else {
        Debug.Log("something went wrong");
      }
    }
  }

  void OnTriggerExit(Collider other) {
    if (other.tag == "Player") {
      Light lumi = gameObject.transform.parent.gameObject.GetComponentInChildren(typeof(Light)) as Light;

      if (lumi != null) {
        // Debug.Log("Something went right");
        lumi.intensity = 0.0f;
      } else {
        Debug.Log("something went wrong");
      }
    }
  }
}
