using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{

    private SpriteRenderer catRenderer;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        catRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.position += -Vector3.left * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            catRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            catRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.position += Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.position += -Vector3.down * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }
    }
}
