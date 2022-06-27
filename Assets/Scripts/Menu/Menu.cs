using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _levelsPanel;
    [SerializeField] private GameObject _settingsPanel;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void SwitchSettingsPanel()
    {
        //_settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SwitchLevelsPanel()
    {
        _levelsPanel.SetActive(!_levelsPanel.activeSelf);
    }

}
