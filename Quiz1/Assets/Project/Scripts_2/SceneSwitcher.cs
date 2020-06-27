using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour {


	public	void  GotoChoiceScene()
	{
		SceneManager.LoadScene ("Menu_Topics_Scene");
	}
	public void GotoProgTopic()
	{
		SceneManager.LoadScene ("Topic_Prog");
	}
	public void GotoTestChoiceScene()
	{
		SceneManager.LoadScene ("Scene_Test_Types");
	}
	public void GotoMenuScene()
	{
		SceneManager.LoadScene ("Menu_Scene");
	}
	public void Goto_Test_1()
	{
		SceneManager.LoadScene ("1st_Scene");
	}
	public void Goto_Test_2()
	{
		SceneManager.LoadScene ("2nd_Scene");
	}
	public void Goto_Test_3()
	{
		SceneManager.LoadScene ("3rd_InputWord_Scene");
	}
	public void Goto_KeysCopying()
	{
		SceneManager.LoadScene ("KeysCopying");
	}



}

