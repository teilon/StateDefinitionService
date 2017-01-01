using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StateDefinitionService.saveeventdata
{
    public static class Receiver
    {
        static WEnterprise.State _state;
        public static string getStatusCode(string input)
        {
            if (_state == null)
                _state = new WEnterprise.State();            
            List<TrackMessage> items = JsonConvert.DeserializeObject<List<TrackMessage>>(input);
            string result = string.Empty;
            foreach (var item in items)
            {
                result = _state.SetMessage(item.deviceID, item.latitude, item.longitude, item.timestamp, (int)item.speedKPH);
                ResultMessage rm = JsonConvert.DeserializeObject<ResultMessage>(result);
                _state.SetDumpMessage(item.deviceID, item.timestamp, rm.transportStatusID, item.latitude, item.longitude, item.altitude, item.heading, item.speedKPH);
                //
                var nowtime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                TXTWriter.Writetime(string.Format("{0};{1};{2};{3};{4}\n", item.deviceID, item.timestamp, nowtime, item.latitude, item.longitude));
            }
            TXTWriter.Write(string.Format("{0}\n", result));
            
            return result;
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
    public class ResultMessage
    {
        public int timestamp;
        public int transportID;
        public int transportStatusID;
        public double rockMass;
    }
}