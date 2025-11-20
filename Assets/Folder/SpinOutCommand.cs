using UnityEngine;

public class SpinOutCommand : BaseCommand
{
    float speedLoss;
    public SpinOutCommand(float loss) 
    {
        speedLoss = loss;
    }
    public override void Exectute()
    {
        Debug.Log("spinout command");
        GameManager.Instance.OnEnemyCollide(speedLoss);
    }
}
