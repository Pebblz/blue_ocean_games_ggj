using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class EquipmentPartGenerator 
{

    public static int MinStatChange = -5;
    public static int MaxStatChange = 20;

    private static List<Type> EquipmentTypes = new List<Type>()
    {
        typeof(BuffingEquipmentPart),
        typeof(MeleeEquipmentPart),
        typeof(DoubleJumpEquipmentPart),
        typeof(HoverBoots),
        typeof(FlamethrowerEquipmentPart)
    };


    public static EquipmentPart generate()
    {
        EquipmentPart part;

        int maxRandValue = EquipmentPartGenerator.EquipmentTypes.Count();

        int typeIdx = UnityEngine.Random.Range(0, maxRandValue);

        Type partType = EquipmentTypes[typeIdx];

        var ctors = partType.GetConstructors();
        var obj = ctors[0].Invoke(null);
        part = (EquipmentPart) obj;

        //randomize part if the class does not have a designated location.
        //By default it is the head, may need to refactor if we add stuff that needs to be on the head.
        if(part.partLocation == default){
            int numberOfPartLocations = Enum.GetNames(typeof(PART_LOCATION)).Length;
            int partLocationIdx = UnityEngine.Random.Range(0, numberOfPartLocations);

            part.partLocation = (PART_LOCATION) partLocationIdx;
        }



        int numberOfAlterations = UnityEngine.Random.Range(1, 4);

        for (int i = 0; i < numberOfAlterations; i++)
        {
            int numberOfStats = Enum.GetNames(typeof(PLAYER_STATS)).Length;

            PLAYER_STATS statToAlter = (PLAYER_STATS)UnityEngine.Random.Range(0, numberOfStats);
            int statAlterationAmount = UnityEngine.Random.Range(MinStatChange, MaxStatChange);
            part.addStatAlteration(statToAlter, statAlterationAmount);


        }
        
        return part;

    }
}
