using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeasonCountdown : MonoBehaviour {
  private float RemainingSeasonInSeconds;
  public float SeasonLengthDefault;
  private bool gameOver = false;
  private RectTransform ibst;

  // Use this for initialization
  void Start () {
    ibst = GameObject.FindWithTag("IBST").GetComponent(typeof(RectTransform)) as RectTransform;
    RemainingSeasonInSeconds = SeasonLengthDefault;
  }

  // calculate angle for rect transform
  float getRotation(float timePassed) {
    // Get percentage of rotation
    float RotPer = timePassed / SeasonLengthDefault;

    // Only doing a half rotation, so apply to 180
    float rotAngle = 180.0f * RotPer;

    // Spin CC
    return (-1.0f * rotAngle);
  }

  // Update is called once per frame
  void Update () {
    if (!isGameOver()) {
      RemainingSeasonInSeconds -= Time.deltaTime;

      if (RemainingSeasonInSeconds < 0) {
        gameOver = true;
        ibst.rotation = Quaternion.identity;
      } else {
        ibst.Rotate(new Vector3(0, 0, getRotation(Time.deltaTime)));
      }
    }
  }

  bool isGameOver() {
    return gameOver;
  }
}
