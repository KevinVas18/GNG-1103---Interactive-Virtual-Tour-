using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
	public void SceneChange(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
