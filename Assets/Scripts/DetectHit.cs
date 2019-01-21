using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    private GameObject cube;
    private Renderer cubeRender;


    public void Start()
    {
        cube = GameObject.Find("Cube");
        cubeRender = cube.GetComponent<Renderer>();
    }

    public void ChangeColor()
    {
        while (true)
        {
            if (cubeRender.material.color == Color.blue)
            {
                cubeRender.material.color = Color.green;
                if (cubeRender.material.color == Color.green)
                {
                    break;
                }
            }
            cubeRender.material.color = Color.blue;
        }
    }
}
