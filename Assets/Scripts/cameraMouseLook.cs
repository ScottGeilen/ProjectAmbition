using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMouseLook : MonoBehaviour
{
    GameObject character;
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 3.0f;
    public float smoothing = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        if (mouseLook.y > 90) {
            mouseLook.y = 90;
        } else if (mouseLook.y < -90) {
            mouseLook.y = -90;
        }

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
