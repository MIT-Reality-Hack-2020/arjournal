using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

public class location : MonoBehaviour
{

    Tuple<float, float>[] pairs = {
        Tuple.Create(42.36039F, -71.08741F),
        Tuple.Create(41.36041F, -71.08734F),
    };
    GameObject[] objects = new GameObject[2];
    private float currentLongitude;
    private float currentLatitude;

    private double distance;

    private bool setOriginalValues = true;

    private Vector3 targetPosition;
    private Vector3 originalPosition;

    private float speed = .1f;


    GameObject dialog = null;
    bool location_retrieved = false;

    IEnumerator getLocation()
    {
        // First, check if user has location service enabled
        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Debug.Log("location is permitted");
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log("location is disabled");
                yield break;
            }
            else
            {
                Debug.Log("location is enabled");
            }
        }
        else
        {
            Debug.Log("asking for location permission");
            Permission.RequestUserPermission(Permission.FineLocation);
            dialog = new GameObject();
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            currentLatitude = Input.location.lastData.latitude;
            currentLongitude = Input.location.lastData.longitude;
            print("Location: " + Input.location.lastData.latitude.ToString("R") + " " + Input.location.lastData.longitude.ToString("R") + " " + Input.location.lastData.altitude.ToString("R") + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
    }

    private void Start()
    {
        StartCoroutine(getLocation());
    }

    private void Update()
    {
        double min = 999.0;
        int j = 0;
        for (int i = 0; i < pairs.Length; i++)
        {
            print("Location: " + currentLatitude + " " + currentLongitude + " " + pairs[i].Item1 + " " + pairs[i].Item2);
            //fetchForCurrentLocation(currentLatitude, currentLongitude);
            double dist = Calc(currentLatitude, currentLongitude, pairs[i].Item1, pairs[i].Item2);
            if (dist < min)
            {
                min = dist;
                j = i;
            }
        }
                print("In zone of tuple: " + pairs[j]);
                objects[j].SetActive(true);
                for (int i=0; i<objects.Length; i++)
                {
                    if (j != i)
                    {
                        objects[i].SetActive(false);
                    }
                }
    
    }


    
    //calculates distance between two sets of coordinates, taking into account the curvature of the earth.
    public double Calc(float lat1, float lon1, float lat2, float lon2)
    {

        var R = 6378.137; // Radius of earth in KM
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
          Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
          Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        distance = distance * 1000f;
        print("Distance: " + distance);

        return distance;
        // meters
                                     //set the distance text on the canvas
        //distanceTextObject.GetComponent<Text>().text = "Distance: " + distance;
        //convert distance from double to float
        //float distanceFloat = (float)distance;
        //set the target position of the ufo, this is where we lerp to in the update function
        //targetPosition = originalPosition - new Vector3(0, 0, distanceFloat * 12);
        //distance was multiplied by 12 so I didn't have to walk that far to get the UFO to show up closer

    }
}
