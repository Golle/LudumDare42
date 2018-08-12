using Assets.Scripts.Items;

namespace Assets.Scripts.Character
{
    internal interface ICarrying
    {
        void Pickup(CarryableItem carryableItem);
        void DropAt(Dropzone dropzone);
    }
}