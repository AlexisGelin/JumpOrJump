using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{


    private void Start()
    {
        GameManager.money += 1;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
