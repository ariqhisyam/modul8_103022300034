using System;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Text.Json;


class transfer
{
    public int treshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }



}

class confirmation {

    public string en { get; set; }
    public string id { get; set; }
   

}

class BahasaConfig {

    public string lang { get; set; } 
    public transfer Transfer { get; set; }

    public string[] method { get; set; }
    public confirmation Confiramtion { get; set; }



    

    public static BahasaConfig LoadFromFile(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<BahasaConfig>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading config: {ex.Message}");
            return null;
        }
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving config: {ex.Message}");
        }
    }

   

    class Program {

        static void Main() { 
       
            string configFilePath = @"D:\modul8_103022300034\modul8_103022300034\bank_transfer_config.json";
            BahasaConfig config = BahasaConfig.LoadFromFile(configFilePath);

            while (true) {

                Console.WriteLine("Current Language: " + config.lang);
                Console.WriteLine("Please insert the amount of money to transfer");
                int input = int.Parse(Console.ReadLine());




                if (input <= config.Transfer.treshold) {
                    
                 Console.WriteLine("The transfer fee is " + config.Transfer.low_fee);

                }
                else
                {
                    Console.WriteLine("The transfer fee is " + config.Transfer.high_fee);
                }

            }

            
            {
                
            }

        }
    
    }

}

