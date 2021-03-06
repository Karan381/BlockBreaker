using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float widthunits;
    [SerializeField] float min;
    [SerializeField] float max;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xpospaddle=(Input.mousePosition.x / Screen.width) * widthunits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(xpospaddle,min,max);
        transform.position = paddlePos;
    }
}
