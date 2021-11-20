using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore;

public class FPSCamLayout : BasicFollowCamLayout
{
    [Range(80,-90)]
    [SerializeField] float minX, maxX;
    float mouseSensetivity;

    Vector3 lastInputPosition;

    public void FPSCamInit(float mouseSensetivity)
    {
        this.mouseSensetivity = mouseSensetivity;
    }

    public void ControlCamera()
    {
        /*
         * Screen - Player
         *  x       y
         *  y       x
         */

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * mouseSensetivity);

        transform.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * mouseSensetivity);

        Vector3 rot = transform.eulerAngles;
        rot.z = 0;
        /*
         *  TODO : Clamp X rotatiton
        if (rot.x > 0)
        {
            rot.x = Mathf.Clamp(rot.x, 0, minX);
        }
        else
        {
            rot.x = Mathf.Clamp(rot.x, 0, minX);
        }
        */
        transform.eulerAngles = rot;

        lastInputPosition = Input.mousePosition;
    }

}
