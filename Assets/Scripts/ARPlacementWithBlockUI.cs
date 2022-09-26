using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARPlacementWithBlockUI : MonoBehaviour
{
    [SerializeField] private GameObject placedPrefab;

    [SerializeField] private GameObject uiPanel;

    [SerializeField] private Button toggleButton;

    [SerializeField] private TextMeshProUGUI log;

    private ARRaycastManager _arRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    public void Toggle()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
        var toggleButtonText = toggleButton.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        toggleButtonText.text = uiPanel.activeSelf ? "UI OFF" : "UI ON";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
