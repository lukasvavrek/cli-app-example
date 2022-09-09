namespace ConsoleApp.Game;

public class Game
{
    private readonly IDirectionSelector _directionSelector;
    
    private readonly Point _coordinates;
    private Point _playerCoordinates;

    private double _distanceFromFinish;
    private GameState _state = GameState.Init;
    
    public Game(IDirectionSelector directionSelector)
    {
        _directionSelector = directionSelector;
        
        // example values
        _coordinates = new Point(2, 3);
        _playerCoordinates = new Point(0, 0);
        
        _distanceFromFinish = _playerCoordinates.DistanceFrom(_coordinates);
    }
    
    public GameState Loop()
    {
        MovePlayer();

        CalculateNewState();
        
        return _state;
    }

    private void MovePlayer()
    {
        var direction = _directionSelector.GetNextDirection();

        _playerCoordinates = _playerCoordinates.GoTo(direction);
    }

    private void CalculateNewState()
    {
        if (_playerCoordinates.SameAs(_coordinates))
        {
            _state = GameState.Won;
        }
        else
        {

            var newDistance = _playerCoordinates.DistanceFrom(_coordinates);

            _state = newDistance > _distanceFromFinish ? GameState.Colder : GameState.Warmer;

            _distanceFromFinish = newDistance;
        }
    }
}