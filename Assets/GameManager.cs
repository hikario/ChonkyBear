using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

  public CollectedItems score;
  public Image fadeOutImage;

  private bool win = false;
  private float fadeSpeed = 2.0f;
  private Scene scene;

  private enum FadeDirection {
    In,
    Out
  }
  // Use this for initialization

  void Start() {
    scene = SceneManager.GetActiveScene();
  }

  void OnEnable() {
    EventManager.GameEndSteps += HandleEndScreen;
  }

  void OnDisable() {
    EventManager.GameEndSteps -= HandleEndScreen;
  }

  // Handle steps to load ending screen
  void HandleEndScreen() {
    // Handle win or lose
    if (score.score >= score.endScore) {
      win = true;
    }
    // Load appropriate screen
    if (win) {
      if (scene.name == "Scene2") {
        StartCoroutine(FadeAndLoadScene("game over win"));
      }
      else if (scene.name == "Scene1") {
        StartCoroutine(FadeAndLoadScene("Scene2"));
      }
    } else {
      StartCoroutine(FadeAndLoadScene("game over lose"));
    }
  }

  public IEnumerator FadeAndLoadScene(string sceneToLoad) {
    yield return Fade(FadeDirection.Out);
    SceneManager.LoadScene(sceneToLoad);
    yield return Fade(FadeDirection.In);
  }

  private IEnumerator Fade(FadeDirection fd) {
    if(fd == FadeDirection.Out) {
      float current = fadeOutImage.color.a;
      while(current < 1.0f) {
        current = fadeToBlack();
        yield return null;
      }
    } else {
      float current = fadeOutImage.color.a;
      while(current > 0.0f) {
        current = fadeFromBlack();
        yield return null;
      }
    }
  }

  float fadeToBlack() {
    float alphaNew = fadeOutImage.color.a + Time.deltaTime * (1.0f/fadeSpeed);
    fadeOutImage.color = new Color(0, 0, 0, alphaNew);
    return alphaNew;
  }

  float fadeFromBlack() {
    float alphaNew = fadeOutImage.color.a - Time.deltaTime * (1.0f/fadeSpeed);
    fadeOutImage.color = new Color(0, 0, 0, alphaNew);
    return alphaNew;
  }

}
