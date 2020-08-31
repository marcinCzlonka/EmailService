namespace EmailService.Common.Interfaces
{
    public interface IMapper<TInput, TOutput> where TOutput : new()
    {
        void Map(TInput obj, TOutput output);

        TOutput Map(TInput obj)
        {
            if (obj == null) return default;

            TOutput output = new TOutput();
            Map(obj, output);
            return output;
        }
    }

}
