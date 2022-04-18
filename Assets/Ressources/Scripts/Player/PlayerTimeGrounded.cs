using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTimeGrounded : MonoBehaviour
{
    public TextMeshProUGUI cooldownJump;
    public Animator _animator;

    [SerializeField]
    public static float _time = 10;
    private bool ready = true;

    void Update()
    {
        if (!GameManager.isGameStart)
        {
            return;
        }

        if (_animator.GetBool("isGrounded") && ready)
        {
            StartCoroutine(Timer());
        }
        if (_animator.GetBool("Jump"))
        {
            _time = 10;
        }


        if (_time <= 5)
        {
            cooldownJump.text = _time.ToString();
            cooldownJump.color = Color.white;
            cooldownJump.fontSize = 150;
        }
        else
        {
            cooldownJump.text = "";
        }

        if (_time == 3)
        {
            cooldownJump.color = Color.green;
            cooldownJump.fontSize = 200;

        }
        if (_time == 2)
        {
            cooldownJump.color = Color.yellow;
            cooldownJump.fontSize = 250;
        }
        if (_time == 1)
        {
            cooldownJump.color = Color.red;
            cooldownJump.fontSize = 300;
        }

        if (_time == 0)
        {
            GameManager.GameOver();
        }

    }

    IEnumerator Timer()
    {
        ready = false;
        yield return new WaitForSeconds(1);
        _time--;
        ready = true;
    }
}
