using System.Collections.Generic;
using CleverCrow.Fluid.Dialogues;
using CleverCrow.Fluid.Dialogues.Choices;
using CleverCrow.Fluid.Dialogues.Graphs;
using TMPEffects.CharacterData;
using TMPEffects.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.UI
{
    public class DialogController : Singleton<DialogController>
    {
        [SerializeField] private CanvasGroup _dialogPanelGroup;
        [SerializeField] private DialogueGraph _debugGraph;
        [SerializeField] private DialogChoiceButton _dialogChoiceButtonPrefab;
        [SerializeField] private Transform _choiceButtonParent;
        [SerializeField] private Image _portraitUI;

        [SerializeField] private TMP_Text _speakerNameText;
        [SerializeField] private TMP_Text _mainTextBox;

        [SerializeField] private TMPWriter _writer;

        private DialogueController _controller;
        private DatabaseInstanceExtended _databaseInstance;

        private bool _dialogActive;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _databaseInstance = new DatabaseInstanceExtended();
            _controller = new DialogueController(_databaseInstance);

            _controller.Events.Begin.AddListener(HandleBegin);
            _controller.Events.Speak.AddListener(HandleSpeak);
            _controller.Events.Choice.AddListener(HandleChoice);
            _controller.Events.End.AddListener(HandleEnd);
            
            _controller.Play(_debugGraph);
        }


        private void OnDestroy()
        {
            _controller.Events.Begin.RemoveListener(HandleBegin);
            _controller.Events.Speak.RemoveListener(HandleSpeak);
            _controller.Events.Choice.RemoveListener(HandleChoice);
            _controller.Events.End.RemoveListener(HandleEnd);
            

        }

        private void HandleEnd()
        {
            _dialogActive = false;
            _dialogPanelGroup.alpha = 0;
        }

        private void HandleSpeak(IActor actor, string message)
        {
            var choiceCount = _choiceButtonParent.childCount;
        
            for (int i = 0; i < choiceCount; i++)
            {
                var button = _choiceButtonParent.GetChild(i);
            
                Destroy(button.gameObject);
            }

            _speakerNameText.text = actor.DisplayName;
            _mainTextBox.text = message;
        }

        private void HandleChoice(IActor actor, string message, List<IChoice> choices)
        {
            HandleSpeak(actor, message);
            _dialogActive = false;
            for (var i = 0; i < choices.Count; i++)
            {
                var choice = choices[i];
                var choiceObject = Instantiate(_dialogChoiceButtonPrefab, _choiceButtonParent);
                choiceObject.clickEvent.AddListener(SubmitChoice);
                choiceObject.SetupChoice(choice);
            }
        }

        private void HandleBegin()
        {
            _dialogPanelGroup.alpha = 1;
            _dialogActive = true;
        }

        private void OnSubmit()
        {
            if (_dialogActive)
            {
                _controller.Next();
            }
        }

        private void SubmitChoice(int choiceIndex)
        {
            _controller.SelectChoice(choiceIndex);

            _dialogActive = true;
        }

// Update is called once per frame
        void Update()
        {
        
        }
    }
}
