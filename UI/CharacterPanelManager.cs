using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelManager : MonoBehaviour
{
    public static CharacterPanelManager GetInstance;
    public GameObject PropertiesPanel;
    public GameObject ShowPropertiesBtnPanel;
    public bool bIsShowProperties;
    public Button showPropertiesBtn;

    void Awake()
    {
        GetInstance = this;
        showPropertiesBtn.onClick.AddListener(ShowPropertiesPanel);
        ShowPropertiesPanel();
    }

    public void ShowPropertiesPanel()
    {
        PropertiesPanel.SetActive(true);
        ShowPropertiesBtnPanel.SetActive(false);
        bIsShowProperties = true;
    }
    
    public void HidePropertiesPanel()
    {
        PropertiesPanel.SetActive(false);
        ShowPropertiesBtnPanel.SetActive(true);
        bIsShowProperties = false;
    }
}
