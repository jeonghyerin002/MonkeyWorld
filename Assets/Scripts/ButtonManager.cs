using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header ("MainScene ��ư")]
    public Button startButton;
    public Button helpButton;
    public Button exitButton;

    [Header("Panel")]
    public GameObject settingPanel;
    public GameObject helpPanel;

    [Header("���� ��ư")]
    public Button settingButton;

    [Header("SettingPanel ��ư")]
    public Button settingPanelExitButton;
    public Button toMainSceneButton;
    [Range(0, 100)]
    public int soundSetting = 50;
    [Range(0, 100)]
    public float  sensitivity = 100.0f;

    [Header("HelpPanel ��ư")]
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
        SceneManager.LoadScene("SampleScene");        //����: ���þ��� ù ���ε� �̰� �̸� ���߿� �ٲٴ��� �ؾ��ҵ� �׳� �̸��̴ϱ� ���ֵ� �ǰ� 
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
