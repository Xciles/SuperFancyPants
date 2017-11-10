using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SuperUserWeb.Utils
{
    public class Email : TagHelper
    {
        private const string EmailDomain = "hotelkamer.nu";

        // MailTo > mailTo > mail-to
        public string MailTo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <email> with <a> tag

            var address = MailTo + "@" + EmailDomain;
            output.Attributes.SetAttribute("href", "mailto:" + address);
            output.Content.SetContent(address);
        }
    }
}