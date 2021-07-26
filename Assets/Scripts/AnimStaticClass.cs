using DG.Tweening;
using UnityEngine;

/// <summary>
/// Дефолтные значения времени 0.5 секунд
/// </summary>
public static class AnimStaticClass 
{
    
    public static void SimpleMoveAnimation(Transform objToMove, Vector3 startPosition, Vector3 endPosition,
        float animationTime = 0.5f ,float animationDelayToReturn = 0.5f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(objToMove.DOLocalMove(endPosition, animationTime));
        sequence.AppendInterval(animationDelayToReturn);
        sequence.Append(objToMove.DOLocalMove(startPosition, animationTime));
    }
    
    public static void MoveAnimationWithDelayOnStart(Transform objToMove, Vector3 startPosition, Vector3 endPosition,
        float animationTime = 0.5f ,float animationDelayToReturn = 0.5f, float animationDelayOnStart = 0.5f)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(animationDelayOnStart);
        sequence.Append(objToMove.DOLocalMove(endPosition, animationTime));
        sequence.AppendInterval(animationDelayToReturn);
        sequence.Append(objToMove.DOLocalMove(startPosition, animationTime));
    }

    public static void SimpleRotation(Transform objToRotate,Vector3 rotateTo, float duration = 1, RotateMode rotateMode = RotateMode.Fast)
    {
         Sequence sequence = DOTween.Sequence();
         sequence.Append(objToRotate.transform.DORotate(rotateTo + new Vector3(0,0,180), duration, rotateMode));
    }
    
    
    /// <summary>
    /// Prealpha version
    /// </summary>
    public static void CoinSpecialMovement (Transform objToMove, Vector3 startPosition, Vector3 endPosition,
        float animationTime = 0.95f)
    
    {
        // БОЛЬШЕ КОСТЫЛЕЙ БОГУ КОСТЫЛЕЙ 
        int revert = 0;
         
        Sequence sequence = DOTween.Sequence();
        
        // Этa логика должна быть не тут
        if (revert == 0)
        {
            sequence.Append(objToMove.DOLocalMove(endPosition, animationTime));
            revert = 1;
            return;
        }
        
        if (revert == 1)
        {
            sequence.Append(objToMove.DOLocalMove(startPosition, animationTime));
            revert = 0;
            return;
        }
        
        
        
    }
}
