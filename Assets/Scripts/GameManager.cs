using DG.Tweening;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
	{
		[SerializeField] private UIController uIController = new();
		[SerializeField] private GameController gameController = new();

		private void Awake()
		{
			uIController.Init(OnPlayButtonClicked, OnExitButtonClicked);
		}

		private void OnPlayButtonClicked(bool isPressed)
		{
			uIController.StartGame(isPressed);
			gameController.Init();
			var cardState = gameController.GetCardStates();
			uIController.UpdateGameOver(cardState);
		}

		private void OnExitButtonClicked(bool isPressed)
		{
			uIController.Exit(isPressed);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			DOTween.KillAll();
			CoroutineRunner.Instance.Clear();
		}
	}
}