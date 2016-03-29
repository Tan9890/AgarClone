using UnityEngine;
using System.Collections;
using System;

public class camera_behav : MonoBehaviour {

    public GameObject player;
    int playerchildren;
    public float height = 4f;
    public float distance = 5f;
    public float turnSpeed = 10f;
    private Vector3 offsetX;
    private Vector3 offsetY;
    // Use this for initialization
    void Start () {
        playerchildren = player.transform.childCount;
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);

    }

    // Update is called once per frame
    void LateUpdate () {
        playerchildren = player.transform.childCount;
        Vector3 centroid = Vector3.zero;
        for (int i = 0; i < playerchildren; i++)
        {
            centroid += player.transform.GetChild(i).transform.position;
        }
        centroid /= playerchildren;

        transform.LookAt(centroid);
        //transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0, -5.0f, 10.0f),Time.deltaTime * 5.0f);
        //offsetX = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offsetX;
        //offsetY = Quaternion.AngleAxis(Input.GetAxis("Vertical") * turnSpeed, Vector3.right) * offsetY;
        //transform.position = player.transform.position + offsetX + offsetY;
        //transform.LookAt(player.transform.position);
    }

    //public event System.EventHandler ChildrenChanged;

    ////#2
    //protected virtual void OnAgeChanged()
    //{
    //    if (ChildrenChanged != null) ChildrenChanged(this, EventArgs.Empty);
    //}

    //public int PlayerChildren
    //{
    //    get { return playerchildren; }
    //    set
    //    {
    //        playerchildren = value;
    //        OnAgeChanged();
    //    }
    //}
}
