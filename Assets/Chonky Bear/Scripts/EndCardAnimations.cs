using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCardAnimations : MonoBehaviour {

  public List<Sprite> frames;
  public float framerate;
  private float elapsedTimeSinceLastUpdate;
  private float frameTimeDelta;
  private int frameIndex;
  private int frameIndexMax;

  // Use this for initialization
  void Start () {
    elapsedTimeSinceLastUpdate = 0.0f;
    frameTimeDelta = 1.0f/framerate;
    frameIndex = 0;
    frameIndexMax = frames.Count;
  }

  // Update is called once per frame
  void Update () {
    elapsedTimeSinceLastUpdate += Time.deltaTime;

    if (elapsedTimeSinceLastUpdate >= frameTimeDelta) {
      Debug.Log(elapsedTimeSinceLastUpdate);
      Debug.Log(frameTimeDelta);
      UpdateImage();
    }
  }

  // Our own update
  void UpdateImage() {
    elapsedTimeSinceLastUpdate = 0.0f;
    frameIndex = (frameIndex + 1) % frameIndexMax;
    gameObject.GetComponent<Image>().sprite = frames[frameIndex];
  }
}
