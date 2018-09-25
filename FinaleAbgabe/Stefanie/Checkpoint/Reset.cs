using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ResetObject obj = other.GetComponent<ResetObject>();
        if (obj != null)
        {
            obj.ResetingMe();
        }
    }
}
