namespace JC_BlueTec.Domain.Entidades
{
    public abstract class Base
    {
        public long Id { get; set; }

        internal List<string> _errors;
        public IReadOnlyCollection<string> Errors
        {
            get
            {
                return _errors;
            }
        }

        public abstract bool Validate();
    }
}
