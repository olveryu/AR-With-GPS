using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Argumented : MonoBehaviour {
    public double Latitude;
    public double Longitude;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void argumentedModel() {
        if (GPS.Instance.latitudeDifference(Latitude) && GPS.Instance.longitudeDifference(Longitude)) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }


}
