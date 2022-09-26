using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Button connectionVertexBtn, objectiveVertexBtn, playBtn, resetBtn;
    [SerializeField] private GameObject player;

    private void Awake() {
        AssingButtons();
    }
    private void AssingButtons(){
        connectionVertexBtn.onClick.AddListener(ConnectionVertexClick);
        objectiveVertexBtn.onClick.AddListener(ObjectiveVertexClick);
        playBtn.onClick.AddListener(PlayClick);
        resetBtn.onClick.AddListener(ResetClick);
    }
    private void ConnectionVertexClick(){
        GameManager.instance.SetVertexType(GameManager.VertexType.Connection);
    }
    private void ObjectiveVertexClick(){
        GameManager.instance.SetVertexType(GameManager.VertexType.Objective);
    }
    private void PlayClick(){
        Instantiate(player, GameManager.instance.GetInitialVertex.transform.position, Quaternion.identity);
        SetPlayButtonInteractable(false);
    }
    private void ResetClick(){
        SceneManager.LoadScene(0);
    }
    public void SetActiveButtons(bool value){
        connectionVertexBtn.interactable = value;
        objectiveVertexBtn.interactable = value;
    }
    public void SetPlayButtonInteractable(bool value){
        playBtn.interactable = value;
    }
}
