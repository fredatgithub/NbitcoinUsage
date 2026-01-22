using NBitcoin;
using Newtonsoft.Json;
using System.Net;

namespace NbitcoinUsage
{
  public class BitcoinFeeEstimator
  {
    private const string FeeApiUrl = "https://mempool.space/api/v1/fees/recommended";

    public MempoolFeeEstimate GetFeeEstimate()
    {
      using (var client = new WebClient())
      {
        var json = client.DownloadString(FeeApiUrl);
        return JsonConvert.DeserializeObject<MempoolFeeEstimate>(json);
      }
    }

    public FeeRate GetFeeRateFast()
    {
      var fees = GetFeeEstimate();
      return new FeeRate(Money.Satoshis(fees.fastestFee), 1);
    }

    public FeeRate GetFeeRateNormal()
    {
      var fees = GetFeeEstimate();
      return new FeeRate(Money.Satoshis(fees.hourFee), 1);
    }
  }
}
