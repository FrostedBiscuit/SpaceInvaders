using System.Collections.Generic;
using UnityEngine;

public interface IMovementHandler<TEntity> where TEntity : MonoBehaviour
{
    void HandleMovement(ICollection<TEntity> entityCollection);
}