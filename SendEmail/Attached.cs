using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace SendEmail
{
    public sealed class Attached
    {
        private string urlProp;
        private string MediaTypeProp;
        public string url
        {
            get { return urlProp; }
            set
            {
                if (string.IsNullOrEmpty(value) == false 
                    && string.IsNullOrWhiteSpace(value) == false
                    && value.Contains(".") == true)
                    urlProp = value;
                else
                    throw new ArgumentException("Url can not be empty or check if extension is included: ", nameof(urlProp) + "=>" + value);
            }
        }
        public string MediaType
        {
            get { return MediaTypeProp; }
            set
            {
                var temp = this.getExtension(urlProp);
                if (MediaType == null)
                    MediaTypeProp = "";
               MediaTypeProp = temp;
            }
        }
        private string getExtension(string file)
        {
            if (file.Contains(".") == false)
                return null;
            
            var returnVal = file.Substring(file.LastIndexOf(".") + 1);
            //var temp = MediaTypeNames;
            return returnVal;
        }

        //public Attached() { }

        public Attached(string url, string mediaType)
        {
            this.url = url;
            MediaType = mediaType;
        }
    }
}