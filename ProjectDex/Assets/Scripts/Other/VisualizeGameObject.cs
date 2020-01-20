using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeGameObject : MonoBehaviour
{
    public Color gizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
