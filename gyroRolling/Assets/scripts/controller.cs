using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool gameStart = false;
    //limit for the platform to rotate, maximum 90 degree
    public float maxRotateAngle = 90f;
    private float currentRotation = 0f;

    // Speed at which the platform rotates
    public float liftForce_ad = 5f;
    public float liftForce_ws = 5f;
    public float rotateForce = 0.0000001f;

    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    // Define key codes for controlling platform rotation
    public KeyCode liftRightKey_D = KeyCode.D;
    public KeyCode liftLeftKey_A = KeyCode.A;
    public KeyCode liftUpKey_W = KeyCode.W;
    public KeyCode liftBottomKey_S = KeyCode.S;

    private Quaternion initialRotation;//platform's initial level status
    private Move ballMoveScript;


    void Start()
    {
        initialRotation = transform.rotation;
        ballMoveScript = FindObjectOfType<Move>();

    }

    void Update()
    {
        if (gameStart)
        {
            return;
        }
        // Detect the keys and update platform rotation accordingly
        
        if (Input.GetKey(liftRightKey_D))
        {
            // Rotate the platform to the right (around its center pivot) when "d" is pressed
            // We use Vector3.back to rotate around the platform's Z-axis
            currentRotation += liftForce_ad * Time.deltaTime;
            z = currentRotation;
            transform.rotation = Quaternion.Euler(x, y, z);
        }
        else if (Input.GetKey(liftLeftKey_A))
        {
            // Rotate the platform to the left (around its center pivot) when "a" is pressed
            // We use Vector3.forward to rotate around the platform's Z-axis in the opposite direction
            currentRotation -= liftForce_ad * Time.deltaTime;
            z = currentRotation;
            //currentRotation = Mathf.Clamp(currentRotation, -maxRotateAngle, maxRotateAngle);
            transform.rotation = Quaternion.Euler(x,y,z);
          

        }
        else if (Input.GetKey(liftUpKey_W))
        {
            // Rotate the platform upward (around its center pivot) when "w" is pressed
            // We use Vector3.left to rotate around the platform's X-axis
            currentRotation -= liftForce_ws * Time.deltaTime;
            x = currentRotation;
            //currentRotation = Mathf.Clamp(currentRotation, -maxRotateAngle, maxRotateAngle);
            transform.rotation = Quaternion.Euler(x,y,z);
           

        }
        else if (Input.GetKey(liftBottomKey_S))
        {
            // Rotate the platform downward (around its center pivot) when "s" is pressed
            // We use Vector3.right to rotate around the platform's X-axis in the opposite direction
      
            currentRotation += liftForce_ws * Time.deltaTime;
            x = currentRotation;
            //currentRotation = Mathf.Clamp(currentRotation, -maxRotateAngle, maxRotateAngle);
            transform.rotation = Quaternion.Euler(x,y,z);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the platform anti-clockwise(around its center pivot) when "->" is pressed
            // We use Vector3.back to rotate around the platform's Y-axis
            currentRotation -= rotateForce;
            y = currentRotation;
            transform.rotation = Quaternion.Euler(x, y, z);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate the platform clockwise (around its center pivot) when "<-" is pressed
            // We use Vector3.back to rotate around the platform's Y-axis
            currentRotation += rotateForce;
            y = currentRotation;
            transform.rotation = Quaternion.Euler(x, y, z);

        }
        else if (Input.GetKey(KeyCode.Escape)||ballMoveScript.isFailed==true)
        {
            // Reset the platform's rotation to its initial state (level position) when "ESC" is pressed
            transform.rotation = initialRotation;
            ballMoveScript.ResetPosition();
        }

    }
    private void StartGame()
    {
        // 隐藏提示文本
        startText.enabled = false;
        // 设置游戏已开始的标志
        gameStart = true;
        // 在此添加开始游戏的逻辑，例如启用球体的运动等
    }
}
