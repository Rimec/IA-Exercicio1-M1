using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCreateVertex : MonoBehaviour
{
    [SerializeField] private GameObject vertexInitial;
    [SerializeField] private GameObject vertexConnection;
    [SerializeField] private GameObject vertexObjective;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private WPManager wPManager;
    private int waypointsNum = 1;
    private void OnMouseDown() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (GameManager.instance.GetVertexSelected != null && !GameManager.instance.GetHasObjectiveVertex)
        {
            if (Physics.Raycast(ray, out hit)) {
                switch (GameManager.instance.GetVertexType)
                {
                    case GameManager.VertexType.Connection:
                        GameObject newVertexConnection = Instantiate<GameObject>(vertexConnection, hit.point,Quaternion.identity);
                        newVertexConnection.name += waypointsNum;
                        foreach (var waypoint in wPManager.GetWaypoints)
                        {
                            wPManager.AddLink(waypoint, newVertexConnection);
                        }
                        wPManager.AddWaypoint(newVertexConnection);
                        // wPManager.AddLink(GameManager.instance.GetVertexSelected, newVertexConnection);
                        waypointsNum++;
                    break;
                    case GameManager.VertexType.Objective:
                        // Instantiate(vertexObjective, hit.point,Quaternion.identity);
                        GameObject newVertexObjective = Instantiate<GameObject>(vertexObjective, hit.point,Quaternion.identity);
                        foreach (var waypoint in wPManager.GetWaypoints)
                        {
                            if (waypoint!=GameManager.instance.GetInitialVertex)
                            {
                                wPManager.AddLink(waypoint, newVertexObjective);
                            }
                        }
                        wPManager.AddWaypoint(newVertexObjective);
                        // wPManager.AddLink(GameManager.instance.GetVertexSelected, newVertexObjective);
                        GameManager.instance.SetHasObjectiveVertex(true);
                        canvasManager.SetActiveButtons(false);
                        canvasManager.SetPlayButtonInteractable(true);
                        wPManager.CreateGraph();
                    break;
                }
            }
            GameManager.instance.GetVertexSelected.GetComponent<Renderer>().material = GameManager.instance.GetVertexSelected.GetComponent<VertexClick>().GetDefaultMaterial;
            GameManager.instance.SetVertexSelected(null);
        }
        else if(!GameManager.instance.GetHasInitialVertex)
        {
            if (Physics.Raycast(ray, out hit)) {
                GameObject newVertexInitial = Instantiate<GameObject>(vertexInitial, hit.point,Quaternion.identity);
                wPManager.AddWaypoint(newVertexInitial);
                GameManager.instance.SetInitialVertex(newVertexInitial);
                GameManager.instance.SetHasInitialVertex(true);
                canvasManager.SetActiveButtons(true);
            }
        }
    }
}
