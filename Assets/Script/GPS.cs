using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GPS : MonoBehaviour {


    public static GPS Instance;
    public Argumented[] targets;

    public Text coordinates;

    public double acceptableDifference;
    private double latitude;
    private double longitude;
    private double latitudeDistance;
    private double longitudeDistance;

    private void Start() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private void Update() {
        latitude = Math.Round(Input.location.lastData.latitude, 4);
        longitude = Math.Round(Input.location.lastData.longitude, 4);
        coordinates.text = "Current (Lat,Lon): " + latitude.ToString() + " , " + longitude.ToString();
        for (int i = 0; i < targets.Length; i++) {
            targets[i].argumentedModel();
        }
    }

    private IEnumerator StartLocationService() {
        // check GPS enable
        if (!Input.location.isEnabledByUser) {
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1) {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            yield break;
        }

        // set coordinate
        latitude = Math.Round(Input.location.lastData.latitude, 4);
        longitude = Math.Round(Input.location.lastData.longitude, 4);

        yield break;
    }

    public bool latitudeDifference(double targetLatitude) {
        latitudeDistance = Math.Round(Math.Abs(latitude - targetLatitude),4);
        return latitudeDistance <= acceptableDifference;
    }

    public bool longitudeDifference(double targetLongitude) {
        longitudeDistance = Math.Round(Math.Abs(longitude - targetLongitude), 4);
        return longitudeDistance <= acceptableDifference;
    }
}