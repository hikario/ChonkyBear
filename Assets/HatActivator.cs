﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatActivator : MonoBehaviour
{
    public bool hatIsActive = false;
    public bool strawberryIsActive = false;
    public GameObject hatStatus;
    private GameObject wornHat;
    private GameObject wornStrawberry;
    private GameObject wornLowStrawberry;
    // Start is called before the first frame update
    void Start()
    {
      wornHat = GameObject.FindGameObjectWithTag("WornHat");
      wornStrawberry = GameObject.FindGameObjectWithTag("WornStraw");
      wornLowStrawberry = GameObject.FindGameObjectWithTag("WornLowStraw");
      SetHatState();
    }

    void SetHatState() {
      hatStatus = GameObject.FindGameObjectWithTag("HatState");
      hatIsActive = hatStatus.GetComponent<GameHatState>().hatActive;
      strawberryIsActive = hatStatus.GetComponent<GameHatState>().strawberryActive;

      if (hatIsActive) {
        wornHat.SetActive(true);
      } else {
        wornHat.SetActive(false);
      }

      if (strawberryIsActive) {
        if (hatIsActive) {
          wornStrawberry.SetActive(true);
          wornLowStrawberry.SetActive(false);
        } else {
          wornLowStrawberry.SetActive(true);
          wornStrawberry.SetActive(false);
        }
      } else {
        wornStrawberry.SetActive(false);
        wornLowStrawberry.SetActive(false);
      }

    }

    void OnEnable() {
      EventManager.UpdateHatStateListeners += SetHatState;
    }

    void OnDisable() {
      EventManager.UpdateHatStateListeners -= SetHatState;
    }

}
