using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum VertexType{Initial, Connection, Objective}
    [SerializeField] private VertexType vertexType = VertexType.Initial;
    [SerializeField] private GameObject vertexSelected = null, initialVertex = null;
    [SerializeField] private bool hasInitialVertex = false;
    [SerializeField] private bool hasObjectiveVertex = false;
    private void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start() {
        vertexType = VertexType.Initial;
    }
    public VertexType GetVertexType => vertexType;
    public void SetVertexType(VertexType _vertexType){
        vertexType = _vertexType;
    }
    public GameObject GetVertexSelected => vertexSelected;
    public void SetVertexSelected(GameObject _vertexSelected){
        vertexSelected = _vertexSelected;
    }
    public bool GetHasInitialVertex => hasInitialVertex;
    public void SetHasInitialVertex(bool value){
        hasInitialVertex = value;
    }
    public bool GetHasObjectiveVertex => hasObjectiveVertex;
    public void SetHasObjectiveVertex(bool value){
        hasObjectiveVertex = value;
    }
    public GameObject GetInitialVertex => initialVertex;
    public void SetInitialVertex(GameObject _initialVertex){
        initialVertex = _initialVertex;
    }
}
