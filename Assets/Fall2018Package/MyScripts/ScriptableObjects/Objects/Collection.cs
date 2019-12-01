using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public CollectedItems score;
    public Collectible item;
    private Slider ui = null;
  //public int scoreValue = 1;

  void Start() {
    ui = GameObject.FindWithTag("FBO").GetComponent(typeof(Slider)) as Slider;
    score.reset();
    ui.value = 0;
  }

  void OnTriggerEnter(Collider other) {
    if(other.tag == "Player") {

      //Destroy(other.gameObject);
      //CollectionAndScore.Score += 1;
      // Increase the score by the enemy's score value.
      score.score += item.value;
      ui.value = score.score;
      Destroy(gameObject);
    }
  }

}
