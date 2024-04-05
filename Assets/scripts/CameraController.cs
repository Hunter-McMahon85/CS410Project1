// code from:
// https://learn.unity.com/tutorial/moving-the-camera?uv=2022.3&projectId=5f158f1bedbc2a0020e51f0d#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 // Reference to the player GameObject.
 public GameObject player;

 // The distance between the camera and the player.
 private Vector3 offset;

 // Start is called before the first frame update.
 void Start()
    {
 // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position; 
    }

 // LateUpdate is called once per frame after all Update functions have been completed.
 void LateUpdate()
    {
 // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + offset;  
    }
}
