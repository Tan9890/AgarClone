using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

    Image Joybg;
    Image Joystk;
    public Vector3 inputvec;

    // Use this for initialization
    void Start()
    {
        Joybg = GetComponent<Image>();
        Joystk = transform.GetChild(0).GetComponent<Image>();

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Joybg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
            {
            pos.x = pos.x / Joybg.rectTransform.sizeDelta.x;
            pos.y = pos.y / Joybg.rectTransform.sizeDelta.y;

            float x = (Joybg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (Joybg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;
            //inputvec = new Vector3((pos.x * 2) + 1, 0, (pos.y * 2) - 1);
            inputvec = new Vector3(x, 0, y);
            Debug.Log(inputvec);
            inputvec = (inputvec.magnitude > 1.0f) ? inputvec.normalized : inputvec;
            Joystk.rectTransform.anchoredPosition = new Vector3(inputvec.x * (Joybg.rectTransform.sizeDelta.x / 3), inputvec.z * (Joybg.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputvec = Vector3.zero;
        Joystk.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputvec.x != 0)
        {
            return inputvec.x;
        }
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputvec.z != 0)
        {
            return inputvec.z;
        }
        else
            return Input.GetAxis("Vertical");
    }
}
