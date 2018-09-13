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

        static float FindCurrentPoints(char gradeLetter, int dateRow)
        {
            // Define request parameters. Spirit Points 1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY
            String spreadsheetId = Program.SpreadSheetId;
            String range = "SPData!" + gradeLetter + dateRow;
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            return float.Parse(values[0][0].ToString());
        }

        public static void AddPoints(string spreadsheetName, float points, string name, string eventName)
        {
            int nameRow = FindNameRow(spreadsheetName, name);

            String spreadsheetId = Program.SpreadSheetId;

            int row = FindNameRow(spreadsheetName, name);
            int columnIndex = FindActiveColumn(spreadsheetName, row);
            string column = letterFromIndex(columnIndex);

            String range = $"{spreadsheetName}!{column}{row}:{letterFromIndex(columnIndex + 1)}{row}";
            ValueRange valueRange = new ValueRange();
            Object[] value = { eventName, points };
            valueRange.Values = new List<IList<Object>>();
            valueRange.Values.Add(value);
            var request = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            AppendValuesResponse result = request.Execute();
        }
        static int FindNameRow(string spreadsheetName, string name)
        {
            // Define request parameters. Spirit Points 1qUOR2PH9xDhnlcazhRDe4_EQ6zdpZVAK923nHXdKsZY
            String spreadsheetId = Program.SpreadSheetId;
            String range = $"{spreadsheetName}!A:A";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            int matching = -1;
            //values[Row#][ColumnABC]
            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i][0].ToString() == name)
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

        public static string CreateXML(List<string> seventh, List<string> eighth, List<string> freshman, List<string> sophomore, List<string> junior, List<string> senior)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<optgroup label=\"Seventh\">");
            foreach (string name in seventh)
            {
                stringBuilder.Append("<option value=\"Seventh.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");

            stringBuilder.AppendLine("<optgroup label=\"Eighth\">");
            foreach (string name in eighth)
            {
                stringBuilder.Append("<option value=\"Eighth.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");


            stringBuilder.AppendLine("<optgroup label=\"Freshman\">");
            foreach (string name in freshman)
            {
                stringBuilder.Append("<option value=\"Freshman.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");


            stringBuilder.AppendLine("<optgroup label=\"Sophomore\">");
            foreach (string name in sophomore)
            {
                stringBuilder.Append("<option value=\"Sophomore.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");


            stringBuilder.AppendLine("<optgroup label=\"Junior\">");
            foreach (string name in junior)
            {
                stringBuilder.Append("<option value=\"Junior.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");


            stringBuilder.AppendLine("<optgroup label=\"Senior\">");
            foreach (string name in senior)
            {
                stringBuilder.Append("<option value=\"Senior.");
                stringBuilder.Append(name);
                stringBuilder.Append("\">");
                stringBuilder.Append(name);
                stringBuilder.AppendLine("</option>");
            }
            stringBuilder.AppendLine("</optgroup>");

            return stringBuilder.ToString();
        }

        static int FindActiveColumn(string spreadsheetName, int row)
        {
            // Define request parameters.
            String spreadsheetId = Program.SpreadSheetId;
            String range = $"{spreadsheetName}!C{row}:{row}";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            //values[Row#][ColumnABC]
            if (values == null) return 3;
            return values[0].Count + 3;
        }
        private static string letterFromIndex(int index)
        {
            int dividend = index;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }


        public static void CreateSheet(string sheetName, List<string> names)
        {
            String spreadsheetId = Program.SpreadSheetId;

            setTitles(sheetName, spreadsheetId);

            insertData(sheetName, spreadsheetId, names);

            #region finalData
            String range = sheetName + "!A1:B1";
            ValueRange valueRange = new ValueRange();
            Object[] value = { "Total Score", $"=SUM(B3:B{names.Count + 3 - 1})" };
            valueRange.Values = new List<IList<Object>>();
            valueRange.Values.Add(value);
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            UpdateValuesResponse result = request.Execute();
            #endregion finalData
        }
        private static void setTitles(string sheetName, string spreadsheetId)
        {
            String range = sheetName + "!A2:H2";
            ValueRange valueRange = new ValueRange();
            Object[] value = { "Name", "Individual Score", "Event", "Points", "Event", "Points", "Event", "Points" };
            valueRange.Values = new List<IList<Object>>();
            valueRange.Values.Add(value);
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            UpdateValuesResponse result = request.Execute();
        }
        private static void insertData(string sheetName, string spreadsheetId, List<string> names)
        {
            int count = names.Count;

            String range = sheetName + "!A3:B" + (3 + count - 1);
            ValueRange valueRange = new ValueRange();
            valueRange.Values = new List<IList<Object>>();
            for (int i = 0; i < count; i++)
            {
                Object[] func = { names[i], $"=SUM(C{i + 3}:{i + 3})" };
                valueRange.Values.Add(func);
            }
            var request = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            UpdateValuesResponse result = request.Execute();
        }
    }
}
