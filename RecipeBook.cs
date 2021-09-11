using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : DataBase
{
    public List<Recipe> _recipeBook { get; private set; }

    public RecipeBook()
    {
        _recipeBook = new List<Recipe>();

        AddRecipe(RecipeName.IronOre, IndustryName.Drill, 1, Gr(Pat(RecipeName.IronOre, 1)), null);
        AddRecipe(RecipeName.CopperOre, IndustryName.Drill, 1, Gr(Pat(RecipeName.CopperOre, 1)), null);
        AddRecipe(RecipeName.Coal, IndustryName.Drill, 1, Gr(Pat(RecipeName.Coal, 1)), null);
        AddRecipe(RecipeName.Water, IndustryName.OffshorePump, 1, Gr(Pat(RecipeName.Water, 1)), null);
        AddRecipe(RecipeName.CrudeOil, IndustryName.PumpJack, 1, Gr(Pat(RecipeName.CrudeOil, 1)), null);

        AddRecipe(RecipeName.IronPlate, IndustryName.ElectricFurnance, 3.2f, Gr(Pat(RecipeName.IronPlate, 1)), Gr(Pat(RecipeName.IronOre, 1)));
        AddRecipe(RecipeName.CopperPlate, IndustryName.ElectricFurnance, 3.2f, Gr(Pat(RecipeName.CopperPlate, 1)), Gr(Pat(RecipeName.CopperOre, 1)));
        AddRecipe(RecipeName.Steal, IndustryName.ElectricFurnance, 16, Gr(Pat(RecipeName.Steal, 1)), Gr(Pat(RecipeName.IronPlate, 5)));

        AddRecipe(RecipeName.IronGear, IndustryName.Assembler, 0.5f, Gr(Pat(RecipeName.IronGear, 1)), Gr(Pat(RecipeName.IronPlate, 2)));
        AddRecipe(RecipeName.IronPipe, IndustryName.Assembler, 0.5f, Gr(Pat(RecipeName.IronPipe, 1)), Gr(Pat(RecipeName.IronPlate, 1)));
        AddRecipe(RecipeName.CopperCable, IndustryName.Assembler, 0.5f, Gr(Pat(RecipeName.CopperCable, 2)), Gr(Pat(RecipeName.CopperPlate, 1)));
        AddRecipe(RecipeName.PlasticBar, IndustryName.ChemicalPlant, 1, Gr(Pat(RecipeName.PlasticBar, 1)), Gr(Pat(RecipeName.Coal, 2), Pat(RecipeName.PetroliumGas, 20)));
        AddRecipe(RecipeName.ElectronicCircuit, IndustryName.ChemicalPlant, 0.5f, Gr(Pat(RecipeName.ElectronicCircuit, 1)), Gr(Pat(RecipeName.IronPlate, 1), Pat(RecipeName.CopperCable, 3)));
        AddRecipe(RecipeName.Sulfur, IndustryName.ChemicalPlant, 1, Gr(Pat(RecipeName.Sulfur, 1)), Gr(Pat(RecipeName.Water, 30), Pat(RecipeName.PetroliumGas, 30)));
        AddRecipe(RecipeName.Battery, IndustryName.ChemicalPlant, 4, Gr(Pat(RecipeName.Battery, 1)), Gr(Pat(RecipeName.IronPlate, 1), Pat(RecipeName.CopperPlate, 1), Pat(RecipeName.SulfuricAcid, 20)));
        AddRecipe(RecipeName.Explosives, IndustryName.ChemicalPlant, 4, Gr(Pat(RecipeName.Explosives, 2)), Gr(Pat(RecipeName.Sulfur, 1), Pat(RecipeName.Coal, 1), Pat(RecipeName.Water, 10)));

        AddRecipe(RecipeName.SolidFuel, IndustryName.ChemicalPlant, 2, Gr(Pat(RecipeName.SolidFuel, 1)), Gr(Pat(RecipeName.LightOil, 10)));

        AddRecipe(RecipeName.Lubricant, IndustryName.ChemicalPlant, 1, Gr(Pat(RecipeName.Lubricant, 10)), Gr(Pat(RecipeName.HeavyOil, 10)));
        AddRecipe(RecipeName.SulfuricAcid, IndustryName.ChemicalPlant, 1, Gr(Pat(RecipeName.SulfuricAcid, 50)), Gr(Pat(RecipeName.IronPlate, 1), Pat(RecipeName.Sulfur, 5), Pat(RecipeName.Water, 100)));
        AddRecipe(RecipeName.HeavyOil, IndustryName.Null, 1, Gr(Pat(RecipeName.HeavyOil, 1)), null);
        AddRecipe(RecipeName.LightOil, IndustryName.Null, 1, Gr(Pat(RecipeName.LightOil, 1)), null);
        AddRecipe(RecipeName.PetroliumGas, IndustryName.Null, 1, Gr(Pat(RecipeName.PetroliumGas, 1)), null);
        AddRecipe(RecipeName.Steam, IndustryName.Null, 1, Gr(Pat(RecipeName.Steam, 1)), null);
        AddRecipe(RecipeName.CrackingHeavyToLight, IndustryName.ChemicalPlant, 2, Gr(Pat(RecipeName.LightOil, 30)), Gr(Pat(RecipeName.HeavyOil, 40), Pat(RecipeName.Water, 30)));
        AddRecipe(RecipeName.CrackingLightToGas, IndustryName.ChemicalPlant, 2, Gr(Pat(RecipeName.PetroliumGas, 20)), Gr(Pat(RecipeName.LightOil, 30), Pat(RecipeName.Water, 30)));
        AddRecipe(RecipeName.BaseOilProcesing, IndustryName.OilRefinery, 10, Gr(Pat(RecipeName.PetroliumGas, 45)), Gr(Pat(RecipeName.CrudeOil, 100)));
        AddRecipe(RecipeName.AdvansedOilProcesing, IndustryName.OilRefinery, 10, Gr(Pat(RecipeName.HeavyOil, 25), Pat(RecipeName.LightOil, 45), Pat(RecipeName.PetroliumGas, 55)), Gr(Pat(RecipeName.Water, 50), Pat(RecipeName.CrudeOil, 100)));
        AddRecipe(RecipeName.CoalLiquefaction, IndustryName.OilRefinery, 10, Gr(Pat(RecipeName.HeavyOil, 90), Pat(RecipeName.LightOil, 20), Pat(RecipeName.PetroliumGas, 10)), Gr(Pat(RecipeName.Coal, 10), Pat(RecipeName.HeavyOil, 25), Pat(RecipeName.Steam, 50)));

        AddRecipe(RecipeName.Engine, IndustryName.Assembler, 10, Gr(Pat(RecipeName.Engine, 1)), Gr(Pat(RecipeName.IronPipe, 2), Pat(RecipeName.Steal, 1), Pat(RecipeName.IronGear, 1)));
        AddRecipe(RecipeName.ElecticEngine, IndustryName.Assembler, 10, Gr(Pat(RecipeName.ElecticEngine, 1)), Gr(Pat(RecipeName.Engine, 1), Pat(RecipeName.ElectronicCircuit, 2), Pat(RecipeName.Lubricant, 15)));
    }

    private ProductPattern Pat(in RecipeName name, in int amount)
    {
        return new ProductPattern(name, amount);
    }

    private ProductPattern[] Gr(in ProductPattern patern)
    {
        ProductPattern[] cookie = new ProductPattern[1];
        cookie[0] = patern;
        return cookie;
    }

    private ProductPattern[] Gr(in ProductPattern patern1, in ProductPattern patern2)
    {
        ProductPattern[] cookie = new ProductPattern[2];
        cookie[0] = patern1;
        cookie[1] = patern2;
        return cookie;
    }

    private ProductPattern[] Gr(in ProductPattern patern1, in ProductPattern patern2, in ProductPattern patern3)
    {
        ProductPattern[] cookie = new ProductPattern[3];
        cookie[0] = patern1;
        cookie[1] = patern2;
        cookie[2] = patern3;
        return cookie;
    }

    private void AddRecipe(in RecipeName name, in IndustryName type, in float cycleTime, in ProductPattern[] products, in ProductPattern[] costs)
    {
        _recipeBook.Add(new Recipe(name, type, cycleTime, products, costs));
    }

    public bool GetRecipe(in RecipeName target, out Recipe recipe)
    {
        if (target != RecipeName.Null)
        {
            for (int i = 0; i < _recipeBook.Count; i++)
            {
                if (_recipeBook[i].Name == target && i < _recipeBook.Count)
                {
                    recipe = _recipeBook[i];

                    return true;
                }
            }
        }

        recipe = new Recipe(RecipeName.Null, IndustryName.Null, 0, new ProductPattern[0], new ProductPattern[0]);

        return false;
    }
}

public class Recipe : RecipePattern
{
    public List<ProductPattern> _productList { get; private set; }
    public List<ProductPattern> _costList { get; private set; }
    public override RecipeName Name { get; private protected set; }
    public override IndustryName IndustryType { get; private protected set; }
    public override float CycleTime { get; private protected set; }

    public Recipe(in RecipeName name, in IndustryName type, in float cycleTime, in ProductPattern[] products, in ProductPattern[] costs)
    {
        _productList = new List<ProductPattern>();
        _costList = new List<ProductPattern>();

        Name = name;
        IndustryType = type;
        CycleTime = cycleTime;

        for (int i = 0; i < products.Length; i++)
        {
            _productList.Add(new ProductPattern(products[i].name, products[i].amount));
        }

        if (costs != null)
        {
            for (int i = 0; i < costs.Length; i++)
            {
                _costList.Add(new ProductPattern(costs[i].name, costs[i].amount));
            }
        }
    }
}