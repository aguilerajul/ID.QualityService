namespace ID.QualityService.Domain
{
    public class EntityBase
    {
        public int Id { get; private set; }

        public EntityBase(int id)
        {
            this.Id = id;
        }

        public bool Equals(EntityBase entity)
        {
            if (ReferenceEquals(this, entity)) return true;
            if (ReferenceEquals(null, entity)) return false;

            return this.Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }
    }
}
