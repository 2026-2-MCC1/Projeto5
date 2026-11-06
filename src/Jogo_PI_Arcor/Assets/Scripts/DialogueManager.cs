
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image portraitImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject chatboxPanel;
    [SerializeField] private GameObject DarkBackground;

    [Header("Dialogue Content")]
    [SerializeField] private DialogueSequence currentDialogue;

    [Header("Settings")]
    [SerializeField] private float typingSpeed = 0.03f;

    private Queue<DialogueLine> dialogueQueue =
        new Queue<DialogueLine>();

    private bool isTyping = false;
    private bool isDialogueActive = false;

    private string currentLineText = "";

    private float previousTimeScale = 1f;
    private bool dialoguePausedGame = false;

    private void Start()
    {
        DarkBackground.SetActive(true);
        StartDialogue(currentDialogue);
    }

    private void Update()
    {
        if (!isDialogueActive)
            return;

        bool advancePressed = false;

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            advancePressed = true;
        }

        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            advancePressed = true;
        }

        if (advancePressed)
        {
            DisplayNextLine();
        }
    }

    public void StartDialogue(DialogueSequence dialogue)
    {
        if (dialogue == null)
        {
            Debug.LogError("DialogueManager: No DialogueSequence assigned!");
            return;
        }

        if (chatboxPanel == null || dialogueText == null)
        {
            Debug.LogError("DialogueManager: Missing essential UI references!");
            return;
        }

        StopAllCoroutines();

        // Freeze the game.
        if (!dialoguePausedGame)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            dialoguePausedGame = true;
        }

        isDialogueActive = true;
        isTyping = false;

        chatboxPanel.SetActive(true);

        dialogueQueue.Clear();

        foreach (DialogueLine line in dialogue.lines)
        {
            dialogueQueue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (!isDialogueActive)
            return;

        // If text is still typing, finish the current line.
        if (isTyping)
        {
            StopAllCoroutines();

            dialogueText.text = currentLineText;
            isTyping = false;

            return;
        }

        // End dialogue when there are no lines left.
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = dialogueQueue.Dequeue();

        // Update character portrait and name.
        if (currentLine.character != null)
        {
            if (nameText != null)
                nameText.text = currentLine.character.characterName;

            if (portraitImage != null)
            {
                portraitImage.sprite = currentLine.character.portrait;

                portraitImage.gameObject.SetActive(
                    currentLine.character.portrait != null
                );
            }
        }
        else
        {
            // Narrator / character without a portrait.
            if (nameText != null)
                nameText.text = "";

            if (portraitImage != null)
                portraitImage.gameObject.SetActive(false);
        }

        // Start typewriter effect.
        currentLineText = currentLine.text;
        StartCoroutine(TypeText(currentLineText));
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;

            // Uses real time, so dialogue works while the game is frozen.
            yield return new WaitForSecondsRealtime(
                Mathf.Max(0f, typingSpeed)
            );
        }

        isTyping = false;
    }

    private void EndDialogue()
    {
        StopAllCoroutines();

        isTyping = false;
        isDialogueActive = false;

        chatboxPanel.SetActive(false);
        DarkBackground.SetActive(false);

        // Restore the previous game speed.
        if (dialoguePausedGame)
        {
            Time.timeScale = previousTimeScale;
            dialoguePausedGame = false;
        }

        Debug.Log("End of conversation.");
    }

    private void OnDestroy()
    {
        // Safety: don't leave the game frozen if this object is destroyed.
        if (dialoguePausedGame)
        {
            Time.timeScale = previousTimeScale;
            dialoguePausedGame = false;
        }
    }
}
