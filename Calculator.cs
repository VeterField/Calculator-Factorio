using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private readonly RecipeBook _recipeBook = new RecipeBook();
    private readonly IndustryBook _industryBook = new IndustryBook();
    private Report _reportList = new Report();
    private readonly Math _math = new Math();
    private readonly OilRefineryMath _oilMath = new OilRefineryMath();

    private RecipeName _inputName = RecipeName.PlasticBar;
    private int _targetOutput = 200;

    private void Awake()
    {
        Calculate(_inputName, _targetOutput);

        _reportList.ShowReport();
    }

    private void Calculate(in RecipeName name, in float targetValue)
    {
        //SetNextStep(RecipeName.Lubricant, 1000);
        //SetNextStep(RecipeName.SolidFuel, 500);
        //SetNextStep(RecipeName.PlasticBar, 1200);

        CountOilFactory(RecipeName.AdvansedOilProcesing);
    }

    private void SetNextStep(in RecipeName name, in float targetValue)
    {
        if (_recipeBook.GetRecipe(name, out var recipe) == true)
        {
            TryAddAndFillReportLine(recipe, targetValue);

            TryMakeNextStepAndCountCost(recipe, targetValue);
        }
    }

    private void TryAddAndFillReportLine(in Recipe recipe, in float targetValue)
    {
        if (recipe._productList.Count > 0)
        {
            for (int i = 0; i < recipe._productList.Count; i++)
            {
                _reportList.TryAddLine(recipe._productList[i].name, recipe.IndustryType);

                _math.TryCountFactoryAmount(targetValue, recipe, out var factory);

                float belts = 0;
                if (recipe.IndustryType != IndustryName.Null)
                {
                    _math.CountBeltAmount(targetValue, out belts);
                }

                _math.TryCountTotalPolution(factory, recipe, out var polution);
                _math.TryCountTotalEnergyConsumption(factory, recipe, out var energy);

                _reportList.TryAddValues(recipe._productList[i].name, factory, targetValue, belts, polution, energy);
            }
        }
    }

    private void TryMakeNextStepAndCountCost(in Recipe recipe, in float targetValue)
    {
        if (recipe._costList.Count > 0)
        {
            _math.TryCountFactoryAmount(targetValue, recipe, out var factory);

            for (int i = 0; i < recipe._costList.Count; i++)
            {
                _math.TryCountFactoryOutput(factory, recipe, i, out var newTargetValue);

                SetNextStep(recipe._costList[i].name, newTargetValue);
            }
        }
    }

    private void CountOilFactory(in RecipeName OilProcesName)
    {
        _recipeBook.GetRecipe(OilProcesName, out var recipe);

        GetOilNeeds(out float[] _needs);

        _oilMath.CountOilRefinery(out var factory, out var outputs, _needs, recipe);

        Debug.Log(outputs[0]);
        Debug.Log(outputs[1]);
        Debug.Log(outputs[2]);
    }

    private void GetOilNeeds(out float[] needs)
    {
        needs = new float[3];

        needs[0] = _reportList.TryGetReportLine(RecipeName.HeavyOil).FactoryOutput;
        needs[1] = _reportList.TryGetReportLine(RecipeName.LightOil).FactoryOutput;
        needs[2] = _reportList.TryGetReportLine(RecipeName.PetroliumGas).FactoryOutput;
    }
}