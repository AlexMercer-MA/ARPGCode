using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    public float mouseSensitivity = 5f;
    public float minCamAngle = -30f;
    public float maxCamAngle = 70f;
    public float camScale = 1f;
    public float camScaleSpeed = 5f;
    public float camLerpSpeed = 5f;
    public Vector3 offset;

    float angleHRaw;
    float angleVRaw;
    float angleH;
    float angleV = 10f;
    float tempCamScale = 1f;

    void Start()//在新场景开始的时候，获得相机和目标
    {
        cam = Camera.main;
        target = CharacterBehaviour.GetInstace.transform.Find("MainCamTarget").gameObject;
        tempCamScale = 1f;

        if (GameObject.Find("GameSettings") != null)
        {
            mouseSensitivity = GameProgramOptions.GetInstance.mouseSensitivity;
        }
        else
        {
            mouseSensitivity = 5f;
        }
    }

    void LateUpdate()
    {
        if (!PanelUIManager.GetInstance.bInPanelUIMode)
        {
            Zoom();
            OrbitCam();
        }

        cam.transform.position = target.transform.position + Quaternion.Euler(angleV, angleH, 0) * offset * camScale;
        cam.transform.LookAt(target.transform);
    }

    void Zoom()
    {
        //缩放相机大小
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            tempCamScale -= camScaleSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            tempCamScale += camScaleSpeed * Time.deltaTime;
        }
        tempCamScale = Mathf.Clamp(tempCamScale, 0.75f, 1.35f);
        camScale = Mathf.Lerp(camScale, tempCamScale, camLerpSpeed * Time.deltaTime);
    }

    void OrbitCam()
    {
        angleHRaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        angleVRaw += Input.GetAxis("Mouse Y") * mouseSensitivity * -0.5f;
        angleVRaw = Mathf.Clamp(angleVRaw, minCamAngle, maxCamAngle);

        angleH = Mathf.Lerp(angleH, angleHRaw, 10 * Time.deltaTime);
        angleV = Mathf.Lerp(angleV, angleVRaw, 10 * Time.deltaTime);
    }
}