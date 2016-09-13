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
                var web3 = new Web3("https://morden.infura.io/aEcNY6wGN4KuEpoXQRxZ");
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
