using TMPro;
using UnityEngine;
using static Gamemanager;

public class Buttoncontrols : MonoBehaviour
{
    [SerializeField] private Gamemanager gameManager;
    [SerializeField] private GameObject RecipeTextBox;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject recipeScreen;
    [SerializeField] private TextMeshProUGUI RecipeText;
    public void StartButton()
    {
        Debug.Log("Choosing random recipe from list");
        gameManager.SelectRecipe();
        Debug.Log("Fidning steps lists for chosen recipe");
        RecipeText.text = gameManager.currentRecipeText;
        Debug.Log("Setting recipe text and image to chosen recipe text and image");
        RecipeText.text = gameManager.currentRecipeText;
        Debug.Log("Start screen turned off");
        startScreen.SetActive(false); 
        recipeScreen.SetActive(true);
    }
    public void FinishedReadingRecipe()
    {
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
    public void FinishRecipeStep2()
    {
        gameManager.NextStep();
        Debug.Log("Initiate next step in recipe");
        GameObject recipeStep = transform.parent.parent.gameObject;
        recipeStep.SetActive(false);
    }
    public void FinishRecipeStep3()
    {
        gameManager.GameLoops();
        Debug.Log("Initiate next step in recipe");
        GameObject recipeStep = gameObject.transform.parent.gameObject;
        recipeStep.SetActive(false);
    }
    public void FinishRecipeStep4()
    {
        gameManager.NextStep();
        Debug.Log("Initiate next step in recipe");
        GameObject background = transform.parent.parent.transform.GetChild(0).gameObject;
        GameObject recipeStep = transform.parent.parent.gameObject;
        GameObject button = transform.parent.gameObject;
        button.SetActive(false);
        recipeStep.SetActive(false);
    }
}
