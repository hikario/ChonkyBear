using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

  // Create Event
  public delegate void PanicInduction();
  public static event PanicInduction StartPanic;

  void CausePanic() {
    if (StartPanic != null) {
      StartPanic();
    }
  }

}
