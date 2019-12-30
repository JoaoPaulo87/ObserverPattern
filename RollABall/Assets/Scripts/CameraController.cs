using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
