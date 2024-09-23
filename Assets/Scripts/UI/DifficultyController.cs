using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    public DifficultySettings easySettings;
    public DifficultySettings mediumSettings;
    public DifficultySettings hardSettings;

    private DifficultySettings currentSettings;

    public Image easyOutline;
    public Image mediumOutline;
    public Image hardOutline;

    void Start()
    {
        SetDifficulty("Medium");
    }

    public void SetDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                currentSettings = easySettings;
                UpdateOutlines(easyOutline, mediumOutline, hardOutline);
                break;
            case "Medium":
                currentSettings = mediumSettings;
                UpdateOutlines(mediumOutline, easyOutline, hardOutline);
                break;
            case "Hard":
                currentSettings = hardSettings;
                UpdateOutlines(hardOutline, easyOutline, mediumOutline);
                break;
        }
    }

    private void UpdateOutlines(Image selectedOutline, Image outline1, Image outline2)
    {
        selectedOutline.enabled = true;  
        outline1.enabled = false;         
        outline2.enabled = false;
    }

    public DifficultySettings GetCurrentSettings()
    {
        return currentSettings;
    }

    public void OnEasyButtonClicked()
    {
        SetDifficulty("Easy");
    }

    public void OnMediumButtonClicked()
    {
        SetDifficulty("Medium");
    }

    public void OnHardButtonClicked()
    {
        SetDifficulty("Hard");
    }
}
