using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float movingSpeed = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movingSpeed * Time.deltaTime, 0);
    }
}
