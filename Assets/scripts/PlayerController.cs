// code taken from:
// https://learn.unity.com/tutorial/moving-the-player?uv=2022.3&projectId=5f158f1bedbc2a0020e51f0d#64ecddceedbc2a2fc3cab919
// comments from given code, want to keep for good reference 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
   private Rigidbody rb;
   private float movementX;
   private float movementY;
   private float movementZ;
   private int count;

   // jump vars
   private int jumpForce = 5;
   private int numJumps = 2;
   private int JumpCount = 0;

   // Speed at which the player moves.
   public float speed = 0;
   public TextMeshProUGUI countText; 
   public GameObject winTextObject;
   public GameObject SupriseObject;

   // Start is called before the first frame update.
   void Start()
   {
      // Get and store the Rigidbody component attached to the player.
      rb = GetComponent<Rigidbody>();
      count = 0;
      SetCountText();
      winTextObject.SetActive(false);
      SupriseObject.SetActive(false);
   }
 
   // This function is called when a move input is detected.
   void OnMove(InputValue movementValue)
   {
      // Convert the input value into a Vector2 for movement.
      Vector2 movementVector = movementValue.Get<Vector2>();

      movementX = movementVector.x; 
      movementY = movementVector.y;
   }

   void OnJump()
   {
      if (JumpCount < numJumps)
      {
         Vector3 movement = new Vector3 (0, jumpForce, 0);
         rb.AddForce(movement, ForceMode.Impulse);
         JumpCount ++;
      }
   }

   void OnCollisionEnter(Collision collision)
   {
      JumpCount = 0;
   }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 10)
       {
           winTextObject.SetActive(true);
           SupriseObject.SetActive(true);
       }
   }

   // FixedUpdate is called once per fixed frame-rate frame.
   private void FixedUpdate() 
   {
      // Create a 3D movement vector using the X and Y inputs.
      Vector3 movement = new Vector3 (movementX, movementZ, movementY);

      // Apply force to the Rigidbody to move the player.
      rb.AddForce(movement * speed);
   }

   void OnTriggerEnter(Collider other) 
   {
      if (other.gameObject.CompareTag("PickUp")) 
       {
           other.gameObject.SetActive(false);
           count += 1;
           SetCountText();
       }
   }
}
