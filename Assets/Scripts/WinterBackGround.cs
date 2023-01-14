using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBackGround : MonoBehaviour
{
    float pos;
    [SerializeField] float _speed;
    void Update()
    {
        if (!LevelSettings.instance.IsPause)
        {
            pos -= _speed * Time.deltaTime;
            pos = Mathf.Repeat(pos, this.gameObject.GetComponent<SpriteRenderer>().localBounds.size.x);
            transform.localPosition = new Vector3(pos, 0, 10);
        }

    }
}
