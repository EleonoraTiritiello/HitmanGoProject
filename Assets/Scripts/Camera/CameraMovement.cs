using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject arrive;
    public GameObject Cam;
    public float speed;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        Cam.transform.position = Vector3.Lerp(Cam.transform.position, arrive.transform.position, speed * Time.deltaTime);
        //Cam.transform.position = arrive.transform.position;
    }

}
