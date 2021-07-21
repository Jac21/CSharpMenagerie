using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MicroPostService.Data
{
    public static class ConnectionUtilities
    {
        public static void CreateConnectionStringsListFromConfiguration(IConfiguration configuration,
            ICollection<string> connectionStringsList)
        {
            var connectionStrings = configuration.GetSection("PostDbConnectionStrings");

            foreach (var connectionString in connectionStrings.GetChildren())
            {
                connectionStringsList.Add(connectionString.Value);
            }
        }

        public static string GetConnectionString(List<string> connectionStrings, string category)
        {
            using var md5 = MD5.Create();

            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(category));

            var x = BitConverter.ToUInt16(hash, 0) % connectionStrings.Count;

            return connectionStrings[x];
        }
    }
}