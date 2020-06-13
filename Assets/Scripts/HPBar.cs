using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().transform.localScale.x < 0.3)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
        else if(this.GetComponent<SpriteRenderer>().transform.localScale.x < 0.6)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f, 1f);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.317f, 1f, 0f, 1f);
        }
    }
}
