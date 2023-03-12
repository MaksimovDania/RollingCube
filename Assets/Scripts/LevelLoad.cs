#nullable enable

using Logic;
using UnityEngine;

public class LevelLoad : MonoBehaviour
{
    public string? Level;
    private Board? board;

    private void Start()
    {
        var tmj = TmjLevel.Load(Level!);
        var ground = System.Array.Find(tmj.layers, it => it.name == "ground");
        var objects = System.Array.Find(tmj.layers, it => it.name == "objects");
        board = new Board(tmj.width, 2, tmj.height, new Tile[tmj.width * tmj.height * 2]);
        uint layer = tmj.width * tmj.height;

        for (uint i = 0; i < layer; i++)
        {
            var p = board.Position(i);
            board[p] = CreateTile(ground.data[i], p);
        }

        for (uint i = layer; i < layer * 2; i++)
        {
            var p = board.Position(i);
            board[p] = CreateTile(objects.data[i - layer], p);
        }

        var position = (Position)(board!.FindPosition(it => it is StartTile))!;
        position.Y += 1;
        board[position] = Make("dice0", position);

        var cameraPosition = position.ToVector3() * 2.0f;
        cameraPosition.x -= 10.0f;
        cameraPosition.y += 10.0f;
        gameObject.transform.Translate(cameraPosition);
        gameObject.transform.Rotate(Vector3.up, 90.0f);
        gameObject.transform.Rotate(Vector3.right, 45.0f);
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        var delta = new Vector3(v, 0, -h);
        delta *= 10 * Time.deltaTime;

        gameObject.transform.position += delta;
    }

    private Tile CreateTile(byte number, Position position)
    {
        switch (number)
        {
            case 0: return new EmptyTile();
            case 1: return Make("stone0", position);
            case 2: returnя Make("stone1", position);
            case 3: return Make("stone2", position);
            case 4: return Make("stone3", position);
            case 5: return Make("finish0", position);
            case 6: return Make("torch0", position);
            case 7: return Make("tree0", position);
            case 8: return Make("tree1", position);
            case 9: return Make("tree2", position);
            case 10: return Make("dice1", position);
            case 11: return Make("dice2", position);
            case 12: return Make("gate0", position);
            case 13:
            case 14:
            case 15:
            case 16:
                throw new System.NotSupportedException();
            case 17: return Make("speed0", position);
            case 18: return Make("slow0", position);
            case 19: return Make("swap0", position);
            case 20: return Make("star0", position);
            case 21: return Make("lock0", position);
            case 22: return Make("unlock0", position);
            case 23: return Make("coin0", position);
            case 24: return Make("zero0", position);
            case 25: return Make("nine0", position);
            case 26: return Make("stronger0", position);
            case 27: return Make("weaker0", position);
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
                throw new System.NotSupportedException();
            case 33: return Make("lilypad0", position);
            case 34: return Make("lilypad1", position);
            case 35: return Make("reeds0", position);
            case 36: return Make("reeds1", position);
            case 37: return Make("reeds2", position);
            case 38: return Make("canes0", position);
            case 39: return Make("canes1", position);
            case 40: return Make("canes2", position);
            case 41:
            case 42:
            case 43:
            case 44:
            case 45:
            case 46:
            case 47:
            case 48:
                throw new System.NotSupportedException();
            case 49: return Make("tile0", position);
            case 50: return Make("start0", position);
            case 51: return Make("log0", position);
            case 52: return Make("tile1", position);
            case 53:
            case 54:
            case 55:
            case 56:
            case 57:
            case 58:
            case 59:
            case 60:
            case 61:
            case 62:
            case 63:
            case 64:
                throw new System.NotSupportedException();
            default:
                throw new System.Exception();
        }
    }

    private Tile Make(string name, Position position)
    {
        var instance = Instantiate(Resources.Load<GameObject>($"Prefabs/{name}"));
        var tile = (instance.GetComponent<MonoBehaviour>() as Tile)!;
        var vector = position.ToVector3() * 2.0f;

        if (tile is ElementTile)
            vector.y = 0.0f;
        else if (tile is DiceTile)
            vector.y = 1.175f;
        else
            vector.y = 0.175f * position.Y;

        instance.transform.SetPositionAndRotation(vector, instance.transform.rotation);
        return tile;
    }
}
