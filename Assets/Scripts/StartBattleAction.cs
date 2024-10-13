using CleverCrow.Fluid.Dialogues.Actions;
using CleverCrow.Fluid.Dialogues;

[CreateMenu("Custom/StartBattle")]
public class CustomAction : ActionDataBase {

    public override void OnStart () {
        Battle.StartBattle();
    }

}