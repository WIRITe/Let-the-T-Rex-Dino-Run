using UnityEngine;
using Thirdweb;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUiController : MonoBehaviour
{
    public static string address;

    public static ThirdwebSDK sdk;
    public TMP_Text walletInfotext;
    public TMP_Text Ballance;

    public GameObject UiLogin;
    public GameObject UiEnter;
    public GameObject BuyTryingsScreen;

    public int NextSceneIndex;



    void Start()
    {
        sdk = new ThirdwebSDK("goerli");


        if (address == null) { UiLogin.SetActive(true); UiEnter.SetActive(false); }

        else { UiLogin.SetActive(false); UiEnter.SetActive(true); }

        Balance();
    }

    public void MetamaskLogin()
    {
        ConnectWallet(WalletProvider.MetaMask);
    }

    public void WalletConnectLogin()
    {
        ConnectWallet(WalletProvider.WalletConnect);
    }

    private async void ConnectWallet(WalletProvider provider)
    {
        walletInfotext.text = "Connecting...";
        address = await sdk.wallet.Connect(new WalletConnection()
        {
            provider = provider,
            chainId = 5 // Switch the wallet Goerli on connection
        });
        walletInfotext.text = "Connected as: " + address;
        PlayerPrefs.SetString("address", address);

        UiLogin.SetActive(false);
        UiEnter.SetActive(true);
    }

    public async void Balance()
    {
        Ballance.text = "Loading...";
        CurrencyValue balance = await sdk.wallet.GetBalance();
        Ballance.text = "Balance: " + balance.displayValue.Substring(0, 3) + " " + balance.symbol;
    }

    public async void DisconnectWallet()
    {
        await sdk.wallet.Disconnect();
        UiLogin.SetActive(true);
        UiEnter.SetActive(false);
    }

    public void GoInGame()
    {
        if(PlayerPrefs.GetInt("Tryings") > 0)
        {
            SceneManager.LoadScene(NextSceneIndex);

            PlayerPrefs.SetInt("Tryings", PlayerPrefs.GetInt("Tryings") - 1);
        }
        else
        {
            BuyTryingsScreen.SetActive(true);
        }
    }

    public void OnRewardButton()
    {
        SceneManager.LoadScene(2);
    }
}
