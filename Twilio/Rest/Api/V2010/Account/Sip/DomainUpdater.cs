using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class DomainUpdater : Updater<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string AuthType { get; set; }
        public string FriendlyName { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Twilio.Http.HttpMethod VoiceStatusCallbackMethod { get; set; }
        public Uri VoiceStatusCallbackUrl { get; set; }
        public Uri VoiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new DomainUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DomainUpdater(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override async System.Threading.Tasks.Task<DomainResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + Sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return DomainResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override DomainResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + Sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return DomainResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (AuthType != null)
            {
                request.AddPostParam("AuthType", AuthType);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (VoiceFallbackMethod != null)
            {
                request.AddPostParam("VoiceFallbackMethod", VoiceFallbackMethod.ToString());
            }
            
            if (VoiceFallbackUrl != null)
            {
                request.AddPostParam("VoiceFallbackUrl", VoiceFallbackUrl.ToString());
            }
            
            if (VoiceMethod != null)
            {
                request.AddPostParam("VoiceMethod", VoiceMethod.ToString());
            }
            
            if (VoiceStatusCallbackMethod != null)
            {
                request.AddPostParam("VoiceStatusCallbackMethod", VoiceStatusCallbackMethod.ToString());
            }
            
            if (VoiceStatusCallbackUrl != null)
            {
                request.AddPostParam("VoiceStatusCallbackUrl", VoiceStatusCallbackUrl.ToString());
            }
            
            if (VoiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", VoiceUrl.ToString());
            }
        }
    }
}