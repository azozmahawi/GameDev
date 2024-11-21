using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0,4,-12.5f);
    public Transform Target;
    public float Followspeed = 10f;
    public float Rotationspeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            Vector3 desiredPosition = Target.position + Target.rotation * Offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Followspeed * Time.deltaTime);

            Quaternion desiredRotation = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Rotationspeed * Time.deltaTime);

           // transform.LookAt(Target.position + Vector3.up);
        }
    }
}
