using UnityEngine;

public interface IParentProvider<TParent> where TParent : MonoBehaviour
{
    TParent GetParent();
}
