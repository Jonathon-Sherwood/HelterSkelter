using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        Spinning();
    }

    public void Spinning()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
