using System;
using UnityEngine;
using Proyecto26;
using Object = System.Object;

public class Nmkr : MonoBehaviour
{
    [SerializeField]
    string _nmkrUrl = "https://studio-api.nmkr.io/v2";
    [SerializeField]
    string _nmkrKey;

    public bool Busy { get; private set; }
    public Object Result { get; private set; }

    void SetHeaders()
    {
        RestClient.ClearDefaultHeaders();
        RestClient.DefaultRequestHeaders["Authorization"] = $"Bearer {_nmkrKey}";
    }

    
    /*
     * Customer
     */

    public void AddPayoutWallet(string walletaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/AddPayoutWallet/{walletaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<ApiResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPayoutWallets(Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPayoutWallets").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPayoutWalletsResultClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    
    /*
     * Address reservation (sale)
     */

    public void CancelAddressReservation(string projectuid, string paymentaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CancelAddressReservation/{projectuid}/{paymentaddress}").Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckAddress(string projectuid, string paymentaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckAddress/{projectuid}/{paymentaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<ApiResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckAddressWithCustomProperties(string projectuid, string customproperty, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckAddressWithCustomProperties/{projectuid}/{customproperty}").Then(response =>
        {
            Result = JsonUtility.FromJson<ApiResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddressForRandomNftSale(string projectuid, int countnft, int lovelace, string customeripaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPaymentAddressForRandomNftSale/{projectuid}/{countnft}/{lovelace}/{customeripaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddressForRandomNftSale(string projectuid, int countnft, string customeripaddress, Action callback = null)
    {
        Busy = true;
        SetHeaders();

        RestClient.Get($"{_nmkrUrl}/GetPaymentAddressForRandomNftSale/{projectuid}/{countnft}/{customeripaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddressForSpecificNftSale(string projectuid, int countnft, int lovelace, string customeripaddress, Action callback = null)
    {
        Busy = true;
        SetHeaders();

        RestClient.Get($"{_nmkrUrl}/GetPaymentAddressForSpecificNftSale/{projectuid}/{countnft}/{lovelace}/{customeripaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddressForSpecificNftSale(string projectuid, int countnft, string customeripaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPaymentAddressForRandomNftSale/{projectuid}/{countnft}/{customeripaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddressForSpecificNftSale(string customeripaddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPaymentAddressForRandomNftSale/{customeripaddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Tools
     */

    public void CheckIfEglibleForDiscount(string projectuid, string address, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckIfEglibleForDiscount/{projectuid}/{address}").Then(response =>
        {
            Result = JsonUtility.FromJson<CheckDiscountsResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckIfSaleConditionsMatch(string projectuid, string address, int countnft, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckIfSaleConditionsMatch/{projectuid}/{address}/{countnft}").Then(response =>
        {
            Result = JsonUtility.FromJson<CheckConditionsResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckUtxo(string address, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckUtxo/{address}").Then(response =>
        {
            Result = JsonUtility.FromJson<AssetsAssociatedWithAccount>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckAdaRates(Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckAdaRates").Then(response =>
        {
            Result = JsonUtility.FromJson<AdaRatesClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetAllAssetsInWallet(string address, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetAllAssetsInWallet/{address}").Then(response =>
        {
            Result = JsonUtility.FromJson<AssetsAssociatedWithAccount>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetAmountOfSpecificTokenInWallet(string address, string policyid, string tokenname, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetAmountOfSpecificTokenInWallet/{address}/{policyid}/{tokenname}").Then(response =>
        {
            Result = JsonUtility.FromJson<AssetsAssociatedWithAccount>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetAmountOfSpecificTokenInWallet(string policyid, string tokenname, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetAmountOfSpecificTokenInWallet/{policyid}/{tokenname}").Then(response =>
        {
            Result = JsonUtility.FromJson<AssetsAssociatedWithAccount>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetCardanoTokenRegistryInformation(string policyid, string tokenname, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetCardanoTokenRegistryInformation/{policyid}/{tokenname}").Then(response =>
        {
            Result = JsonUtility.FromJson<TokenRegistryMetadata>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPolicySnapshot(string policyid, bool cumulateStakeAddresses, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPolicySnapshot/{policyid}/{cumulateStakeAddresses}").Then(response =>
        {
            Result = JsonUtility.FromJson<NmkrAssetAddress[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetRoyaltyInformation(string policyid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetRoyaltyInformation/{policyid}").Then(response =>
        {
            Result = JsonUtility.FromJson<RoyaltyClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * NFT
     */


    public void CheckMetadata(string nftuid, UploadMetadataClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/CheckMetadata/{nftuid}", data).Then(response =>
        {
            Result = JsonUtility.FromJson<ApiErrorResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void DeleteNft(string nftuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/DeleteNft/{nftuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftDetailsClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetNftDetailsById(string nftuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetNftDetailsById/{nftuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftDetailsClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetNftDetailsByTokenName(string projectuid, string nftname, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetNftDetailsByTokenName/{projectuid}/{nftname}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftDetailsClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetNfts(string projectuid, string state, int count, int page, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetNfts/{projectuid}/{state}/{count}/{page}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftDetailsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UpdateMetadata(string projectuid, string nftuid, string metadata, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/UpdateMetadata/{projectuid}/{nftuid}", metadata).Then(response =>
        {
            Result = JsonUtility.FromJson<NftDetailsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UploadNft(string projectuid, UploadNftClassV2 data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/UploadNft/{projectuid}", data).Then(response =>
        {
            Result = JsonUtility.FromJson<UploadNftResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Wallet Validation
     */

    public void CheckWalletValidation(string validationuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CheckWalletValidation/{validationuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<CheckWalletValidationResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetWalletValidationAddress(string validationname, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetWalletValidationAddress/{validationname}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetWalletValidationAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetWalletValidationAddress(Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetWalletValidationAddress").Then(response =>
        {
            Result = JsonUtility.FromJson<GetWalletValidationAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Projects
     */

    public void CreateBurningAddress(string projectuid, string addressactiveinhours, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/CreateBurningAddress/{projectuid}/{addressactiveinhours}").Then(response =>
        {
            Result = JsonUtility.FromJson<BurningAddress>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CreateProject(NftProject data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/CreateProject", data).Then(response =>
        {
            Result = JsonUtility.FromJson<BurningAddress>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void DeleteProject(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/DeleteProject/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<ApiResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetCounts(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetCounts/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftCountsClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetDiscounts(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetDiscounts/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetDiscountsClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetIdentityAccounts(string policyid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetIdentityAccounts/{policyid}").Then(response =>
        {
            Result = JsonUtility.FromJson<Identity>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetNotifications(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetNotifications/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetNotificationsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPricelist(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetPricelist/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<PricelistClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetProjectDetails(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetProjectDetails/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftProjectsDetailsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetSaleConditions(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetSaleConditions/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetSaleconditionsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void ListProjects(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ListProjects/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftProjectsDetailsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void ListProjects(string projectuid, int count, int page, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ListProjects/{projectuid}/{count}/{page}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftProjectsDetailsClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UpdateDiscounts(string projectuid, GetDiscountsClass[] data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Put($"{_nmkrUrl}/UpdateDiscounts/{projectuid}", data).Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UpdateNotifications(string projectuid, GetNotificationsClass[] data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/UpdateNotifications/{projectuid}", data).Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UpdatePricelist(string projectuid, PricelistClassV2[] data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Put($"{_nmkrUrl}/UpdatePricelist/{projectuid}", data).Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void UpdateSaleConditions(string projectuid, SaleconditionsClassV2[] data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Put($"{_nmkrUrl}/UpdateSaleConditions/{projectuid}", data).Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Paymenttransactions
     */

    public void CreatePaymentTransaction(PaymentTransaction data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/CreatePaymentTransaction", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetTransactionState(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/GetTransactionState").Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPaymentAddress(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/GetPaymentAddress").Then(response =>
        {
            Result = JsonUtility.FromJson<GetPaymentAddressResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void SignDecentralPayment(string paymenttransactionuid, SignDecentralClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/SignDecentralPayment", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CheckPaymentAddress(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/CheckPaymentAddress").Then(response =>
        {
            Result = JsonUtility.FromJson<ApiResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CancelTransaction(string paymenttransactionuid, SignDecentralClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/CancelTransaction", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void CancelTransaction(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/CancelTransaction").Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void GetPriceListForProject(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/GetPriceListForProject").Then(response =>
        {
            Result = JsonUtility.FromJson<PricelistClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void LockNft(string paymenttransactionuid, SellerClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/LockNft", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void SubmitTransaction(string paymenttransactionuid, SubmitTransactionClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/SubmitTransaction", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void BetOnAuction(string paymenttransactionuid, SignDecentralClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/BetOnAuction", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void BuyDirectsale(string paymenttransactionuid, SignDecentralClass data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/BuyDirectsale", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void EndTransaction(string paymenttransactionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/EndTransaction").Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void ReservePaymentgatewayMintAndSendNft(string paymenttransactionuid, PaymentTransactionsMintAndSend data, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ProceedPaymentTransaction/{paymenttransactionuid}/ReservePaymentgatewayMintAndSendNft", data).Then(response =>
        {
            Result = JsonUtility.FromJson<PaymentTransactionResultClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Auctions
     */

    public void GetAuctionState(string auctionuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetAuctionState/{auctionuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<GetAuctionStateResultClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Smartcontracts
     */

    public void GetDatumInformationForSmartcontractDirectsaleTransaction(string txhash, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/GetDatumInformationForSmartcontractDirectsaleTransaction/{txhash}").Then(response =>
        {
            Result = JsonUtility.FromJson<SmartcontractDirectsaleDatumInformationClass[]>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Whitelists
     */

    public void ManageWhitelist(string projectuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/ManageWhitelist/{projectuid}").Then(response =>
        {
            Result = JsonUtility.FromJson<Whitelist>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void ManageWhitelist(string projectuid, string address, int countofnfts, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Post($"{_nmkrUrl}/ManageWhitelist/{projectuid}/{address}/{countofnfts}", null).Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void ManageWhitelist(string projectuid, string address, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Delete($"{_nmkrUrl}/ManageWhitelist/{projectuid}/{address}").Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }


    /*
     * Mint
     */

    public void MintAndSendRandom(string projectuid, int countofnfts, string receiveraddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/MintAndSendRandom/{projectuid}/{countofnfts}/{receiveraddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void MintAndSendSpecific(string projectuid, string nftuid, int tokencount, string receiveraddress, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/MintAndSendSpecific/{projectuid}/{nftuid}/{tokencount}/{receiveraddress}").Then(response =>
        {
            Result = JsonUtility.FromJson<NftClass>(response.Text);

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void MintRoyaltyToken(string projectuid, string royaltyaddress, float percentage, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/MintRoyaltyToken/{projectuid}/{royaltyaddress}/{percentage}").Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }

    public void RemintAndBurn(string projectuid, string nftuid, Action callback = null)
    {
        Busy = true;

        SetHeaders();
        RestClient.Get($"{_nmkrUrl}/RemintAndBurn/{projectuid}/{nftuid}").Then(response =>
        {
            Result = response;

            Busy = false;
            callback?.Invoke();
        }).Catch(ex =>
        {
            Debug.LogWarning(ex.Message);
            Result = null;

            Busy = false;
            callback?.Invoke();
        });
    }



    /*
     * NMKR Schemas
     */

    [Serializable]
    public class AdaRatesClass
    {
        public int usdRate;
        public int eurRate;
        public int jpyRate;
        public int btcRate;
        public DateTime effectivedate;
    }

    [Serializable]
    public class AddressTxInClass
    {
        public string address;
        public TxInClass[] utxo;
    }

    [Serializable]
    public class ApiErrorResultClass
    {
        public string resultState;
        public string errorMessage;
        public int errorCode;
        public string innerErrorMessage;
    }

    [Serializable]
    public class ApiResultClass
    {
        public string state;
        public int lovelace;
        public int hasToPay;
        public DateTime payDateTime;
        public DateTime expiresDateTime;
        public string transaction;
        public string senderAddress;
        public ReservedNft[] reservedNft;
        public string rejectReason;
        public string rejectParameter;
        public int stakeReward;
        public int discount;
        public string customProperty;
    }

    [Serializable]
    public class AssetsAssociatedWithAccount
    {
        public string unit;
        public int quantity;
    }

    [Serializable]
    public class AuctionsHistory
    {
        public string txHash;
        public string senderaddress;
        public int bidAmount;
        public DateTime created;
        public string state;
        public string returnTxHash;
    }

    [Serializable]
    public class AuctionHistoryResultClass
    {
        public string txHash;
        public int bidAmount;
        public DateTime created;
        public string state;
        public string address;
        public string returnTxHash;
        public bool signedAndSubmitted;
    }

    [Serializable]
    public class AuctionsNft
    {
        public string policyid;
        public string tokennamehex;
        public string ipfshash;
        public string metadata;
        public int tokencount;
    }

    [Serializable]
    public class AuctionParametersClass
    {
        public long durationInSeconds;
        public int minBet;
    }

    [Serializable]
    public class AuctionsResultClass
    {
        public string jsonHash;
        public int minBet;
        public DateTime runsUntil;
        public int actualBid;
        public AuctionHistoryResultClass[] history;
        public float marketplaceFeePercent;
        public float royaltyFeePercent;
    }

    [Serializable]
    public class BurningAddress
    {
        public string address;
        public DateTime validuntil;
    }

    [Serializable]
    public class CheckConditionsResultClass
    {
        public bool conditionsMet;
        public string rejectReason;
        public string rejectParameter;
        public FrankenAddressProtectionClass sendBackAddress;
        public bool blocked;
    }

    [Serializable]
    public class CheckDiscountsResultClass
    {
        public float discountInPercent;
    }

    [Serializable]
    public class CheckWalletValidationResultClass
    {
        public string validationResult;
        public string senderAddress;
        public string stakeAddress;
        public int lovelace;
        public string validationaddress;
        public DateTime validUntil;
        public string validationName;
    }

    [Serializable]
    public class CountedWhitelistAddressesClass
    {
        public string address;
        public int maxCount;
    }

    [Serializable]
    public class DecentralParameters
    {
        public MintNftsClass mintNfts;
        public RoyaltyClass createRoyaltyTokenIfNotExists;
    }

    [Serializable]
    public class DecentralParametersResultClass
    {
        public MintNftsResultClass mintNfts;
        public int priceInLovelace;
        public Tokens[] additionalPriceInTokens;
        public int stakeRewards;
        public int discount;
        public string rejectParameter;
        public string rejectReason;
    }

    [Serializable]
    public class DirectSaleParameters
    {
        public int priceInLovelace;
        public string txHashForAlreadyLockedinAssets;
    }

    [Serializable]
    public class DirectSaleResultsClass
    {
        public int sellingPrice;
        public int marketplaceAmount;
        public int sellerAmount;
        public int royaltyAmount;
        public int additionalPayoutAmount;
        public int lockedInAmount;
        public string sellerAddress;
        public string buyerAddress;
        public string sellerTxHash;
        public DateTime sellerTxCreate;
    }

    [Serializable]
    public class GetWalletValidationAddressResultClass
    {
        public string validationUId;
        public string address;
        public DateTime expires;
        public int lovelace;
    }

    [Serializable]
    public class FrankenAddressProtectionClass
    {
        public string address;
        public string originatorAddress;
        public string stakeAddress;
    }

    [Serializable]
    public class GetAuctionStateResultClass
    {
        public string auctionname;
        public string auctionType;
        public string address;
        public int minbet;
        public int actualbet;
        public DateTime runsuntil;
        public string selleraddress;
        public string highestbidder;
        public DateTime created;
        public string state;
        public int royaltyfeespercent;
        public string royaltyaddress;
        public int marketplacefeepercent;
        public AuctionsNft[] auctionsNfts;
        public AuctionsHistory[] auctionshistories;
    }

    [Serializable]
    public class GetDiscountsClass
    {
        public string condition;
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public int minOrMaxValue;
        public string description;
        public int discountInPercent;
    }

    [Serializable]
    public class GetNotificationsClass
    {
        public string notificationType;
        public string address;
        public bool isActive;
        public string secret;
    }

    [Serializable]
    public class GetPaymentAddressResultClass
    {
        public string paymentAddress;
        public int paymentAddressId;
        public DateTime expires;
        public string adaToSend;
        public string debug;
        public int priceInEur;
        public int priceInUsd;
        public int priceInJpy;
        public int priceInBtc;
        public DateTime effectivedate;
        public int priceInLovelace;
        public Tokens[] additionalPriceInTokens;
        public int sendbackToUser;
    }

    [Serializable]
    public class GetPayoutWalletsResultClass
    {
        public string walletAddress;
        public DateTime created;
        public string state;
        public string comment;
    }

    [Serializable]
    public class GetSaleconditionsClass
    {
        public string condition;
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public int minOrMaxValue;
        public string description;
        public string policyProjectname;
        public WhitelistetedCountClass[] whitelistedAddresses;
        public string[] blacklistedAddresses;
        public bool onlyOneSalePerWhitelistAddress;
        public WhitelistetedCountClass[] alreadyUsedAddressOrStakeaddress;
    }

    [Serializable]
    public class Identity
    {
        public DateTime date;
        public string policyId;
        public string[] accounts;
        public bool signatures;
    }

    [Serializable]
    public class MetadataPlaceholderClass
    {
        public string name;
        public string value;
    }

    [Serializable]
    public class MintNftsClass
    {
        public int countNfts;
        public ReservedNftsClassV2[] reserveNfts;
    }

    [Serializable]
    public class MintNftsResultClass
    {
        public int countNfts;
        public ReservedNftsClassV2[] reserveNfts;
    }

    [Serializable]
    public class NftClass
    {
        public int mintAndSendId;
        public NftDetailsClass[] sendedNft;
    }

    [Serializable]
    public class NftCountsClass
    {
        public int nftTotal;
        public int sold;
        public int free;
        public int reserved;
        public int error;
        public int blocked;
        public int totalTokens;
        public int totalBlocked;
    }

    [Serializable]
    public class NftDetailsClass
    {
        public int id;
        public string ipfshash;
        public string state;
        public string name;
        public string displayname;
        public string detaildata;
        public bool minted;
        public string receiveraddress;
        public DateTime selldate;
        public string soldby;
        public DateTime reserveduntil;
        public string policyid;
        public string assetid;
        public string assetname;
        public string fingerprint;
        public string initialminttxhash;
        public string title;
        public string series;
        public string ipfsGatewayAddress;
        public string metadata;
        public int singlePrice;
        public string uid;
        public string paymentGatewayLinkForSpecificSale;
        public int sendBackCentralPaymentInLovelace;
        public int priceInLovelaceCentralPayments;
    }

    [Serializable]
    public class NftFileV2
    {
        public string mimetype;
        public string fileFromBase64;
        public string fileFromsUrl;
        public string fileFromIPFS;
    }

    [Serializable]
    public class NftSubfileFileV2
    {
        public NftFileV2 subfile;
        public string description;
        public MetadataPlaceholderClass[] metadataPlaceholder;
    }

    [Serializable]
    public class NftProject
    {
        public string projectname;
        public string description;
        public string projecturl;
        public string tokennamePrefix;
        public string twitterHandle;
        public bool policyExpires;
        public DateTime policyLocksDateTime;
        public string payoutWalletaddress;
        public string payoutWalletaddressUsdc;
        public int maxNftSupply;
        public PolicyClass policy;
        public string metadataTemplate;
        public int addressExpiretime;
        public PricelistClassV2[] pricelist;
        public PayoutWalletsClassV2[] additionalPayoutWallets;
        public SaleconditionsClassV2[] saleConditions;
        public GetDiscountsClass[] discounts;
        public GetNotificationsClass[] notifications;
        public bool enableFiat;
        public bool enableDecentralPayments;
        public bool enableCrossSaleOnPaymentgateway;
        public bool activatePayinAddress;
        public DateTime paymentgatewaysalestart;
    }

    [Serializable]
    public class NftProjectsDetailsClass
    {
        public int id;
        public string projectname;
        public string projecturl;
        public string projectLogo;
        public string state;
        public int free;
        public int sold;
        public int reserved;
        public int total;
        public int blocked;
        public string uid;
        public int maxTokenSupply;
        public string description;
        public int addressReservationTime;
        public string policyId;
        public bool enableCrossSaleOnPaymentGateway;
        public string adaPayoutWalletAddress;
        public string usdcPayoutWalletAddress;
        public bool enableFiatPayments;
        public DateTime paymentGatewaySaleStart;
        public bool enableDecentralPayments;
        public DateTime policyLocks;
        public string royaltyAddress;
        public int royaltyPercent;
        public int lockslot;
        public bool disableManualMintingbutton;
        public bool disableRandomSales;
        public bool disableSpecificSales;
        public string twitterHandle;
    }

    [Serializable]
    public class NmkrAssetAddress
    {
        public string policyId;
        public string assetName;
        public string fingerprint;
        public int totalSupply;
        public int multiplier;
        public string address;
        public int quantity;
        public int decimals;
    }

    [Serializable]
    public class PaymentgatewayParametersClass
    {
        public MintNftsClass mintNfts;
    }

    [Serializable]
    public class PaymentgatewayResultsClass
    {
        public int priceInLovelace;
        public int fee;
        public int minUtxo;
        public MintNftsResultClass mintNfts;
        public Tokens[] additionalPriceInTokens;
    }

    public class PaymentTransaction
    {
        public string projectUid;
        public string paymentTransactionType;
        public TransactionParametersClass[] transactionParameters;
        public PaymentgatewayParametersClass paymentgatewayParameters;
        public DecentralParameters decentralParameters;
        public AuctionParametersClass auctionParametersClass;
        public DirectSaleParameters directSaleParameters;
        public string customerIpAddress;
        public PaymentTransactionNotification[] paymentTransactionNotifications;
        public string referer;
        public string referencedPaymenttransactionUid;
    }

    [Serializable]
    public class PaymentTransactionsMintAndSend
    {
        public string receiverAddress;
    }

    [Serializable]
    public class PaymentTransactionsMintAndSendResultClass
    {
        public string state;
        public string transactionId;
        public DateTime executed;
        public string receiverAddress;
    }

    [Serializable]
    public class PaymentTransactionNotification
    {
        public string notificationType;
        public string notificationEndpoint;
        public string hmacSecret;
    }

    [Serializable]
    public class PaymentTransactionResultClass
    {
        public string paymentTransactionUid;
        public string projectUid;
        public string paymentTransactionType;
        public string state;
        public TransactionParametersClass transactionParameters;
        public DateTime paymentTransactionCreated;
        public PaymentgatewayResultsClass paymentgatewayResults;
        public PaymentTransactionSubStateResultClass paymentTransactionSubStateResult;
        public AuctionsResultClass auctionResults;
        public DirectSaleResultsClass directSaleResults;
        public DecentralParametersResultClass decentralParameters;
        public PaymentTransactionsMintAndSendResultClass mintAndSendResults;
        public string cbor;
        public string signedCbor;
        public DateTime expires;
        public string signGuid;
        public int fee;
        public string txHash;
        public string nmkrPayUrl;
        public string customeripaddress;
        public string referer;
    }

    [Serializable]
    public class PaymentTransactionSubStateResultClass
    {
        public string paymentTransactionSubstate;
        public string lastTxHash;
    }

    [Serializable]
    public class PayoutWalletsClassV2
    {
        public string payoutWallet;
        public double valuePercent;
        public int valueFixInLovelace;
    }

    [Serializable]
    public class PolicyClass
    {
        public string policyId;
        public string privateVerifykey;
        public string privateSigningkey;
        public string policyScript;
    }

    [Serializable]
    public class PricelistClass
    {
        public int countNft;
        public int priceInLovelace;
        public string adaToSend;
        public int priceInEur;
        public int priceInUsd;
        public int priceInJpy;
        public int priceInBtc;
        public DateTime effectivedate;
        public Tokens[] additionalPriceInTokens;
        public string paymentGatewayLinkForRandomNftSale;
        public string currency;
        public int sendBackCentralPaymentInLovelace;
        public string sendBackCentralPaymentInAda;
        public int priceInLovelaceCentralPayments;
        public string adaToSendCentralPayments;
    }

    [Serializable]
    public class PricelistClassV2
    {
        public int countNft;
        public int priceInLovelace;
        public bool isActive;
        public DateTime validFrom;
        public DateTime validTo;
    }

    [Serializable]
    public class ProblemDetails
    {
        public string type;
        public string title;
        public int status;
        public string detail;
        public string instance;
    }

    [Serializable]
    public class RejectedErrorResultClass
    {
        public string resultState;
        public string errorMessage;
        public int errorCode;
        public string rejectReason;
        public string rejectParameter;
    }
    [Serializable]
    public class ReservedNft
    {
        public int id;
        public string uid;
        public string name;
        public string displayname;
        public string detaildata;
        public string ipfsLink;
        public string gatewayLink;
        public string state;
        public bool minted;
        public string policyId;
        public string assetId;
        public string assetname;
        public string fingerprint;
        public string initialMintTxHash;
        public string series;
        public int tokenamount;
        public int price;
        public DateTime selldate;
        public string paymentGatewayLinkForSpecificSale;
    }

    [Serializable]
    public class ReservedNftsClassV2
    {
        public string nftUid;
        public int tokencount;
        public string tokennameHex;
        public string policyId;
        public int nftId;
        public int lovelace;
    }

    [Serializable]
    public class ReserveMultipleNftsClassV2
    {
        public ReserveNftsClassV2[] reserveNfts;
    }

    [Serializable]
    public class ReserveNftsClassV2
    {
        public int lovelace;
        public string nftUid;
        public int tokencount;
    }

    [Serializable]
    public class RoyaltyClass
    {
        public int percentage;
        public string address;
        public string pkh;
    }

    [Serializable]
    public class SaleconditionsClassV2
    {
        public string condition;
        public string policyId1;
        public string policyId2;
        public string policyId3;
        public string policyId4;
        public string policyId5;
        public int minOrMaxValue;
        public string description;
        public bool isActive;
        public string policyProjectname;
        public string[] blacklistedAddresses;
        public CountedWhitelistAddressesClass[] countedWhitelistAddresses;
    }

    [Serializable]
    public class SellerClass
    {
        public TransactionAddressClass seller;
    }

    [Serializable]
    public class SignDecentralClass
    {
        public TransactionAddressClass buyer;
    }

    [Serializable]
    public class SmartcontractDirectsaleDatumInformationClass
    {
        public int totalPriceInLovelace;
        public string smartContractName;
        public string smartContractAddress;
        public string nmkrPayLink;
        public string preparedPaymentTransactionId;
        public string datumCbor;
        public SmartcontractDirectsaleReceiverClass[] receivers; 
    }

    [Serializable]
    public class SmartcontractDirectsaleReceiverClass
    {
        public string pkh;
        public string address;
        public int amountInLovelace;
    }

    [Serializable]
    public class SoldNftsOrTokensFromWhitelist
    {
        public string usedaddress;
        public string originatoraddress;
        public string transactionid;
        public DateTime created;
        public int countnft;
    }

    [Serializable]
    public class SubmitTransactionClass
    {
        public string signedCbor;
        public string signGuid;
    }

    [Serializable]
    public class TokenRegistryMetadata
    {
        public string name;
        public string description;
        public string ticker;
        public string url;
        public string logo;
        public int decimals;
    }

    [Serializable]
    public class Tokens
    {
        public int countToken;
        public string policyId;
        public string assetNameInHex;
        public int multiplier;
        public int totalCount;
        public string assetName;
        public int decimals;
    }

    [Serializable]
    public class TransactionAddressClass
    {
        public string pkh;
        public AddressTxInClass[] addresses;
        public string collateralTxIn;
        public string changeAddress;
    }

    [Serializable]
    public class TransactionParametersClass
    {
        public int tokencount;
        public string policyId;
        public string tokenname;
        public string tokennameHex;
    }

    [Serializable]
    public class TxInClass
    {
        public string txHash;
        public int txId;
        public int lovelace;
        public TxInTokensClass[] tokens;
        public string txHashId;
        public DateTime txTimestamp;
        public int tokenSum;
    }

    [Serializable]
    public class TxInTokensClass
    {
        public string policyId;
        public string tokenname;
        public string tokennameHex;
        public int quantity;
        public string tokenHex;
        public string token;
        public bool readOnly;
    }

    [Serializable]
    public class UploadMetadataClass
    {
        public string metadata;
    }

    [Serializable]
    public class UploadNftClassV2
    {
        public string tokenname;
        public string displayname;
        public string description;
        public NftFileV2 previewImageNft;
        public NftSubfileFileV2[] subfiles;
        public MetadataPlaceholderClass[] metadataPlaceholder;
        public string metadataOverride;
        public int priceInLovelace;
    }

    [Serializable]
    public class UploadNftResultClass
    {
        public int nftId;
        public string nftUid;
        public string ipfsHashMainnft;
        public string[] ipfsHashSubfiles;
        public string metadata;
        public string assetId;
    }

    [Serializable]
    public class Whitelist
    {
        public string addresss;
        public string stakeaddress;
        public int countNftsOrTokens;
        public DateTime created;
        public int totalSoldNftsOrTokens;
        public SoldNftsOrTokensFromWhitelist[] soldNftsOrTokens;
    }

    [Serializable]
    public class WhitelistetedCountClass
    {
        public string address;
        public int countNft;
        public string stakeAddress;
    }
}
