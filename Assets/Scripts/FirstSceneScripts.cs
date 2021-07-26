using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneScripts : MonoBehaviour
{
    [Header("FallenBlocks Section")] [SerializeField]
    private GameObject[] fallenBlocks;

    [Header("MovingBlocks Section")] [SerializeField]
    private GameObject[] movingBlocks;

    [SerializeField] private GameObject movingBlockButton;

    [Header("Coins Selection")] [SerializeField]
    private GameObject[] coins;

    private readonly List<GameObject> safeObjNames = new List<GameObject>();
    private Dictionary<float, GameObject> checkList = new Dictionary<float, GameObject>();
    private AudioLevelManager audioLevelManager;

    private void Start()
    {
        audioLevelManager = FindObjectOfType<AudioLevelManager>();
        StartCoroutine(nameof(RepeatCoinRotationCoroutine));
        SetSafeNames();
    }

    private void OnEnable()
    {
        Player.Triggered += CharacterMovementOnTriggered;
    }

    private void CharacterMovementOnTriggered(Collider objTrigger)
    {
        if (objTrigger.gameObject.CompareTag("Coin"))
        {
            audioLevelManager.Play("Coin");
            objTrigger.gameObject.SetActive(false);
        }

        if (objTrigger.gameObject.CompareTag("Button") &&
            objTrigger.gameObject.name == movingBlockButton.gameObject.name 
            && CheckForLastPressed(objTrigger.gameObject)
            )
        {
            audioLevelManager.Play("Button");
            ExecuteMovingBlockButton();
        }

        if (objTrigger.gameObject.CompareTag("FallenBlock") &&
            CheckForLastPressed(objTrigger.gameObject))
        {
            foreach (var block in fallenBlocks)
            {
                if (block.name == objTrigger.gameObject.name)
                {
                    ExecuteFallOfBlocksAnimation(block);
                }
            }
        }

        if (objTrigger.gameObject.CompareTag("Damage"))
        {
            SceneLoader.LoadFirstScene();
        }
    }

    /// <summary>
    ///  Велосипед
    /// </summary>
    private bool CheckForLastPressed(GameObject objForCheck)
    {
        if (!checkList.ContainsValue(objForCheck))
        {
            checkList.Add(Time.time, objForCheck);
            //Debug.Log("Добавлен объект");
            return true;
        }
        else
        {
            foreach (var go in checkList)
            {
                //Debug.Log(go.Key +" " + go.Value.name);
                //Debug.Log("Объект на проверке");
                if (objForCheck == go.Value && Time.time - go.Key >= 10)
                {
                    checkList.Remove(go.Key);
                    return true;
                }
                else
                {
                    
                    //Debug.Log("Условие не пройдено");
                    return false;
                }
            }
        }
        
        return false;
    }


    /// <summary>
    /// Бесконечная корутина 
    /// </summary>
    /// <returns></returns>
    private IEnumerator RepeatCoinRotationCoroutine()
    {
        while (true)
        {
            RotateCoinsAnimation();
            yield return new WaitForSeconds(1);
        }
    }

    private void RotateCoinsAnimation()
    {
        foreach (var c in coins)
        {
            AnimStaticClass.SimpleRotation(c.transform, new Vector3(90, 0, 0), 1);
        }
    }

    private void ExecuteFallOfBlocksAnimation(GameObject block)
    {
        AnimStaticClass.MoveAnimationWithDelayOnStart(block.transform, block.transform.localPosition,
            block.transform.localPosition - new Vector3(0, 10, 0), animationDelayToReturn: 3,
            animationDelayOnStart: 1f);
    }

    private void ExecuteMovingBlockButton()
    {
        AnimStaticClass.SimpleMoveAnimation(movingBlockButton.transform, movingBlockButton.transform.localPosition,
            movingBlockButton.transform.localPosition - new Vector3(0, 0.25f, 0));
        ExecuteMovingBlock();
    }

    private void ExecuteMovingBlock()
    {
        foreach (var block in movingBlocks)
        {
            AnimStaticClass.MoveAnimationWithDelayOnStart(block.transform, block.transform.localPosition,
                block.transform.localPosition + new Vector3(20, 0, 0), 2, 4);
        }
    }

    private void SetSafeNames()
    {
        foreach (var c in coins)
        {
            safeObjNames.Add(c);
        }

        foreach (var c in fallenBlocks)
        {
            safeObjNames.Add(c);
        }

        foreach (var c in movingBlocks)
        {
            safeObjNames.Add(c);
        }

        safeObjNames.Add(movingBlockButton);

        for (int i = 0; i < safeObjNames.Count; i++)
        {
            safeObjNames[i].name = "SafeName" + i;
        }
    }
}