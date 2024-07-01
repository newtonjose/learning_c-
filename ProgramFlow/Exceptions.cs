using System;
using System.Net.Http;

namespace learning_c_sharp.ProgramFlow;

public class Exceptions
{
    public decimal Balance { get; private set; }
    
    public static void nutshell()
    {
        int x = 100;
        int y = 10;
        int result;

        try {
            if (x > 1000) {
                throw new ArgumentOutOfRangeException("x","x has to be 1000 or less");
            }
            result = x / y;
            Console.WriteLine("The result is: {0}", result);
        }
        catch (DivideByZeroException e) {
            Console.WriteLine("Whoops!");
            Console.WriteLine(e.Message);
        }
        catch (ArgumentOutOfRangeException e) {
            Console.WriteLine("Sorry, 1000 is the limit");
            Console.WriteLine(e.Message);
        }
        finally {
            Console.WriteLine("This code always runs.");
        }
    }

    public static void custom()
    {
        
    }
}


public class CurrencyConverter(IExchangeRateProvider exchangeRateProvider)
{
    private readonly IExchangeRateProvider _exchangeRateProvider = exchangeRateProvider;

    public decimal convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (string.IsNullOrWhiteSpace(fromCurrency) || string.IsNullOrWhiteSpace(toCurrency))
        {
            throw new ArgumentException("Source and target currencies cannot be empty.");
        }

        if (string.Equals(fromCurrency, toCurrency, StringComparison.CurrentCultureIgnoreCase))
        {
            return amount;
        }

        try
        {
            var exchangeRates = _exchangeRateProvider.GetExchangeRates(fromCurrency);
            if (!exchangeRates.TryGetValue(toCurrency, out decimal value))
            {
                throw new InvalidOperationException($"Exchange rate not found for {toCurrency}.");
            }

            var exchangeRate = value;
            return amount * exchangeRate;
        }
        catch (ErrorFetchingException? ex)
        {
            throw new CurrencyConversionException("Error fetching exchange rates.", ex);
        }
    }
}

public interface IExchangeRateProvider
{
    Dictionary<string, decimal> GetExchangeRates(string baseCurrency);
}

public class CurrencyConversionException(string message, Exception? innerException = null)
    : Exception(message, innerException);

public class ErrorFetchingException(string message) : Exception(message);
