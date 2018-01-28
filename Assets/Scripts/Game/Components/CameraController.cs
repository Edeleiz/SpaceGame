using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    protected static CameraController _instance;

    public static CameraController instance
    {
        protected set
        {
            _instance = value;
        }
        get
        {
            return _instance;
        }
    }

    public GameObject player;       //Public variable to store a reference to the player game object

    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        instance = this;
        player = SpicerGameManager.instance.player;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player == null)
            return;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}