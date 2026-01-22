using NBitcoin;
using Newtonsoft.Json;
using System;
using System.Net;

namespace NbitcoinUsage
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      // list all methods from NBitcoin
      var estimator = new BitcoinFeeEstimator();

      FeeRate fast = estimator.GetFeeRateFast();
      FeeRate normal = estimator.GetFeeRateNormal();

      Console.WriteLine($"Fast fee   : {fast.SatoshiPerByte} sat/vB");
      Console.WriteLine($"Normal fee : {normal.SatoshiPerByte} sat/vB");

      // Exemple : estimation pour une transaction SegWit (~140 vBytes)
      int txSize = 140;

      Money estimatedFee = fast.GetFee(txSize);
      Console.WriteLine($"Estimated network fee: {estimatedFee.ToDecimal(MoneyUnit.BTC)} BTC");

      Display("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
