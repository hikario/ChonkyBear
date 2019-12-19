using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHatState : MonoBehaviour
{
    public bool hatActive = false;
    public bool strawberryActive = false;
    public bool glassesActive = false;

    void Start() {
      DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
}
