using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phone3Input : MonoBehaviour
{
    public GameObject doorToUnlock;
    public string phoneNum;

    [SerializeField]
    private TMP_InputField tmpInputField;
    public SoundManager soundManager;

    // Function to be called when a button is clicked
    public void OnInputButtonClick(int numberToInput)
    {
        // Set the TextMeshPro input field text
        tmpInputField.text = tmpInputField.text + numberToInput.ToString();
    }

    public void OnCallButtonPress()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (tmpInputField.text == phoneNum)
        {
            soundManager.SwtichPhone(3);
            soundManager.PlayCorrectSound();
            doorToUnlock.SetActive(true);
            tmpInputField.text = "";
        }
        else
        {
            tmpInputField.text = "";
        }
    }
}
