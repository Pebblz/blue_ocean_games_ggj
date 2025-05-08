
public class BuffingEquipmentPart : EquipmentPart
{

    // This piece of equipment is meant to only improve stats and not implement any action
    public override void Action()
    {
        throw new System.NotImplementedException();
    }

}