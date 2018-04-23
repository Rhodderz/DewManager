using System.Diagnostics;
using System.IO;
using System.Linq;
using DewManager.Configs;

namespace DewManager.Parsers
{
    public class CfgParse
    {
        public static DewritoConfig LoadCfg(string filePath)
        {
            DewritoConfig dewritoConfig = new DewritoConfig();

            Debug.WriteLine("FilePath:::::::" + filePath);
            Debug.WriteLine("FilePath1:::::::" + Path.GetFileNameWithoutExtension(filePath));
            dewritoConfig.ConfigName = Path.GetFileNameWithoutExtension(filePath);
            
            using (StreamReader r = new StreamReader(filePath))
            {
                string line;
                while((line = r.ReadLine()) != null)
                {
                    string key = line.Split(' ')[0];
                    string[] values = line.Split(' ').Skip(1).ToArray();

                    if (key.Contains("Input.") | string.IsNullOrEmpty(key) | string.IsNullOrWhiteSpace(key))
                    {
                        //Dont want to handle the inputs. This is a server so not required.
                    }
                    else
                    {
                        dewritoConfig.ConfigLines.Add(new DewritoConfigLine(key, values));
                    }
                }
            }

            return dewritoConfig;
        }
    }
}