using System;

namespace rates.Entity
{
    public class Error
    {
        public string Information { get; set; }
       


        // Required for deserialization (uses reflection)
        public Error()
        {

        }


        public Error(
            string information)
        {
            this.Information = information;
        }
    }
}