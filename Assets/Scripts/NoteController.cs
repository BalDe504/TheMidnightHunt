using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityStandardAssets;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.SceneManagement;

public class NoteController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private KeyCode closeKey;

    [Space(10)]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerCam player2;

    [Header("UI Text")]
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [Space(10)]
    [SerializeField] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;

    [SerializeField] private KeyInventory _keyInventory = null;


    public void ShowNote()
    {
        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        DisablePlayer(true);
        isOpen = true;


        switch(gameObject.tag)
        {
            case "Note1":
                if(!_keyInventory.Note1)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note1 = true;
                }
                break;
            
            case "Note2":
                if (!_keyInventory.Note2)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note2 = true;
                }
                break;

            case "Note3":
                if (!_keyInventory.Note3)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note3 = true;
                }
                break;

            case "Note4":
                if (!_keyInventory.Note4)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note4 = true;
                }
                break;

            case "Note5":
                if (!_keyInventory.Note5)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note5 = true;
                }
                break;

            case "Note6":
                if (!_keyInventory.Note6)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note6 = true;
                }
                break;

            case "Note7":
                if (!_keyInventory.Note7)
                {
                    _keyInventory.NotesPicked++;
                    _keyInventory.Note7 = true;
                }
                break;

        }

    }

    void DisableNote()
    {
        noteCanvas.SetActive(false);
        DisablePlayer(false);
        isOpen = false;
    }

    void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
        player2.enabled = !disable;
    }

    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(closeKey))
            {
                DisableNote();
            }
        }
    }
}
