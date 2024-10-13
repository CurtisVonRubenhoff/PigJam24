using System;
using CleverCrow.Fluid.Dialogues.Choices;
using Source.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogChoiceButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _choiceText;

    [SerializeField] private Button _uiButton;

    private DialogController _controller;

    public UnityEvent<int> clickEvent = new ActivateChoiceIndexEvent();

    private class ActivateChoiceIndexEvent : UnityEvent<int> {
    }

    private int _index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SetupChoice(IChoice choice)
    {
        _choiceText.text = choice.Text;
        _uiButton.onClick.AddListener(HandleChoiceClick);
    }


    private void HandleChoiceClick()
    {
        clickEvent.Invoke(transform.GetSiblingIndex());
    }

    private void OnDestroy()
    {
        _uiButton.onClick.RemoveAllListeners();
    }
}