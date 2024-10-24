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
    private MinesweeperScoreManager scoreManager;

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
        CreateGameBoard(9, 9, 10); // Easy
        scoreManager = new MinesweeperScoreManager(width*height, numMines);
        ResetGameState();
    }

    void Update() {
        if (!isGameOver) {
            timeRemaining -= Time.deltaTime;
            UpdateTimer();
        }
    }

    // update time and check if time has run out for game
    private void UpdateTimer() {
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
        // Save the game parameters we're using.
        this.width = width;
        this.height = height;
        this.numMines = numMines;

        // Create the array of tiles.
        for (int row = 0; row < height; row++) {
            for (int col = 0; col < width; col++) {
                // Position the tile in the correct place (centred).
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

    private void ResetGameState() {
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
    private List<int> GetNeighbors(int pos) {
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

        if (playerWon) {
            Debug.Log("EndGame::Player Won!");
        } else {
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
            winnerText.text = "You Won!";
            Debug.Log("Player Won Minesweeper!");
            SetFlagOnAllMines();
            EndGame();
        } else if (count == MinesweeperScoreManager.PLAYER_HIT_MINE) {
            isGameOver = true;
            playerWon = false;
            winnerText.text = "You Lost!";
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
}