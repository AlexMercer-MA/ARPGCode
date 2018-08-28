using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//USELESS
public class UISelectLevel : MonoBehaviour
{

    public string[] dungenName;
    public GameObject selectLevelWindow;
    public Dropdown selectLevelDropdown;
    public Button sureButton;
    public Button cancelButton;

    public int maxLevel;
    public int index;
    SceneSetting sceneSetting;

    void Start()
    {
        Button surebtn = sureButton.GetComponent<Button>();
        surebtn.onClick.AddListener(LoadScene);
        Button cancelbtn = cancelButton.GetComponent<Button>();
        cancelbtn.onClick.AddListener(CloseWindow);
        selectLevelWindow.SetActive(false);
        AddOpations();
    }

    void AddOpations()
    {
        Dropdown selectLevel = selectLevelDropdown.GetComponent<Dropdown>();
        selectLevel.ClearOptions();

        List<string> opations = new List<string>();
        for (int i = 1; i <= maxLevel; i++)
        {
            opations.Add("Level " + i);
        }
        selectLevel.AddOptions(opations);
    }

    void LoadScene()
    {
        selectLevelWindow.SetActive(false);
        int nextIndex = Random.Range(0, dungenName.Length);
        string nextDungen = dungenName[nextIndex];
        SceneSetting.GetInstance.level = selectLevelDropdown.value;
        SceneManager.LoadScene(nextDungen, LoadSceneMode.Single);
    }

    void CloseWindow()
    {
        selectLevelWindow.SetActive(false);
        //UIPanelController.GetInstance.HideCursor ();
    }
}