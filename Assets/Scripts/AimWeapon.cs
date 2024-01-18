using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        
        Vector3 aimDirection =
    }
}
