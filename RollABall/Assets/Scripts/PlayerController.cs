using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private int pickUpsCount;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Door door;
    [SerializeField] private UserInterface uIText;
    

    private void Start()
    {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
        this.pickUpsCount = 0;        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        PlayerMovement(moveHorizontal, moveVertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("PickUps"))
            {
                other.gameObject.SetActive(false);

                this.pickUpsCount++;

                this.uIText.UpdateItemsAmount(this.pickUpsCount);

                this.CheckForWinCondition();
            }

            if (other.gameObject.CompareTag("RedPickUps"))
            {
                this.uIText.ShowLoseText();

                this.StopMoving();
               
                this.uIText.ShowGameOptions();
            }

            if (other.gameObject.CompareTag("GreenPickUps"))
            {
                other.gameObject.SetActive(false);

                this.door.Open();
            }
        }
    }

    private void CheckForWinCondition()
    {
        if (this.pickUpsCount >= 12)
        {
            this.uIText.ShowWinText();

            this.StopMoving();

            this.uIText.ShowGameOptions();
        }
    }

    public void PlayerMovement(float moveHorizontal, float moveVertical)
    {
        if (this.rigidbody != null)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            this.rigidbody.AddForce(movement * this.movementSpeed);
        }
    }

    public void StopMoving()
    {
        this.rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        this.rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        this.movementSpeed = 0.0f; // If i dont set movement to 0, it's still moving really slow.
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

}
