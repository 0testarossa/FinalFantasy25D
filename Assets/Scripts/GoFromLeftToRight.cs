using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFromLeftToRight : MonoBehaviour
{
    private float timeMoveFromLeftToRight;
    // Start is called before the first frame update
    void Start()
    {
        timeMoveFromLeftToRight = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeMoveFromLeftToRight -= Time.deltaTime;
        if (timeMoveFromLeftToRight >0)
        {
            transform.position += transform.right * 4 * Time.deltaTime;
        }
        else if(timeMoveFromLeftToRight > -5f)
        {
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
            transform.position += transform.right * -4 * Time.deltaTime;
        }
        else
        {
            timeMoveFromLeftToRight = 5f;
            GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            transform.position += transform.right * 4 * Time.deltaTime;

        }

        //Color color = this.GetComponent<MeshRenderer>().material.color;
        //color.a -= Time.deltaTime * 1;
        //this.GetComponent<MeshRenderer>().material.color = color;
        //this.GetComponent().SpriteRenderer.color = new Color(1f, 1f, 1f, 0f)
    }
}
