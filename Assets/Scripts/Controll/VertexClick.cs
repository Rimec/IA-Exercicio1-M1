using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexClick : MonoBehaviour
{
    [SerializeField] private Material vertexSelected;
    [SerializeField] private Material defaultMaterial;
    private void Start(){
        defaultMaterial = this.gameObject.GetComponent<Renderer>().material;
    }
    private void OnMouseDown() {
        if (!GameManager.instance.GetHasObjectiveVertex)
        {
            if (GameManager.instance.GetVertexSelected != null)
                GameManager.instance.GetVertexSelected.GetComponent<Renderer>().material = GameManager.instance.GetVertexSelected.GetComponent<VertexClick>().GetDefaultMaterial;
            GameManager.instance.SetVertexSelected(this.gameObject);
            this.gameObject.GetComponent<Renderer>().material = vertexSelected;
        }
    }
    public Material GetDefaultMaterial => defaultMaterial;
}
