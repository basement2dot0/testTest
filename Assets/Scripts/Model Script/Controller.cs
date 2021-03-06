﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class Controller : MonoBehaviour
{
    public abstract void ReadInput(InputData data);

    protected Rigidbody rb;

    protected bool newInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

}
