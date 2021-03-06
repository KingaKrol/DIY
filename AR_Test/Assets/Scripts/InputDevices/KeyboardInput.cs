﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    void Update()
    {
        // move left and right
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0.1f)
        {
            VirtualInputManager.Instance.MoveRight = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveRight = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < -0.1f)
        {
            VirtualInputManager.Instance.MoveLeft = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveLeft = false;
        }

        // move up and down
        if (Input.GetKey(KeyCode.W))
        {
            VirtualInputManager.Instance.MoveUp = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveUp = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            VirtualInputManager.Instance.MoveDown = true;
        }

        else
        {
            VirtualInputManager.Instance.MoveDown = false;
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            VirtualInputManager.Instance.Jump = true;
        }

        else
        {
            VirtualInputManager.Instance.Jump = false;
        }
    }
}
