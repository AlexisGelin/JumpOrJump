using System.Collections;
using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    public float time = 0.5f;
    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }


}
