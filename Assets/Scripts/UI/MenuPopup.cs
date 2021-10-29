using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MAG.Popups;

public class MenuPopup : PopupState<MenuPopup>
{
    [SerializeField] private Button playButton;

    public override void Init()
    {
        base.Init();
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
        Close();
    }

    public override void Dispose()
    {
        base.Dispose();
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
    }
}
