using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Phone1Input : MonoBehaviour
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
            soundManager.SwtichPhone(1);
            soundManager.PlayCorrectSound();
            doorToUnlock.SetActive(false);
            tmpInputField.text = "";
        }
        else
        {
            soundManager.PlayWrongSound();
            tmpInputField.text = "";
        }
    }
}
