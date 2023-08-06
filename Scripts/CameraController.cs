using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool chasingPlayer;
    public float chasingVelocity;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if(chasingPlayer)
        {
            Vector3 a = transform.position;
            Vector3 b = playerTransform.position;
            b.z = -10;
            if(Vector3.Distance(a, b) > 0.01)
                transform.position = Vector3.Lerp(a, b, Time.deltaTime * chasingVelocity);
        }
    }
}
