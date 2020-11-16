using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using sep3tier3.Models;

namespace sep3tier3.Data
{
    public class msgService : ImsgService
    {
        private string msgFile = "msgs.json";
        private List<msg> _msgs;

        public msgService()
        {
            string content = File.ReadAllText(msgFile);
            _msgs = JsonSerializer.Deserialize<List<msg>>(content);
        }
        private void WriteToFile() {
            string productsAsJson = JsonSerializer.Serialize(_msgs);
            File.WriteAllText(msgFile, productsAsJson);
        }
        
        public async Task<msg> AddMsgAsync(msg msg)
        {
            _msgs.Add(msg);
            WriteToFile();
            return msg;
        }

        public async Task<string> GetAllMsgAsync()
        {
            return await File.ReadAllTextAsync(msgFile);
        }
    }
}