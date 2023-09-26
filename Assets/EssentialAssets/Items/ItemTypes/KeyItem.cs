namespace Items
{
    public class KeyItem: Pickable
    {
        public bool IsPicked { get; private set; }
        protected override void PickingBehaviour()
        {
            IsPicked = true;
            base.PickingBehaviour();
        }
    }
}