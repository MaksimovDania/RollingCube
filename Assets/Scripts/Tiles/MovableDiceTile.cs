#nullable enable

using Logic;
using UnityEngine;

public class MovableDiceTile : MonoBehaviour, Tile
{
    public Rule Rule { get { return new Rule.Dummy(); } }
    public void TimePassed(double delta) { }
}
