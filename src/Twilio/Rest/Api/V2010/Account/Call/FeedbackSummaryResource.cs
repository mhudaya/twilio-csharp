using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    /// <summary>
    /// FeedbackSummaryResource
    /// </summary>
    public class FeedbackSummaryResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}

            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
        }

        private static Request BuildCreateRequest(CreateFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/FeedbackSummary.json",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static FeedbackSummaryResource Create(CreateFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> CreateAsync(CreateFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="includeSubaccounts"> The include_subaccounts </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static FeedbackSummaryResource Create(DateTime? startDate, DateTime? endDate, string pathAccountSid = null, bool? includeSubaccounts = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackSummaryOptions(startDate, endDate){PathAccountSid = pathAccountSid, IncludeSubaccounts = includeSubaccounts, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="includeSubaccounts"> The include_subaccounts </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> CreateAsync(DateTime? startDate, DateTime? endDate, string pathAccountSid = null, bool? includeSubaccounts = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateFeedbackSummaryOptions(startDate, endDate){PathAccountSid = pathAccountSid, IncludeSubaccounts = includeSubaccounts, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/FeedbackSummary/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static FeedbackSummaryResource Fetch(FetchFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> FetchAsync(FetchFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static FeedbackSummaryResource Fetch(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackSummaryOptions(pathSid){PathAccountSid = pathAccountSid};
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<FeedbackSummaryResource> FetchAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchFeedbackSummaryOptions(pathSid){PathAccountSid = pathAccountSid};
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteFeedbackSummaryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/Calls/FeedbackSummary/" + options.PathSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static bool Delete(DeleteFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete FeedbackSummary parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFeedbackSummaryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of FeedbackSummary </returns> 
        public static bool Delete(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteFeedbackSummaryOptions(pathSid){PathAccountSid = pathAccountSid};
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        /// <param name="pathAccountSid"> The account_sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of FeedbackSummary </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteFeedbackSummaryOptions(pathSid){PathAccountSid = pathAccountSid};
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a FeedbackSummaryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackSummaryResource object represented by the provided JSON </returns> 
        public static FeedbackSummaryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FeedbackSummaryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The call_count
        /// </summary>
        [JsonProperty("call_count")]
        public int? CallCount { get; private set; }
        /// <summary>
        /// The call_feedback_count
        /// </summary>
        [JsonProperty("call_feedback_count")]
        public int? CallFeedbackCount { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The end_date
        /// </summary>
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; private set; }
        /// <summary>
        /// The include_subaccounts
        /// </summary>
        [JsonProperty("include_subaccounts")]
        public bool? IncludeSubaccounts { get; private set; }
        /// <summary>
        /// The issues
        /// </summary>
        [JsonProperty("issues")]
        public List<FeedbackIssue> Issues { get; private set; }
        /// <summary>
        /// The quality_score_average
        /// </summary>
        [JsonProperty("quality_score_average")]
        public decimal? QualityScoreAverage { get; private set; }
        /// <summary>
        /// The quality_score_median
        /// </summary>
        [JsonProperty("quality_score_median")]
        public decimal? QualityScoreMedian { get; private set; }
        /// <summary>
        /// The quality_score_standard_deviation
        /// </summary>
        [JsonProperty("quality_score_standard_deviation")]
        public decimal? QualityScoreStandardDeviation { get; private set; }
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The start_date
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; private set; }
        /// <summary>
        /// The status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedbackSummaryResource.StatusEnum Status { get; private set; }

        private FeedbackSummaryResource()
        {

        }
    }

}