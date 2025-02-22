﻿using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private string currentLevel;
    private Transform currentSlot;
    public bool Debug;
    private bool canSelect;

    private void Awake()
    {
        canSelect = true;
    }

    public void OnSlotTriggered(Transform slotTransform, string levelName)
    {
        if(!canSelect)return;
        currentLevel = levelName;
        Invoke(nameof(ChangeScene), 1);
        if (currentSlot)
        {
            DeselectSlot(currentSlot);
        }
        SelectSlot(slotTransform);
    }

    private void ChangeScene()
    {
        if (Debug) return;
        SceneManager.LoadScene(currentLevel);
    }

    private void SelectSlot(Transform trans)
    {
        currentSlot = trans;
        canSelect = false;
        trans.DOMoveX(2, .15f).SetRelative(true).SetEase(Ease.OutBack).OnComplete(()=>canSelect = true);
    }

    private void DeselectSlot(Transform trans)
    {
        currentSlot = null;
        trans.DOMoveX(-2, .15f).SetRelative(true).SetEase(Ease.OutBack).OnComplete(() => canSelect = true);
    }
}