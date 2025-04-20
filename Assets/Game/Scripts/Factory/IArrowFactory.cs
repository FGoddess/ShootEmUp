using UnityEngine;
using Views;

namespace Factory
{
public interface IArrowFactory
{
    void CreateArrow(GameEntity attacker, GameEntity target);
}
} 