using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject deleteTip;
    public GameObject showTip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            deleteTip.SetActive(false);
            showTip.SetActive(true);
        }
    }
}
