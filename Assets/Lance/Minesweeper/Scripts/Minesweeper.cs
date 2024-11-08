using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minesweeper : MiniGameLevel {
    [SerializeField] private Transform tilePrefab;
    [SerializeField] private Transform gameHolder;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI winnerText;

    private List<Tile> tiles = new();
    private ScoreManager scoreManager;

    private float timeRemaining;
    private int width;
    private int height;
    private int numMines;
    private bool playerWon = false;
    private int TIME_LIMIT = 120;

    private readonly float tileSize = 0.5f;

    // Start is called before the first frame update
    void Start() {
        timeLimit = TIME_LIMIT;
        timeRemaining = timeLimit;
        if (MainPlayer.IsBCMode()) {
            CreateGameBoard(9,9,0); // no mines
        } else {
            CreateGameBoard(9, 9, 10);
        }
        // scoreManager = new MinesweeperScoreManager(width*height, numMines);
        scoreManager = ScoreManagerFactory.CreateScoreManager("Minesweeper", width*height, numMines);
        ResetGameState();
    }

    void Update() {
        if (!isGameOver) {
            timeRemaining -= Time.deltaTime;
            UpdateTimer();
        }
    }

    // update time and check if time has run out for game
    public void UpdateTimer() {
        timerText.text = Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0f) {
            Debug.Log("Player ran out of time");
            playerWon = false;
            EndGame();
        }
    }

    public void AddPlayerScore() {
        scoreManager.AddPlayerScore();
    }

    public void CreateGameBoard(int width, int height, int numMines) {
        if (tilePrefab == null || gameHolder == null)
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
        this.width = width;
        this.height = height;
        this.numMines = numMines;

        // Create the array of tiles.
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                // Position the tile in the correct place (centered).
                Transform tileTransform = Instantiate(tilePrefab);
                tileTransform.parent = gameHolder;
                float xIndex = col - ((width - 1) / 2.0f);
                float yIndex = row - ((height - 1) / 2.0f);
                tileTransform.localPosition = new Vector2(xIndex * tileSize, yIndex * tileSize);
                // Keep a reference to the tile for setting up the game.
                Tile tile = tileTransform.GetComponent<Tile>();
                tiles.Add(tile);
                tile.gameManager = this;
            }
        }
    }

    // Helper function to clear existing tiles from the board
    private void ClearExistingBoard()
    {
        // Destroy all tile GameObjects in the list
        foreach (Tile tile in tiles)
        {
            if (tile != null)
            {
                Destroy(tile.gameObject);
            }
        }

        // Clear the tiles list
        tiles.Clear();
    }

    public void ResetGameState() {
        // Randomly shuffle the tile positions to get indices for mine positions.
        int[] minePositions = Enumerable.Range(0, tiles.Count).OrderBy(x => Random.Range(0.0f, 1.0f)).ToArray();

        // Set mines at the first numMines positions.
        for (int i = 0; i < numMines; i++) {
            int pos = minePositions[i];
            tiles[pos].isMine = true;
        }

        // Update all the tiles to hold the correct number of mines.
        for (int i = 0; i < tiles.Count; i++) {
            tiles[i].mineCount = HowManyMines(i);
        }
    }

    // count the total number of mines on the board
    public int TotalMinesOnBoard() {
        int count = 0;

        foreach (Tile tile in tiles) {
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
            if (tiles[pos].isMine) {
                count++;
            }
        }
        return count;
    }

    // Given a position, return the positions of all neighbors.
    public List<int> GetNeighbors(int pos) {
        List<int> neighbors = new();
        int row = pos / width;
        int col = pos % width;
        // (0,0) is bottom left.
        if (row < (height - 1)) {
            neighbors.Add(pos + width); // North
            if (col > 0) {
                neighbors.Add(pos + width - 1); // North-West
            }
            if (col < (width - 1)) {
                neighbors.Add(pos + width + 1); // North-East
            }
        }
        if (col > 0) {
            neighbors.Add(pos - 1); // West
        }
        if (col < (width - 1)) {
            neighbors.Add(pos + 1); // East
        }
        if (row > 0) {
            neighbors.Add(pos - width); // South
            if (col > 0) {
                neighbors.Add(pos - width - 1); // South-West
            }
            if (col < (width - 1)) {
            neighbors.Add(pos - width + 1); // South-East
            }
        }
        return neighbors;
    }

    public void ClickNeighbors(Tile tile) {
        int location = tiles.IndexOf(tile);
        foreach (int pos in GetNeighbors(location)) {
            tiles[pos].ClickedTile();
        }
    }

    public override void EndGame() {
        // Disable clicks on all mines.
        foreach (Tile tile in tiles) {
            tile.ShowGameOverState();
        }

        isGameOver = true;

        if (playerWon || MainPlayer.IsBCMode()) {
            Debug.Log("EndGame::Player Won!");
            winnerText.text = "You Won!";
            MainPlayer.SetMiniGameStatus(1);
            SetFlagOnAllMines();
        } else {
            winnerText.text = "You Lost!";
            MainPlayer.SetMiniGameStatus(0);
            Debug.Log("EndGame::Player Lost");
        }

        timerScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    private int CountActiveTiles() {
        int count = 0;
        foreach (Tile tile in tiles) {
            if (tile.active) {
                count++;
            }
        }
        return count;
    }

    // set a flag on every mine
    private void SetFlagOnAllMines() {
        foreach (Tile tile in tiles) {
            tile.active = false;
            tile.SetFlaggedIfMine();
        }
    }
    
    public void CheckGameOver() {
        // If there are numMines left active then we're done.
        int count = scoreManager.CheckWinCondition();

        if (count == ScoreManager.PLAYER_WON) {
            // Flag and disable everything, we're done.
            isGameOver = true;
            playerWon = true;
            // winnerText.text = "You Won!";
            Debug.Log("Player Won Minesweeper!");
            SetFlagOnAllMines();
            EndGame();
        } else if (count == MinesweeperScoreManager.PLAYER_HIT_MINE) {
            isGameOver = true;
            playerWon = false;
            // winnerText.text = "You Lost!";
            Debug.Log("Player Lost Minesweeper!");
            EndGame();
        }
    }

    public void SetPlayerHitMine() {
        scoreManager.SetPlayerHitMine();
    }

    // Click on all surrounding tiles if mines are all flagged.
    public void ExpandIfFlagged(Tile tile) {
        int location = tiles.IndexOf(tile);
        // Get the number of flags.
        int flag_count = 0;
        foreach (int pos in GetNeighbors(location)) {
            if (tiles[pos].flagged) {
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
        tilePrefab = prefab;
    }

    public void SetGameHolder(Transform temp) {
        gameHolder = temp;
    }

    public int GetTileCount() {
        return tiles.Count;
    }

    public bool IsGameOverShowing() {
        return gameOverScreen.activeSelf;
    }

    public void SetTimerText(TextMeshProUGUI text)
    {
        timerText = text;
    }

    public void SetTimerScreen(GameObject screen)
    {
        timerScreen = screen;
    }

    public void SetGameOverScreen(GameObject screen)
    {
        gameOverScreen = screen;
    }

    public void SetWinnerText(TextMeshProUGUI text)
    {
        winnerText = text;
    }

    // For unit testing
    public float GetTimeRemaining() => timeRemaining;
    public void SetTimeRemaining(float time) => timeRemaining = time;
    public int GetTilesCount() => tiles.Count;
    public string GetTimeText() => timerText.text;

}
