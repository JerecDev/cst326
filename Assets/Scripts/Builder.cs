﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject defense;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;
                if (boxCollider.tag != null)
                {
                    if(boxCollider.tag == "placeholder")
                    {
                    }
                }
            }
        }
    }

    void OnMouseDown()
    {
    }
}
