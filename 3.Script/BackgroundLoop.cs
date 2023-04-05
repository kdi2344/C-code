using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float height;

    private void Awake()
    {
        height = transform.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -height)
        {
            Reposition();
        }
    }

    public void Reposition()
    {
        Vector2 offset = new Vector2(0, 2 * height);
        transform.position = (Vector2)transform.position + offset;
    }
}
