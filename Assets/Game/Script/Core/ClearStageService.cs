using System.Linq.Expressions;
using UnityEngine;

public static class ClearStageService
{

    public const int totalStages = 5;
    public static bool[] clearStageFlags { get; private set; } = new bool[totalStages];

    public static void SetClearScene(int stageNumber)
    {
        try{
            clearStageFlags[stageNumber] = true;
        }
        catch
        {
            Debug.Log("“ü—Í’l‚ª•s³‚Å‚·");
            return;
        }
       
    }
}
