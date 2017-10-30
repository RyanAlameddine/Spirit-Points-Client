using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiritPointsClient
{
    public class SheetsManager
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Spirit Points Client";
        static SheetsService service;

        /*
            Ninth = "B",
            Tenth = "C",
            Eleventh = "D",
            Twelfth = "E",
            Middle = "F"
        */

        static SheetsManager()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-spirit-points-client.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        static int FindDateRow(string date)
        {
            // Define request parameters. Spirit Points 1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY
            String spreadsheetId = "1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY";
            String range = "SPData!A:A";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            int matching = -1;
            //values[Row#][ColumnABC]
            if (values != null && values.Count > 0)
            {
                for(int i = 0; i < values.Count; i++)
                {
                    if(values[i][0].ToString() == date)
                    {
                        matching = i + 1;
                        break;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("Could not find google sheet");
            }
            if (matching == -1) throw new Exception("Date not found");

            return matching;
        }

        static int FindCurrentPoints(char gradeLetter, int dateRow)
        {
            // Define request parameters. Spirit Points 1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY
            String spreadsheetId = "1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY";
            String range = "SPData!" + gradeLetter + dateRow;
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            return int.Parse(values[0][0].ToString());
        }

        public static void AddPoints(int points, char gradeLetter, string date)
        {
            int dateRow = FindDateRow(date);
            points = FindCurrentPoints(gradeLetter, dateRow) + points;
            String spreadsheetId = "1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY";
            String range = "SPData!" + gradeLetter + dateRow;
            ValueRange valueRange = new ValueRange();
            Object[] value = new Object[1];
            value[0] = points;
            valueRange.Values = new List<IList<Object>>();
            valueRange.Values.Add(value);
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            UpdateValuesResponse result = request.Execute();
        }
    }
}
