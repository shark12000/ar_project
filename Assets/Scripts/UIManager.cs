using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster _raycaster;
    private PointerEventData pData;
    private EventSystem eventSystem; 
    public Transform selectionPoint;

    public static UIManager instance;
    
    void Start()
    {
        _raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);

        pData.position = selectionPoint.position;
    }

    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();
        _raycaster.Raycast(pData, results);

        foreach (var result in results)
        {
            if (result.gameObject == button)
            {
                return true;
            } 
        }

        return false;
    }
    
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
                
            }

            return instance;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
