using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCreateVertex : MonoBehaviour
{
    [SerializeField] private GameObject vertexInitial;
    [SerializeField] private GameObject vertexConnection;
    [SerializeField] private GameObject vertexObjective;
    [SerializeField] private CanvasManager canvasManager;
    private void OnMouseDown() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (GameManager.instance.GetVertexSelected != null && !GameManager.instance.GetHasObjectiveVertex)
        {
            if (Physics.Raycast(ray, out hit)) {
                switch (GameManager.instance.GetVertexType)
                {
                    case GameManager.VertexType.Connection:
                        Instantiate(vertexConnection, hit.point,Quaternion.identity);
                    break;
                    case GameManager.VertexType.Objective:
                        Instantiate(vertexObjective, hit.point,Quaternion.identity);
                        GameManager.instance.SetHasObjectiveVertex(true);
                        canvasManager.SetActiveButtons(false);
                    break;
                }
            }
            GameManager.instance.GetVertexSelected.GetComponent<Renderer>().material = GameManager.instance.GetVertexSelected.GetComponent<VertexClick>().GetDefaultMaterial;
            GameManager.instance.SetVertexSelected(null);
        }
        else if(!GameManager.instance.GetHasInitialVertex)
        {
            if (Physics.Raycast(ray, out hit)) {
                Instantiate(vertexInitial, hit.point,Quaternion.identity);
                GameManager.instance.SetHasInitialVertex(true);
                canvasManager.SetActiveButtons(true);
            }
        }
    }
}
