using UnityEngine;
using System;
#if WINDOWS_UWP 
using System.Collections;
using Nethereum.Web3;
#endif
public class BlockNumber : MonoBehaviour {


    private static DateTime LastTimeAccessed; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
#if WINDOWS_UWP 
        if (LastTimeAccessed.AddSeconds(5) < DateTime.Now)
        {
            try
            {

                //Note: in this sample, a special INFURA API key is used: `7238211010344719ad14a89db874158c`. If you wish to use this sample in your own project you’ll need to [sign up on INFURA](https://infura.io/register) and use your own key.
                var web3 = new Web3("https://goerli.infura.io/v3/7238211010344719ad14a89db874158c");
                var blockNumber = web3.Eth.Blocks.GetBlockNumber.SendRequestAsync().Result;
                   GetComponent<TextMesh>().text = "Last block:" + blockNumber.Value.ToString();
                LastTimeAccessed = DateTime.Now;
            }
            catch (Exception ex)
            {
                GetComponent<TextMesh>().text = ex.Message + ex.StackTrace;
            }
        }
#endif
    }
}
