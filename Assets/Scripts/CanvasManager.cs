using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Button connectionVertexBtn, objectiveVertexBtn;

    private void Awake() {
        AssingButtons();
    }
    private void AssingButtons(){
        connectionVertexBtn.onClick.AddListener(ConnectionVertexClick);
        objectiveVertexBtn.onClick.AddListener(ObjectiveVertexClick);
    }
    private void ConnectionVertexClick(){
        GameManager.instance.SetVertexType(GameManager.VertexType.Connection);
    }
    private void ObjectiveVertexClick(){
        GameManager.instance.SetVertexType(GameManager.VertexType.Objective);
    }
    public void SetActiveButtons(bool value){
        connectionVertexBtn.interactable = value;
        objectiveVertexBtn.interactable = value;
    }
}
