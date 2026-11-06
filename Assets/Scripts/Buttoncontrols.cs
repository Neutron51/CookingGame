using TMPro;
using UnityEngine;
using static Gamemanager;

public class Buttoncontrols : MonoBehaviour
{
    [SerializeField] private Gamemanager gameManager;
    public void StartButton()
    {
        Debug.Log("Choosing random recipe from list");
        gameManager.SelectRecipe();
        GameObject RecipeTextBox = GameObject.Find("Recipe text");
        Debug.Log("Fidning steps lists for chosen recipe");
        TextMeshProUGUI RecipeText = RecipeTextBox.GetComponent<TextMeshProUGUI>();
        RecipeText.text = gameManager.currentRecipeText;
        Debug.Log("Setting recipe text and image to chosen recipe text and image");
        GameObject startScreen = gameObject.transform.parent.gameObject;
        Debug.Log("Start screen turned off");
        startScreen.SetActive(false);
    }
    public void FinishedReadingRecipe()
    {
        GameObject recipeScreen = gameObject.transform.parent.gameObject;
        gameManager.PrepareRecipeProcess();
        Debug.Log("Finished reding the recipe, now turning recipe screen off, and initiating subsequent minigames/processes");
        recipeScreen.SetActive(false);
    }
    public void FinishRecipeStep()
    {
        gameManager.NextStep();
        Debug.Log("Initiate next step in recipe");
        GameObject recipeStep = gameObject.transform.parent.gameObject;
        recipeStep.SetActive(false);
    }
}
