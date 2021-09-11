using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataBase
{

}

public abstract class RecipePattern
{
    public abstract RecipeName Name { get; private protected set; }
    public abstract IndustryName IndustryType { get; private protected set; }
    public abstract float CycleTime { get; private protected set; }
}

public abstract class IndustryTypePattern
{
    public abstract IndustryName Type { get; private protected set; }
    public abstract float ProductionRate { get; private protected set; }
    public abstract float Polution { get; private protected set; }
    public abstract float EnergyConsumption { get; private protected set; }
}

public abstract class ReportLinePattern
{
    public abstract RecipeName Name { get; private protected set; }
    public abstract IndustryName IndustryType { get; private protected set; }
    public abstract float FactoryAmount { get; private protected set; }
    public abstract float FactoryOutput { get; private protected set; }
    public abstract float BeltAmount { get; private protected set; }
    public abstract float TotalPolution { get; private protected set; }
    public abstract float TotalEnergyConsamption { get; private protected set; }
}

public struct ProductPattern
{
    public RecipeName name { get; private set; }
    public int amount { get; private set; }

    public ProductPattern(in RecipeName name, in int amount)
    {
        this.name = name;
        this.amount = amount;
    }
}

public class Math
{
    private readonly RecipeBook _recipeBook = new RecipeBook();
    private readonly IndustryBook _industryBook = new IndustryBook();

    private const int _secondsInMinute = 60;

    public bool TryCountFactoryAmount(in float targetOutput, in Recipe targetRecipe, out float factory)
    {
        if (_industryBook.TryGetType(targetRecipe.IndustryType, out var type) == true)
        {
            factory = targetOutput / _secondsInMinute * targetRecipe.CycleTime / type.ProductionRate / targetRecipe._productList[0].amount;

            return true;
        }
        else
        {
            factory = 0;

            return false;
        }
    }

    public bool TryCountFactoryOutput(in float mainRecipeFactory, in Recipe mainRecipe, in int mainRecipeCostMemberIndex , out float targetOutput)
    {
        if (_industryBook.TryGetType(mainRecipe.IndustryType, out var type) == true)
        {
            targetOutput = mainRecipeFactory * _secondsInMinute / mainRecipe.CycleTime * type.ProductionRate * mainRecipe._costList[mainRecipeCostMemberIndex].amount;

            return true;
        }
        else
        {
            targetOutput = 0;

            return false;
        }
    }

    public void CountBeltAmount(in float targetOutput, out float belts)
    {
        float beltSpeedPerSecond = 150;

        belts = targetOutput / _secondsInMinute / beltSpeedPerSecond;
    }

    public bool TryCountTotalPolution(in float factory, in Recipe recipe, out float polution)
    {
        if (_industryBook.TryGetType(recipe.IndustryType, out var type) == true)
        {
            polution = factory * type.Polution;

            return true;
        }
        else
        {
            polution = 0;

            return false;
        }
    }

    public bool TryCountTotalEnergyConsumption(in float factory, in Recipe recipe, out float energy)
    {
        if (_industryBook.TryGetType(recipe.IndustryType, out var type) == true)
        {
            energy = factory * type.EnergyConsumption;

            return true;
        }
        else
        {
            energy = 0;

            return false;
        }
    }
}

public class OilRefineryMath
{
    private readonly RecipeBook _recipeBook = new RecipeBook();
    private readonly IndustryBook _industryBook = new IndustryBook();

    public void CountOilRefinery(out float oilRefinery, out float[] oilRefOutput, in float[] targetOutput, in Recipe oilRef)
    {
        _industryBook.TryGetType(oilRef.IndustryType, out var type);

        if (oilRef._productList.Count > 1)
        {
            oilRefinery = 0;
            oilRefOutput = new float[3];
            float cookie;

            for (int i = 0; i < oilRef._productList.Count; i++)
            {
                cookie = targetOutput[i] / 60 * oilRef.CycleTime / type.ProductionRate / oilRef._productList[i].amount;

                if (cookie > oilRefinery)
                {
                    oilRefinery = cookie;
                }
            }

            for (int i = 0; i < oilRef._productList.Count; i++)
            {
                oilRefOutput[i] = targetOutput[i] - oilRefinery * 60 / oilRef.CycleTime * type.ProductionRate * oilRef._productList[i].amount;
            }
        }
        else
        {
            oilRefinery = targetOutput[2] / 60 * oilRef.CycleTime / type.ProductionRate / oilRef._productList[0].amount;
            oilRefOutput = new float[1];
            oilRefOutput[0] = targetOutput[2];
        }
    }

    /*public void CountChemicalPlant(in Recipe oilRef, in float[] oilRefOutput, in float oilRefinery, out float refinery, out float lightPlant, out float gasPlant)
    {
        _recipeBook.GetRecipe(RecipeName.CrackingHeavyToLight, out var HLrecipe);
        _recipeBook.GetRecipe(RecipeName.CrackingLightToGas, out var LGrecipe);

        
    }*/
}

public enum RecipeName
{
    Null,
    IronOre, Coal, CopperOre, Water, CrudeOil,
    IronPlate, CopperPlate, Steal, IronGear, IronPipe, PlasticBar, Sulfur, Battery, Explosives, ElectronicCircuit, CopperCable,
    HeavyOil, LightOil, PetroliumGas, Steam, Lubricant, SulfuricAcid, SolidFuel,
    CrackingHeavyToLight, CrackingLightToGas, BaseOilProcesing, AdvansedOilProcesing, CoalLiquefaction,
    Engine, ElecticEngine
}

public enum IndustryName
{
    Null,
    Drill, ElectricFurnance,
    Assembler,
    OffshorePump, PumpJack, OilRefinery, ChemicalPlant
}

public enum OilIndustryProcesType
{

}