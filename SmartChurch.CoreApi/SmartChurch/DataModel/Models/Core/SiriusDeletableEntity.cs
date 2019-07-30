namespace SmartChurch.DataModel.Models.Core
{
    public abstract class SiriusDeletableEntity : SiriusEntity
    {
        public bool IsDeleted { get; set; }
    }
}