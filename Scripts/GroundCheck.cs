using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    private bool onRock;
    private bool onGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int lr = collision.gameObject.layer;
        switch (lr)
        {
            case 6: //Rock
                OnRock = true;
                break;

            case 8: //Ground
                OnGround = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int lr = collision.gameObject.layer;
        switch (lr)
        {
            case 6: //Rock
                OnRock = false;
                break;

            case 8: //Ground
                OnGround = false;
                break;
        }
    }

    public bool OnGround
    {
        get { return this.onGround; }
        private set { this.onGround = value; }
    }

    public bool OnRock
    {
        get { return this.onRock; }
        private set { this.onRock = value; }
    }
}
