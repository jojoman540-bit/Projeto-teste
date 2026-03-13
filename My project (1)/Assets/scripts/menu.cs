using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject painelOptions;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private TMP_Text textNome;
    
    public void OnVolumeChange()
    {
        Debug.Log(sliderVolume.value);
    }
  public void LoadGameScene()
    {
        SceneManager.LoadScene(0);

    }

    public void AbrirOptions()
    {
        painelMenuPrincipal.SetActive(false);
        painelOptions.SetActive(true);
    }

    public void voltar()
    {
        painelMenuPrincipal.SetActive(true);
        painelOptions.SetActive(false);
    }

    public void sair()
    {
        Application.Quit();
    }

    public void SetPlayerUsername(TMP_InputField input)
    {
        textNome.text = input.text;
    }
    
    


}



