using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offset;
    private Vector3 Change;
    public float Speed = 0.4f;
    
    public float MouseScroll;
    public float MouseScrollSpeed = 2f;

    public float MinZoom = 5f;
    public float MaxZoom = 20f;

    void Update()
    {
        Vector3 position = GetCenter() + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, position, ref Change, Speed);
        Zoom();
    }

    Vector3 GetCenter(){
        MassSpawner ms = MassSpawner.ins;

        Bounds bounds = new Bounds(ms.Players[0].transform.position, Vector3.zero);

        for(int i = 0; i < ms.Players.Count; i++){
            bounds.Encapsulate(ms.Players[i].transform.position);
        }

        return bounds.center;
    }

    void Zoom(){
        MouseScroll -= Input.GetAxis("Mouse ScrollWheel") * MouseScrollSpeed;
        MouseScroll = Mathf.Clamp(MouseScroll, MinZoom, MaxZoom);
        Camera.main.orthographicSize = MouseScroll;
    }
}
