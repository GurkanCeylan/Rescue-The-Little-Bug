using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallax : MonoBehaviour
{
    public float moveSpeed = 0.10f;

    private void Update()
    {
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
