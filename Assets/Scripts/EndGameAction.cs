using CleverCrow.Fluid.Dialogues.Actions;
using CleverCrow.Fluid.Dialogues;
using UnityEngine.WSA;
using UnityEngine;

[CreateMenu("Custom/EndGame")]
public class EndGameAction : ActionDataBase {

    public override void OnStart ()
    {
        UnityEngine.Application.Quit();
    }

}