using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)][SerializeField]  string storyText;
    [SerializeField]  State[] nextStates;
 
    public string GetStoryText()
    {
        return storyText;
    }

    public virtual State NextState(int stateNum)
    {
        if (nextStates.Length > stateNum)
            return nextStates[stateNum];
        else
        {
            throw new IndexOutOfRangeException("Value too low");
        }
    }
  }
