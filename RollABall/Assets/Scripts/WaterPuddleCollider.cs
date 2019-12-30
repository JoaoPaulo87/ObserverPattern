using UnityEngine;

public class WaterPuddleCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Rigidbody playerRigidBody =  other.GetComponent<Rigidbody>();
            playerRigidBody.drag = -2;
        }
        else
        {
            Debug.LogError("Null player controller");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            Rigidbody playerRigidBody = other.GetComponent<Rigidbody>();
            playerRigidBody.drag = 2;
        }
    }
}
