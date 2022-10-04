using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Player : MonoBehaviour
{
    public Transform body_prefab;
    public List<Transform> body_parts;
    public int speed;
    private Rigidbody2D rigid_body;

    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        body_parts = new List<Transform>();
        body_parts.Add(this.transform);
    }

    void FixedUpdate()
    {
        Vector2 directional_vector = new Vector2((Input.GetAxis("Horizontal")) * speed, (Input.GetAxis("Vertical")) * speed);
        for (int i = body_parts.Count - 1; i > 0; i--)
        {
            body_parts[i].position = body_parts[i - 1].position;
        }
        rigid_body.velocity = directional_vector;
    }

    public void Grow()
    {
        for (int i = 0; i < 3; i++)
        {
            Transform body = Instantiate(this.body_prefab);
            body.transform.position = body_parts[body_parts.Count - 1].position;
            body_parts.Add(body);
        }
    }

    public void destroyBody()
    {
        for (int i = 1; i < body_parts.Count; i++)
        {
            Destroy(body_parts[i].transform.gameObject);
        }
        body_parts.RemoveRange(1, body_parts.Count - 1);
    }

    public void Shrink()
    {
        if (body_parts.Count - 1 > 3)
        {
            Destroy(body_parts[body_parts.Count - 1].gameObject);
            body_parts.RemoveAt(body_parts.Count - 1);

        }
    }

}
