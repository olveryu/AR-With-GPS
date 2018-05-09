using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Coordinate : MonoBehaviour {
    public InputField inputLat;
    public InputField inputLon;
    public Argumented target;

    public void setLatitude() {
        try {
            target.Latitude = double.Parse(inputLat.text);
        }catch (Exception e) {
            Debug.Log("setLatitude" + e.Message);
        }
    }

    public void setLongitude() {
        try {
            target.Longitude = double.Parse(inputLon.text);
        }catch (Exception e) {
            Debug.Log("setLongitude" + e.Message);
        }
    }
}
