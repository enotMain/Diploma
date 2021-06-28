using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleBack : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(3);
    }
}
