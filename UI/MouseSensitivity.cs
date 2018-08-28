using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{

    public Slider slider;
    public CameraMover cameraMover;

    void Update()
    {
        cameraMover.mouseSensitivity = slider.value;
    }
}
