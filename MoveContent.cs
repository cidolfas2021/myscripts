﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveContent : MonoBehaviour
{

    public void MoveContentPane(float value)
    {
        var pos = transform.position;
        pos.y += value;
        transform.position = pos;
    }
}
