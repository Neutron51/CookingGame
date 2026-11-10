using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [System.Serializable]
    public class Recipes
    {
        public string RecipeText;
        public string Recipe;
        public List<string> CookingSteps;
    }
    [SerializeField] private bool InitialInstance = false;
    [SerializeField] List<GameObject> RecipeSteps = new List<GameObject>();
    [SerializeField] private Recipes currentRecipe;
    [SerializeField] private int currentStep;
    public string currentRecipeText;
    public List<Recipes> recipes;
    public void SelectRecipe()
    {
        currentRecipe = recipes[Random.Range(0, recipes.Count)];
        currentRecipeText = currentRecipe.RecipeText;
        currentStep = 0;
    }
    public void NextStep()
    {
        currentStep++;
        InitialInstance = true;
        PrepareRecipeProcess();
    }
    public void PrepareRecipeProcess()
    {
        Debug.Log("Start");
        if (!InitialInstance)
        {
            Debug.Log("Prepare recipe pro 1");
            string RecipeName = currentRecipe.Recipe;
            GameObject RecipeProcessGameObject = GameObject.Find(RecipeName);
            foreach (Transform child in RecipeProcessGameObject.transform)
            {
                RecipeSteps.Add(child.gameObject);
                Debug.Log("Added child as a step");
            }
            RecipeSteps[0].SetActive(true);
        }
        else if (currentStep >= RecipeSteps.Count)
        {
            Debug.Log("Recipe finished");
        }
        else if (currentStep < RecipeSteps.Count)
        {
            RecipeSteps[currentStep].SetActive(true);
        }
    }
    public void FinishRecipeStep()
    {
        RecipeSteps[0].transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("Initiate next step in recipe");
    }
}
