using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustryBook : DataBase
{
    private List<IndustryType> _industries;
    public IndustryBook()
    {
        _industries = new List<IndustryType>();

        AddType(IndustryName.Drill, 5, 55, 0.5f);
        AddType(IndustryName.ElectricFurnance, 20, 7.75f, 1.02f);
        AddType(IndustryName.Assembler, 5, 2, 0.45f);
        AddType(IndustryName.OffshorePump, 3900, 0, 0);
        AddType(IndustryName.PumpJack, 5.5f, 55, 0.5f);
        AddType(IndustryName.OilRefinery, 10, 33, 2.29f);
        AddType(IndustryName.ChemicalPlant, 10, 22, 1.15f);
    }

    private void AddType(in IndustryName type, in float rate, in float polution, in float energy)
    {
        _industries.Add(new IndustryType(type, rate, polution, energy));
    }

    public bool TryGetType(in IndustryName name, out IndustryType type)
    {
        for (int i = 0; i < _industries.Count; i++)
        {
            if (_industries[i].Type == name)
            {
                type = _industries[i];

                return true;
            }
        }

        type = new IndustryType(IndustryName.Null, 0, 0, 0);

        return false;
    }
}

public class IndustryType : IndustryTypePattern
{
    public override IndustryName Type { get; private protected set; }
    public override float ProductionRate { get; private protected set; }
    public override float Polution { get; private protected set; }
    public override float EnergyConsumption { get; private protected set; }

    public IndustryType(in IndustryName type, in float rate, in float polution, in float energy)
    {
        Type = type;
        ProductionRate = rate;
        Polution = polution;
        EnergyConsumption = energy;
    }
}