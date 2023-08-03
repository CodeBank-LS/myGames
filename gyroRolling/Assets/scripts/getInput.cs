// A code block
using UnityEngine;
using System.Collections;

public class CamGyro : MonoBehaviour
{
    private const float lowPassFilterFactor = 0.8f;

    private Quaternion startQuaternion;

    private Quaternion originalQuaternion;

    private int frameCnt = 0;

    void Start()
    {
        //set gyro open or close, must set to true to use
        Input.gyro.enabled = true;
        //get gravity speed  
        Vector3 deviceGravity = Input.gyro.gravity;
        //get rotate rate to x, y, z, unit is degree/s）  
        Vector3 rotationVelocity = Input.gyro.rotationRate;
        //refined rotate rate
        Vector3 rotationVelocity2 = Input.gyro.rotationRateUnbiased;
        //update every 0.1s 
        Input.gyro.updateInterval = 0.1f;
        //speed without gravity
        Vector3 acceleration = Input.gyro.userAcceleration;
    }

    void Update()
    {
        frameCnt++;

        if (frameCnt > 5 && frameCnt <= 30)
        {
            originalQuaternion = transform.rotation;

            startQuaternion = new Quaternion(-1 * Input.gyro.attitude.x,
            -1 * Input.gyro.attitude.y,
            Input.gyro.attitude.z,
            Input.gyro.attitude.w);
            return;
        }

        Quaternion currentQuaternion = new Quaternion(-1 * Input.gyro.attitude.x, -1 * Input.gyro.attitude.y,
            Input.gyro.attitude.z, Input.gyro.attitude.w);

        //Quaternion deltaQuaternion = Quaternion.RotateTowards(startQuaternion, currentQuaternion, 180);

        //Input.gyro.attitude return value Quaterniontype  
        //transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(-1*Input.gyro.attitude.x, -1*Input.gyro.attitude.y, Input.gyro.attitude.z, Input.gyro.attitude.w), lowPassFilterFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, originalQuaternion * Quaternion.Inverse(startQuaternion) * currentQuaternion, lowPassFilterFactor);
    }
}
