using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISample.Models;

public class VideoIndexerOptions
{
    public string SubscriptionId { get; set; }
    public string ResourceGroup { get; set; }
    public string AccountName { get; set; }
    public string ApiVersion { get; set; }
}
