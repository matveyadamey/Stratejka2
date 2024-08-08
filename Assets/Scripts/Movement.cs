using System.Collections;
using UnityEngine;
public class Movement : MonoBehaviour {

    [SerializeField] private float _speed=10f;
    [SerializeField] private int playerNumber;
    [SerializeField] public int chipNumber;
    [SerializeField] private Raycaster raycaster;

    private IEnumerator realMove(Vector3 target)
    {

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
        yield return null;
    }
    public void Move(Point target)
    {
        Vector3 _target = new Vector3(target.x, 1, target.y);
        Player player = PlayersContainer.Players[playerNumber];

        if (player.CanMoveChip(chipNumber,target))
        {
            StartCoroutine(this.realMove(_target));

            Highlighter.HighlightOff(gameObject);
            Highlighter.HiglightPossiblePlacesToMove(chipNumber, false);

            player.MoveChip(chipNumber, target);

            CurrentPlayer.OperatingMode = "expectation";
            CurrentPlayer.MovementChip = null;
            CurrentPlayer.NextPlayer();

        }
    }

    void OnMouseDown()
    {
        if (CurrentPlayer.CurrentPlayerNumber == playerNumber)
        {
            if(CurrentPlayer.MovementChip != null)
            {
                Movement previousChip = CurrentPlayer.MovementChip;
                Highlighter.HighlightOff(previousChip.gameObject);
                Highlighter.HiglightPossiblePlacesToMove(previousChip.chipNumber,false);
            }

            CurrentPlayer.OperatingMode = "movement_chip";
            CurrentPlayer.MovementChip = this;
            Highlighter.HighlightOn(gameObject);
            Highlighter.HiglightPossiblePlacesToMove(chipNumber, true);
        }
    }
}
