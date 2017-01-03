using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StateDefinitionService.saveeventdata
{
    public static class Receiver
    {
        static WEnterprise.State _state;
        public static string getStatusCode(string input)
        {
            if (_state == null)
                _state = new WEnterprise.State();              
            
            bool isSecond = CheckStatusCode(input);
            
            string result = string.Empty;
            if (isSecond)
            {
                List<MessageT2> items = JsonConvert.DeserializeObject<List<MessageT2>>(input);
                foreach (var item in items)
                {
                    result = _state.SetMessage(item.deviceID, item.latitude, item.longitude, item.timestamp, (int)item.speedKPH);
                    ResultMessage rm = JsonConvert.DeserializeObject<ResultMessage>(result);
                    _state.SetDumpMessage(item.deviceID, item.timestamp, rm.transportStatusID, item.latitude, item.longitude, item.altitude, item.heading, item.speedKPH);
                    //
                    var nowtime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    TXTWriter.Writetime(string.Format("{0};{1};{2};{3};{4}\n", item.deviceID, item.timestamp, nowtime, item.latitude, item.longitude));
                }
            }
            else
            {
                List<TrackMessage> items = JsonConvert.DeserializeObject<List<TrackMessage>>(input);
                foreach (var item in items)
                {
                    result = _state.SetMessage(item.deviceID, item.latitude, item.longitude, item.timestamp, (int)item.speedKPH);
                    ResultMessage rm = JsonConvert.DeserializeObject<ResultMessage>(result);
                    _state.SetDumpMessage(item.deviceID, item.timestamp, rm.transportStatusID, item.latitude, item.longitude, item.altitude, item.heading, item.speedKPH);
                    //
                    var nowtime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                    TXTWriter.Writetime(string.Format("{0};{1};{2};{3};{4}\n", item.deviceID, item.timestamp, nowtime, item.latitude, item.longitude));
                }
            }
            
            TXTWriter.Write(string.Format("{0}\n", result));
            
            return result;
        }
        static bool CheckStatusCode(string input)
        {
            string pattern = @"statusCode:\d+,";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(input);
        }
        static bool CheckDriverMessage(string input)
        {
            string pattern = @"driverMessage:.+,";
            Regex reg = new Regex(pattern);
            return reg.IsMatch(input);
        }
    }
    public class TrackMessage
    {
        public string deviceID;
        public int timestamp;
        public double latitude;
        public double longitude;
        public double speedKPH;
        public double heading;
        public double altitude;
    }
    class MessageT2
    {
        public string deviceID;
        public int timestamp;
        public string statusCode;
        public double latitude;
        public double longitude;
        public double speedKPH;
        public double heading;
        public double altitude;
    }
    public class ResultMessage
    {
        public int timestamp;
        public int transportID;
        public int transportStatusID;
        public double rockMass;
    }
}