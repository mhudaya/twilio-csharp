using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    /// <summary>
    /// CreateFeedbackOptions
    /// </summary>
    public class CreateFeedbackOptions : IOptions<FeedbackResource> 
    {
        /// <summary>
        /// The account_sid
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// The message_sid
        /// </summary>
        public string PathMessageSid { get; }
        /// <summary>
        /// The outcome
        /// </summary>
        public FeedbackResource.OutcomeEnum Outcome { get; set; }

        /// <summary>
        /// Construct a new CreateFeedbackOptions
        /// </summary>
        ///
        /// <param name="pathMessageSid"> The message_sid </param>
        public CreateFeedbackOptions(string pathMessageSid)
        {
            PathMessageSid = pathMessageSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Outcome != null)
            {
                p.Add(new KeyValuePair<string, string>("Outcome", Outcome.ToString()));
            }

            return p;
        }
    }

}