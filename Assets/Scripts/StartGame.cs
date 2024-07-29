using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public const int Size = 10;
    public const int RadiusAttack = 1;
    public const int PlayersCount = 2;
    public const int ChipsCount = 2;
    public static Material CanMoveMaterial;
    public static Material[] Materials;
    public static GameObject CellPrefab;
    public static Transform CellParent;
    public static GameObject CoinPrefab;
    public static Transform CoinParent;
    public static Text Money1;
    public static Text Money2;
    public static GameObject BuildingPanel1;
    public static GameObject BuildingPanel2;



    [SerializeField] private Text _money1;
    [SerializeField] private Text _money2;
    [SerializeField] private GameObject _buildingPanel1;
    [SerializeField] private GameObject _buildingPanel2;
    [SerializeField] private Material _canMoveMaterial;
    [SerializeField] private Material[] _materials;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Transform _cellParent;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinParent;
    [SerializeField] private GameObject _winMenu;
    void Awake()
    {
        CanMoveMaterial = _canMoveMaterial;
        Materials = _materials;
        CellPrefab = _cellPrefab;
        CellParent = _cellParent;
        CoinPrefab = _coinPrefab;
        CoinParent = _coinParent;
        Money1 = _money1;
        Money2 = _money2;
        BuildingPanel1 = _buildingPanel1;
        BuildingPanel2 = _buildingPanel2;

        MapObject.MakeMapObject();
        MapCoins.MakeMapCoins();
        Field.FieldAndCoinsSpawn();
        Win.SetWinScreen(_winMenu);

        PlayersContainer.MakePlayers();
        PlayersContainer.Players[0].SetCoordChip(0, new Point(0, 0));
        PlayersContainer.Players[0].SetCoordChip(1, new Point(Size - 1, Size - 1));
        PlayersContainer.Players[1].SetCoordChip(0, new Point(0, Size - 1));
        PlayersContainer.Players[1].SetCoordChip(1, new Point(Size - 1, 0));
    }

}
