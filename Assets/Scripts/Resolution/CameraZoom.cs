using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public SpriteRenderer border;
    // Start is called before the first frame update
    void Start()
    {
        float orthoSize = border.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
    }

}
