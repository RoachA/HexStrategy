using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera _gameCam;
    
    private void Start()
    {
        _gameCam = GetComponentInChildren<Camera>();
    }

}
