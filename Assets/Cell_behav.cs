using UnityEngine;
using System.Collections;

public class Cell_behav : MonoBehaviour {

    public Joystick Joystickcontrol;
    public float speed = 10.0f;
    public float drag = 1.0f;
    public float maxrotationspeed = 25.0f;
    int children;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        children = transform.childCount;
        Vector3 direction = Vector3.zero;
        direction.x = Joystickcontrol.Horizontal();
        direction.z = Joystickcontrol.Vertical();

        if (direction.magnitude > 1)
            direction.Normalize();

        for (int child = 0; child < children; child++)
        {
            Rigidbody rbody;
            rbody = transform.GetChild(child).GetComponent<Rigidbody>();
            rbody.maxAngularVelocity = maxrotationspeed;
            rbody.drag = drag;
            rbody.AddForce(direction * speed);
        }
	}
}
