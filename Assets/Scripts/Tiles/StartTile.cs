#nullable enable

using Logic;
using UnityEngine;

public class StartTile : MonoBehaviour, Tile
{
    public Rule Rule { get { return new Rule.Dummy(); } }
    public void TimePassed(double delta) { }
}
