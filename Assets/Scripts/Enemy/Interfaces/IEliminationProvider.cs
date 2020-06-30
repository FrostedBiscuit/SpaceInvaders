using System.Collections;

public interface IEliminationProvider<TEntityCollection> where TEntityCollection : ICollection
{
    void Eliminate(TEntityCollection entityCollection);
}