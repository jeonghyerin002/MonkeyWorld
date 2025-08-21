using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header ("MainScene 버튼")]
    public Button startButton;
    public Button helpButton;
    public Button exitButton;

    [Header("Panel")]
    public GameObject settingPanel;
    public GameObject helpPanel;

    [Header("공용 버튼")]
    public Button settingButton;

    [Header("SettingPanel 버튼")]
    public Button settingPanelExitButton;
    public Button toMainSceneButton;
    [Range(0, 100)]
    public int soundSetting = 50;
    [Range(0, 100)]
    public float  sensitivity = 100.0f;

    [Header("HelpPanel 버튼")]
    public Button helpPanelExitButton;
    public Button nextHelpPanelButton;
    public Button beforeHelpPanelButton;

    void Start()
    {
        helpPanel.SetActive(false);
        settingPanel.SetActive(false);

        startButton.onClick.AddListener(StartButton);
        helpButton.onClick.AddListener(HelpButton);
        exitButton.onClick.AddListener(ExitButton);

        settingButton.onClick.AddListener(SettingButton);
        settingPanelExitButton.onClick.AddListener(SettingPanelExitButton);
        toMainSceneButton.onClick.AddListener(ToMainSceneButton);
        helpPanelExitButton.onClick.AddListener(HelpPanelExitButton);

    }

    void StartButton()
    {
        SceneManager.LoadScene("SampleScene");        //혜린: 샘플씬이 첫 씬인데 이거 이름 나중에 바꾸던지 해야할듯 그냥 이름이니까 냅둬도 되고 
    }

    void SettingPanelExitButton()
    {
       settingPanel.SetActive(false);
    }
    void HelpPanelExitButton()
    {
        helpPanel.SetActive(false);
    }

    void SettingButton()
    {
        settingPanel.SetActive(true);
    }

    void HelpButton()
    {
        helpPanel.SetActive(true);
    }

    void ExitButton()
    {
        Application.Quit();
    }
    
    void ToMainSceneButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    void SoundSetting()
    {

    }
}
