using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minesweeper : MiniGameLevel {
    [SerializeField] private Transform _tilePrefab;
    [SerializeField] private Transform _gameHolder;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _timerScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _winnerText;

    private List<Tile> _tiles = new();
    private ScoreManager _scoreManager;

    private float _timeRemaining;
    private int _width;
    private int _height;
    private int _numMines;
    private bool _playerWon = false;
    private const int _TIME_LIMIT = 120;

    private readonly float r_tileSize = 0.5f;

    // Start is called before the first frame update
    void Start() {
        p_timeLimit = _TIME_LIMIT;
        _timeRemaining = p_timeLimit;
        if (MainPlayer.IsBCMode()) {
            CreateGameBoard(9,9,0); // no mines
        } else {
            CreateGameBoard(9, 9, 10);
        }
        // scoreManager = new MinesweeperScoreManager(width*height, numMines);
        _scoreManager = ScoreManagerFactory.CreateScoreManager("Minesweeper", _width*_height, _numMines);
        ResetGameState();
    }

    void Update() {
        if (!p_isGameOver) {
            _timeRemaining -= Time.deltaTime;
            UpdateTimer();
        }
    }

    // update time and check if time has run out for game
    public void UpdateTimer() {
        _timerText.text = Mathf.Ceil(_timeRemaining).ToString();

        if (_timeRemaining <= 0f) {
            Debug.Log("Player ran out of time");
            _playerWon = false;
            VEndGame();
        }
    }

    public void AddPlayerScore() {
        _scoreManager.VAddPlayerScore();
    }

    public void CreateGameBoard(int width, int height, int numMines) {
        if (_tilePrefab == null || _gameHolder == null)
        {
            Debug.LogError("Tile prefab or game holder is not set.");
            return;
        }
        if (width < 1) width = 1;
        if (width > 10) width = 10;
        if (height < 1) height = 1;
        if (height > 10) height = 10;

        if (numMines > (width*height)) numMines = width*height;

        ClearExistingBoard();

        // Save the game parameters we're using.
        this._width = width;
        this._height = height;
        this._numMines = numMines;

        // Create the array of tiles.
        for (int row = 0; row < _height; row++) {
            for (int col = 0; col < _width; col++) {
                // Position the tile in the correct place (centered).
                Transform tileTransform = Instantiate(_tilePrefab);
                tileTransform.parent = _gameHolder;
                float xIndex = col - ((_width - 1) / 2.0f);
                float yIndex = row - ((_height - 1) / 2.0f);
                tileTransform.localPosition = new Vector2(xIndex * r_tileSize, yIndex * r_tileSize);
                // Keep a reference to the tile for setting up the game.
                Tile tile = tileTransform.GetComponent<Tile>();
                _tiles.Add(tile);
                tile.gameManager = this;
            }
        }
    }

    // Helper function to clear existing tiles from the board
    private void ClearExistingBoard()
    {
        // Destroy all tile GameObjects in the list
        foreach (Tile tile in _tiles)
        {
            if (tile != null)
            {
                Destroy(tile.gameObject);
            }
        }

        // Clear the tiles list
        _tiles.Clear();
    }

    public void ResetGameState() {
        // Randomly shuffle the tile positions to get indices for mine positions.
        int[] minePositions = Enumerable.Range(0, _tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

        // Set mines at the first numMines positions.
        for (int i = 0; i < _numMines; i++) {
            int pos = minePositions[i];
            _tiles[pos].isMine = true;
        }

        // Update all the tiles to hold the correct number of mines.
        for (int i = 0; i < _tiles.Count; i++) {
            _tiles[i].mineCount = HowManyMines(i);
        }
    }

    // count the total number of mines on the board
    public int TotalMinesOnBoard() {
        int count = 0;

        foreach (Tile tile in _tiles) {
            if (tile.isMine) {
                count++;
            }
        }

        return count;
    }

    // Given a location work out how many mines are surrounding it.
    private int HowManyMines(int location) {
        int count = 0;
        foreach (int pos in GetNeighbors(location)) {
            if (_tiles[pos].isMine) {
                count++;
            }
        }
        return count;
    }

    // Given a position, return the positions of all neighbors.
    public List<int> GetNeighbors(int pos) {
        List<int> neighbors = new();
        int row = pos / _width;
        int col = pos % _width;
        // (0,0) is bottom left.
        if (row < (_height - 1)) {
            neighbors.Add(pos + _width); // North
            if (col > 0) {
                neighbors.Add(pos + _width - 1); // North-West
            }
            if (col < (_width - 1)) {
                neighbors.Add(pos + _width + 1); // North-East
            }
        }
        if (col > 0) {
            neighbors.Add(pos - 1); // West
        }
        if (col < (_width - 1)) {
            neighbors.Add(pos + 1); // East
        }
        if (row > 0) {
            neighbors.Add(pos - _width); // South
            if (col > 0) {
                neighbors.Add(pos - _width - 1); // South-West
            }
            if (col < (_width - 1)) {
            neighbors.Add(pos - _width + 1); // South-East
            }
        }
        return neighbors;
    }

    public void ClickNeighbors(Tile tile) {
        int location = _tiles.IndexOf(tile);
        foreach (int pos in GetNeighbors(location)) {
            _tiles[pos].ClickedTile();
        }
    }

    public override void VEndGame() {
        // Disable clicks on all mines.
        foreach (Tile tile in _tiles) {
            tile.ShowGameOverState();
        }

        p_isGameOver = true;

        if (_playerWon || MainPlayer.IsBCMode()) {
            Debug.Log("EndGame::Player Won!");
            _winnerText.text = "You Won!";
            MainPlayer.SetMiniGameStatus(1);
            SetFlagOnAllMines();
        } else {
            _winnerText.text = "You Lost!";
            MainPlayer.SetMiniGameStatus(0);
            Debug.Log("EndGame::Player Lost");
        }

        _timerScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }

    private int CountActiveTiles() {
        int count = 0;
        foreach (Tile tile in _tiles) {
            if (tile.active) {
                count++;
            }
        }
        return count;
    }

    // set a flag on every mine
    private void SetFlagOnAllMines() {
        foreach (Tile tile in _tiles) {
            tile.active = false;
            tile.SetFlaggedIfMine();
        }
    }
    
    public void CheckGameOver() {
        // If there are numMines left active then we're done.
        int count = _scoreManager.VCheckWinCondition();

        if (count == ScoreManager.PLAYER_WON) {
            // Flag and disable everything, we're done.
            p_isGameOver = true;
            _playerWon = true;
            // _winnerText.text = "You Won!";
            Debug.Log("Player Won Minesweeper!");
            SetFlagOnAllMines();
            VEndGame();
        } else if (count == MinesweeperScoreManager.PLAYER_HIT_MINE) {
            p_isGameOver = true;
            _playerWon = false;
            // _winnerText.text = "You Lost!";
            Debug.Log("Player Lost Minesweeper!");
            VEndGame();
        }
    }

    public void SetPlayerHitMine() {
        _scoreManager.VSetPlayerHitMine();
    }

    // Click on all surrounding tiles if mines are all flagged.
    public void ExpandIfFlagged(Tile tile) {
        int location = _tiles.IndexOf(tile);
        // Get the number of flags.
        int flag_count = 0;
        foreach (int pos in GetNeighbors(location)) {
            if (_tiles[pos].flagged) {
                flag_count++;
            }
        }
    
        // If we have the right number click surrounding tiles.
        if (flag_count == tile.mineCount) {
            // Clicking a flag does nothing so this is safe.
            ClickNeighbors(tile);
        }
    }

    // setter methods for Minesweeper tests
    public void SetTilePrefab(Transform prefab) {
        _tilePrefab = prefab;
    }

    public void SetGameHolder(Transform temp) {
        _gameHolder = temp;
    }

    public int GetTileCount() {
        return _tiles.Count;
    }

    public bool IsGameOverShowing() {
        return _gameOverScreen.activeSelf;
    }

    public void SetTimerText(TextMeshProUGUI text)
    {
        _timerText = text;
    }

    public void SetTimerScreen(GameObject screen)
    {
        _timerScreen = screen;
    }

    public void SetGameOverScreen(GameObject screen)
    {
        _gameOverScreen = screen;
    }

    public void SetWinnerText(TextMeshProUGUI text)
    {
        _winnerText = text;
    }

    // For unit testing
    public float GetTimeRemaining() => _timeRemaining;
    public void SetTimeRemaining(float time) => _timeRemaining = time;
    public int GetTilesCount() => _tiles.Count;
    public string GetTimeText() => _timerText.text;

}
