using UnityEngine;
using UnityEngine.UI;

public class DiferentsTrigersPlayer : MonoBehaviour
{
    [SerializeField] private Text _coinsText;
    [SerializeField] private Canvas _canvasGames;
    [SerializeField] private Canvas _finishCanvas;
    [SerializeField] private Text _xpText;
    [SerializeField] private int _xp = 0;
    [SerializeField] private int _kills = 0;
    [SerializeField] private Text _killsText;
    [SerializeField] private Text _finishCoin;

    private int _currentCoins = 0;
    
    private void Awake()
    {
        _coinsText.text = _currentCoins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
            ColectCoin(collision.gameObject);
    }
    private void ColectCoin(GameObject gameO)
    {
        _currentCoins += 1;
        _coinsText.text = _currentCoins.ToString() ;
        XPCounter();
        Destroy(gameO);
    }
    public void CollectKills()
    {
        _kills += 1;
    }
    private void XPCounter()
    {
        _xp = _currentCoins * 2 +_kills * 3;
    }
    
    public void FinishController()
    {
        XPCounter();    
        _canvasGames.gameObject.SetActive(false);
        _finishCanvas.gameObject.SetActive(true);
        _xpText.text = _xp.ToString();
        _finishCoin.text = _currentCoins.ToString();
        _killsText.text = _kills.ToString();
        Time.timeScale = 0;
    }
 
}
