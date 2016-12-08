using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class ChannelResource : Resource 
    {
        public sealed class ChannelTypeEnum : StringEnum 
        {
            private ChannelTypeEnum(string value) : base(value) {}
            public ChannelTypeEnum() {}
        
            public static readonly ChannelTypeEnum Public = new ChannelTypeEnum("public");
            public static readonly ChannelTypeEnum Private = new ChannelTypeEnum("private");
        }
    
        private static Request BuildFetchRequest(FetchChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ChannelResource Fetch(FetchChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(FetchChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ChannelResource Fetch(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchChannelOptions(serviceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchChannelOptions(serviceSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelOptions(serviceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelOptions(serviceSid, sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static ChannelResource Create(CreateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(CreateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static ChannelResource Create(string serviceSid, string friendlyName = null, string uniqueName = null, string attributes = null, ChannelResource.ChannelTypeEnum type = null, ITwilioRestClient client = null)
        {
            var options = new CreateChannelOptions(serviceSid){FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(string serviceSid, string friendlyName = null, string uniqueName = null, string attributes = null, ChannelResource.ChannelTypeEnum type = null, ITwilioRestClient client = null)
        {
            var options = new CreateChannelOptions(serviceSid){FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ChannelResource> Read(ReadChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<ChannelResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(ReadChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<ChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<ChannelResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ChannelResource> Read(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadChannelOptions(serviceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadChannelOptions(serviceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<ChannelResource> NextPage(Page<ChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.IpMessaging,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ChannelResource>.FromJson("channels", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateChannelOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static ChannelResource Update(UpdateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(UpdateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static ChannelResource Update(string serviceSid, string sid, string friendlyName = null, string uniqueName = null, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new UpdateChannelOptions(serviceSid, sid){FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(string serviceSid, string sid, string friendlyName = null, string uniqueName = null, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new UpdateChannelOptions(serviceSid, sid){FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChannelResource object represented by the provided JSON </returns> 
        public static ChannelResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ChannelResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ChannelResource.ChannelTypeEnum Type { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private ChannelResource()
        {
        
        }
    }

}