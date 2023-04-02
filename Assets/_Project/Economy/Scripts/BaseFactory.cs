using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseFactory : MonoBehaviour
{
    [SerializeReference]
    [Header("The data for the products that this factory can produce")]
    protected List<ResourceData> productData;
    public List<ResourceData> ProductDatas { get => productData; }

    [SerializeReference]
    [Header("The products this factory can produce")]
    protected List<Resource> products;
    public List<Resource> Products { get => products; }

    [SerializeReference]
    [Header("The resources that this factory has")]
    protected List<FactoryResource> factoryResources;
    public List<FactoryResource> FactoryResources { get => factoryResources; }

    void Start()
    {
        if (factoryResources == null)
            factoryResources = new List<FactoryResource>();
    }

    protected IEnumerator ProduceResource(Resource targetProduct, uint amountToProduce)
    {
        // Return if parameters are invalid
        if (amountToProduce == 0 || targetProduct == null)
            yield return null;

        // Get factory resource object
        FactoryResource factoryResource = GetFactoryResourceFromResource(targetProduct, initializeIfNull: true);
        if (factoryResource == null)
            InitializeFactoryResource(targetProduct);

        // Get ingredients required to produce the target product
        Dictionary<Resource, uint> ingredientsRequired = targetProduct.GetIngredientsRequired();
        if (ingredientsRequired == null)
            yield return null;

        UseResourcesFromFactory(ingredientsRequired, amountToProduce);

        int amountProduced = 0;
        while (amountProduced < amountToProduce)
        {
            yield return new WaitForSeconds(factoryResource.TimeToProduce.ToSeconds());
            factoryResource.Resource.AddAmount(1);
            amountProduced++;
        }
    }

    void UseResourcesFromFactory(Dictionary<Resource, uint> ingredientsRequired, uint amountToProduce)
    {
        foreach (var ingredient in ingredientsRequired)
        {
            Resource targetIngredient = ingredient.Key;
            uint amountRequiredToProduce = ingredient.Value * amountToProduce;

            // Return if the factory does not have the ingredient
            if (!FactoryHasResource(targetIngredient))
            {
                Debug.Log("Factory doesn't have " + targetIngredient);
                return;
            }

            // Return if the factory does not have enough of the ingredient
            FactoryResource ingredientFactoryResource = GetFactoryResourceFromResource(targetIngredient);
            if (ingredientFactoryResource == null)
            {
                Debug.Log("Factory doesn't have the factory resource " + targetIngredient);
                return;
            }

            if (amountRequiredToProduce > ingredientFactoryResource.Resource.Amount)
            {
                Debug.Log("Not enough ingredients to produce " + amountToProduce + " of the target product");
                return;
            }

            // Remove the ingredient from the factory
            ingredientFactoryResource.Resource.RemoveAmount(amountRequiredToProduce);
            Debug.Log("Successfully removed " + amountRequiredToProduce + " " + targetIngredient + " from the factory");
        }
    }

    protected FactoryResource InitializeFactoryResource(Resource resourceToAdd)
    {
        if (resourceToAdd == null)
            return null;

        if (FactoryHasResource(resourceToAdd))
            return null;

        FactoryResource factoryResource = resourceToAdd.ToFactoryResource();
        FactoryResources.Add(factoryResource);
        return factoryResource;
    }

    protected void InitializeProduct(Resource productToAdd)
    {
        InitializeFactoryResource(productToAdd);
        if (!Products.Contains(productToAdd))
            Products.Add(productToAdd);
    }

    protected Resource GetProductFromData(ResourceData productData)
    {
        foreach (Resource existingProduct in Products)
        {
            if (existingProduct.Equals(productData))
                return existingProduct;
        }
        return null;
    }

    protected Resource GetProductFromName(string name)
    {
        foreach (Resource existingProduct in Products)
        {
            if (existingProduct.Name.Equals(name))
                return existingProduct;
        }
        return null;
    }

    protected bool FactoryHasResource(Resource resourceToCheck)
    {
        foreach (FactoryResource existingFactoryResource in FactoryResources)
        {
            if (existingFactoryResource.Resource.Equals(resourceToCheck))
                return true;
        }
        return false;
    }

    protected bool FactoryHasResource(Resource resourceToCheck, out FactoryResource factoryResource)
    {
        factoryResource = null;
        foreach (FactoryResource existingFactoryResource in FactoryResources)
        {
            if (existingFactoryResource.Resource.Equals(resourceToCheck))
            {
                factoryResource = existingFactoryResource;
                return true;
            }
        }
        return false;
    }

    private FactoryResource GetFactoryResourceFromResource(Resource resource, bool initializeIfNull = false)
    {
        foreach (var existingFactoryResource in FactoryResources)
        {
            if (existingFactoryResource.Resource.Equals(resource))
                return existingFactoryResource;
        }

        if (initializeIfNull)
            return InitializeFactoryResource(resource);

        return null;
    }
}

