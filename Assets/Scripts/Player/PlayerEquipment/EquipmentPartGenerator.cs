using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class EquipmentPartGenerator : MonoBehaviour
{

    private static List<Type> EquipmentTypes = new List<Type>()
    {
        typeof(BuffingEquipmentPart),
        typeof(MeleeEquipmentPart),
        typeof(DoubleJumpEquipmentPart)
    };


    public EquipmentPart generate()
    {
        EquipmentPart part;

        int maxRandValue = EquipmentPartGenerator.EquipmentTypes.Count();

        int typeIdx = UnityEngine.Random.Range(0, maxRandValue);

        Type partType = EquipmentTypes[typeIdx];

        var ctors = partType.GetConstructors();
        var obj = ctors[0].Invoke(null);
        part = (EquipmentPart) obj;

        //part location

        if(part is DoubleJumpEquipmentPart) {
            part.partLocation = PART_LOCATION.LEGS;
        } else
        {
            int numberOfPartLocations = Enum.GetNames(typeof(PART_LOCATION)).Length;
            int partLocationIdx = UnityEngine.Random.Range(0, numberOfPartLocations);

            part.partLocation = (PART_LOCATION) partLocationIdx;
        }



            //stat alterations
            part.addStatAlteration

        

        
        return part;

    }
}
