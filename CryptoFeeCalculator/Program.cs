using System;

namespace CryptoFeeCalculator
{
  internal class Program
  {
    static void Main()
    {
      Console.WriteLine("=== Crypto Withdrawal Fee Calculator ===");

      // Entrée utilisateur
      Console.Write("Montant à retirer (BTC) : ");
      string input = Console.ReadLine();
      if (!decimal.TryParse(input, out decimal amountBtc) || amountBtc <= 0)
      {
        Console.WriteLine("Montant invalide.");
        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
        return;
      }

      Console.Write("Cours BTC vs EUR (ex: 25000) : ");
      string inputRate = Console.ReadLine();
      if (!decimal.TryParse(inputRate, out decimal btcRate) || btcRate <= 0)
      {
        Console.WriteLine("Cours invalide.");
        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
        return;
      }

      // Frais fixes / variables (BTC)
      decimal feeCryptoCom = 0.0005m;
      decimal feeBinance = 0.0002m;
      decimal feeCoinbase = 0.0004m;

      // Calcul montant reçu après frais
      decimal netCryptoCom = amountBtc - feeCryptoCom;
      decimal netBinance = amountBtc - feeBinance;
      decimal netCoinbase = amountBtc - feeCoinbase;

      // Conversion en EUR
      decimal feeCryptoComEur = feeCryptoCom * btcRate;
      decimal feeBinanceEur = feeBinance * btcRate;
      decimal feeCoinbaseEur = feeCoinbase * btcRate;

      // Affichage résultats
      Console.WriteLine("\n=== Résultat ===");
      Console.WriteLine($"Crypto.com : Frais {feeCryptoCom} BTC (~{feeCryptoComEur:F2} EUR), Net reçu {netCryptoCom} BTC");
      Console.WriteLine($"Binance    : Frais {feeBinance} BTC (~{feeBinanceEur:F2} EUR), Net reçu {netBinance} BTC");
      Console.WriteLine($"Coinbase   : Frais {feeCoinbase} BTC (~{feeCoinbaseEur:F2} EUR), Net reçu {netCoinbase} BTC");

      // Comparaison simple
      decimal minFee = Math.Min(feeCryptoCom, Math.Min(feeBinance, feeCoinbase));
      Console.WriteLine("\nPlateforme avec le frais le plus bas : " +
          (minFee == feeCryptoCom ? "Crypto.com" :
           minFee == feeBinance ? "Binance" : "Coinbase"));

      Console.WriteLine("\nAppuyez sur une touche pour quitter...");
      Console.ReadKey();
    }
  }
}
