using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNicknamePanel : LobbyPanelBase
{
    [Header("Non-Inherited variables")]
    [SerializeField] private Button createNicknameBtn;
    [SerializeField] private TMP_InputField createNicknameInputField;

    private const int MIN_CHAR_NICKNAME = 2;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        createNicknameBtn.interactable = false;
        createNicknameBtn.onClick.AddListener(OnClickCreateNickname);
        createNicknameInputField.onValueChanged.AddListener(InputValueChanged);
    }

    private void InputValueChanged(string arg0)
    {
        createNicknameBtn.interactable = arg0.Length >= MIN_CHAR_NICKNAME;
    }

    private void OnClickCreateNickname()
    {
        var nickname = createNicknameInputField.text;
        if(nickname.Length >= MIN_CHAR_NICKNAME)
        {
            base.ClosePanel();
            lobbyUIManager.ShowPanel(LobbyType.MiddleSectionPanel);
        }
    }
}