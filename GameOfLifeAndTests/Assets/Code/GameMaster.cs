using UnityEngine;
using UnityEngine.UI;

namespace GameOfLifeAndTests
{
    public class GameMaster : UpdatableObject
    {
        /*public delegate void OnEssentialBonusesAmountChange();
        public event OnEssentialBonusesAmountChange EssentialBonusesAmountChange;

        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private GameObject _VictoryScreen;
        [SerializeField] private Text _displayBonusText;
        public float essentialBonusesAmount;
        private void Awake()
        {
            essentialBonusesAmount = FindObjectsOfType<EssentialBonus>().Length;
            _displayBonusText.text = essentialBonusesAmount.ToString();
        }
        public void DisplayGameOverScreen(object value)
        {
            _gameOverScreen.SetActive(true);
        }
        public void DisplayVictoryScreen(object value)
        {
            _VictoryScreen.SetActive(true);
        }
        public void SetBonusesLeft(object value)
        {
            //_essentialBonusesAmount = FindObjectsOfType<EssentialBonus>().Length;
            essentialBonusesAmount--;
            EssentialBonusesAmountChange?.Invoke();
            _displayBonusText.text = essentialBonusesAmount.ToString();
            Debug.Log("BonusCollected! New amount is: " + essentialBonusesAmount);
        }*/
        public override void CustomUpdate()
        {
            
        }
    }
}