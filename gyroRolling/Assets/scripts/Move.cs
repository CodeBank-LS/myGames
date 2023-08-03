using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform platform; // Reference to the platform's Transform component

    private Rigidbody ballRigidbody;

    private Vector3 initialPosition;//initial position of the ball 
    private Vector3 initialOffset; // Offset between ball and platform when the game starts

    private bool isArrive = false;//if the ball reach exit
    public bool isFailed = false;//if the ball drop off the edge or trap

    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        initialOffset = transform.position - platform.position;
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {

        // Update the ball's position relative to the platform's new rotation and position
        Vector3 newPos = platform.TransformPoint(initialOffset);
        ballRigidbody.MovePosition(newPos);
        if (ballRigidbody.transform.position.y < -20)
        {
            isFailed = true;
        }
    }
    
    public void ResetPosition()
    {
        transform.position = initialPosition;
        //the ball and platform are reset to initial state, ball should be still 
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        //isMoving = true;
    }

    
    
        


}
