using UnityEngine;
using Thirdweb;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartUiController : MonoBehaviour
{
    public static ThirdwebSDK sdk;
    public TMP_Text walletInfotext;
    public TMP_Text Ballance;

    public GameObject UiLogin;
    public GameObject UiEnter;

    void Start()
    {
        sdk = new ThirdwebSDK("goerli");
        

        UiLogin.SetActive(true);
        UiEnter.SetActive(false);
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
        string address = await sdk.wallet.Connect(new WalletConnection()
        {
            provider = provider,
            chainId = 5 // Switch the wallet Goerli on connection
        });
        walletInfotext.text = "Connected as: " + address;

        UiLogin.SetActive(false);
        UiEnter.SetActive(true);
        if (Ballance != null) Balance();
    }

    public async void Balance()
    {
        Ballance.text = "Loading...";
        CurrencyValue balance = await sdk.wallet.GetBalance();
        Ballance.text = "Balance: " + balance.displayValue.Substring(0, 3) + " " + balance.symbol;
    }
}
