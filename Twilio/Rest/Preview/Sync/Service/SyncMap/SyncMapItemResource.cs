using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class SyncMapItemResource : Resource 
    {
        public sealed class QueryResultOrderEnum : StringEnum 
        {
            private QueryResultOrderEnum(string value) : base(value) {}
            public QueryResultOrderEnum() {}
        
            public static readonly QueryResultOrderEnum Asc = new QueryResultOrderEnum("asc");
            public static readonly QueryResultOrderEnum Desc = new QueryResultOrderEnum("desc");
        }
    
        public sealed class QueryFromBoundTypeEnum : StringEnum 
        {
            private QueryFromBoundTypeEnum(string value) : base(value) {}
            public QueryFromBoundTypeEnum() {}
        
            public static readonly QueryFromBoundTypeEnum Inclusive = new QueryFromBoundTypeEnum("inclusive");
            public static readonly QueryFromBoundTypeEnum Exclusive = new QueryFromBoundTypeEnum("exclusive");
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <returns> SyncMapItemFetcher capable of executing the fetch </returns> 
        public static SyncMapItemFetcher Fetcher(string serviceSid, string mapSid, string key)
        {
            return new SyncMapItemFetcher(serviceSid, mapSid, key);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <returns> SyncMapItemDeleter capable of executing the delete </returns> 
        public static SyncMapItemDeleter Deleter(string serviceSid, string mapSid, string key)
        {
            return new SyncMapItemDeleter(serviceSid, mapSid, key);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncMapItemCreator capable of executing the create </returns> 
        public static SyncMapItemCreator Creator(string serviceSid, string mapSid, string key, Object data)
        {
            return new SyncMapItemCreator(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <returns> SyncMapItemReader capable of executing the read </returns> 
        public static SyncMapItemReader Reader(string serviceSid, string mapSid)
        {
            return new SyncMapItemReader(serviceSid, mapSid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> The map_sid </param>
        /// <param name="key"> The key </param>
        /// <param name="data"> The data </param>
        /// <returns> SyncMapItemUpdater capable of executing the update </returns> 
        public static SyncMapItemUpdater Updater(string serviceSid, string mapSid, string key, Object data)
        {
            return new SyncMapItemUpdater(serviceSid, mapSid, key, data);
        }
    
        /// <summary>
        /// Converts a JSON string into a SyncMapItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapItemResource object represented by the provided JSON </returns> 
        public static SyncMapItemResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncMapItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; set; }
        [JsonProperty("map_sid")]
        public string MapSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("revision")]
        public string Revision { get; set; }
        [JsonProperty("data")]
        public Object Data { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
    
        public SyncMapItemResource()
        {
        
        }
    
        private SyncMapItemResource([JsonProperty("key")]
                                    string key, 
                                    [JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("service_sid")]
                                    string serviceSid, 
                                    [JsonProperty("map_sid")]
                                    string mapSid, 
                                    [JsonProperty("url")]
                                    Uri url, 
                                    [JsonProperty("revision")]
                                    string revision, 
                                    [JsonProperty("data")]
                                    Object data, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("created_by")]
                                    string createdBy)
                                    {
            Key = key;
            AccountSid = accountSid;
            ServiceSid = serviceSid;
            MapSid = mapSid;
            Url = url;
            Revision = revision;
            Data = data;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            CreatedBy = createdBy;
        }
    }
}