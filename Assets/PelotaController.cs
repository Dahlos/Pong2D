using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaController : MonoBehaviour
{
    public float speed;
    public float impulsoInicial;
    Rigidbody2D rb;
    public float timeToRestart;
    public Vector2[] startPositions;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("IniciarMovimiento");
    }

    public IEnumerator IniciarMovimiento()
    {
        yield return new WaitForSeconds(timeToRestart);
        rb.AddForce(GetRandomStart() * impulsoInicial, ForceMode2D.Impulse);
    }

    Vector2 GetRandomStart()
    {
        int position = UnityEngine.Random.Range(0, startPositions.Length - 1);
        return startPositions[position];
    }

    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            ResetPelota();
        }
    }

    public void ResetPelota()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        StartCoroutine("IniciarMovimiento");
    }
}
