using System;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    // SerializeField allows variable to accessed in Unity Inspector
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStoryText();
    }

    // Update is called once per frame
    void Update() 
    {
        ManageState();
        
    }

    private void ManageState()
    {
        if (Input.anyKeyDown) { 
			int index;
			if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
			else if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
			else index = 2;

			try
			{
			    state = state.NextState(index);

			    LoadNewState(state);

			} catch (IndexOutOfRangeException e) { 
			    Debug.Log(e);
			}

        }
    }

    private void LoadNewState(State state) {
        textComponent.text = state.GetStoryText();
    }
}