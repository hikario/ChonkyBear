using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

  // Create Event
  public delegate void PanicInduction();
  public static event PanicInduction StartPanic;

  public delegate void EndingSteps();
  public static event EndingSteps GameEndSteps;

  void CausePanic() {
    if (StartPanic != null) {
      StartPanic();
    }
  }

  void EndGame() {
    if (GameEndSteps != null) {
      GameEndSteps();
    }
  }

}
