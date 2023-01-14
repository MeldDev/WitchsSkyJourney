using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWellConfiguration : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void SetConfiguration(float speed, float size)
    {
        _speed = speed;
        transform.localScale = new Vector3(size, size, 1);
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - _speed * Time.deltaTime, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
}
