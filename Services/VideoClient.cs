using Azure.Core;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Options;
using VISample.Models;
using Microsoft.Extensions.Logging;

namespace VISample.Services;

public class VideoClient
{
    private readonly ILogger<VideoClient> _logger;
    private readonly TokenCredential _creds;
    private readonly HttpClient _http;
    private string _accessToken = String.Empty;
    private readonly IOptions<VideoIndexerOptions> _options;
    private string _location = String.Empty;
    private string _accountId = String.Empty;

    public VideoClient(
        ILogger<VideoClient> logger,
        TokenCredential creds,
        HttpClient http,
        IOptions<VideoIndexerOptions> options)
    {
        _logger = logger;
        _creds = creds;
        _http = http;
        _options = options;
    }

    internal async Task AuthorizeAsync(CancellationToken ct = default)
    {
        try
        {
            //TODO: Use token caching
            var tokenRequestContext = new TokenRequestContext(new[] { "https://management.azure.com/.default" });
            var tokenRequestResult = await _creds.GetTokenAsync(tokenRequestContext, ct);
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenRequestResult.Token);

            var requestUri = $"https://management.azure.com/subscriptions/{_options.Value.SubscriptionId}/resourcegroups/{_options.Value.ResourceGroup}/providers/Microsoft.VideoIndexer/accounts/{_options.Value.AccountName}/generateAccessToken?api-version={_options.Value.ApiVersion}";
            var result = await _http.PostAsJsonAsync(requestUri, new { scope = "Account", permissionType = "Contributor" }, ct);

            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync(ct);
            _accessToken = JsonObject.Parse(json)!["accessToken"]!.GetValue<string>();

            requestUri = $"https://management.azure.com/subscriptions/{_options.Value.SubscriptionId}/resourcegroups/{_options.Value.ResourceGroup}/providers/Microsoft.VideoIndexer/accounts/{_options.Value.AccountName}?api-version={_options.Value.ApiVersion}";
            json = await _http.GetAsync(requestUri, ct).Result.Content.ReadAsStringAsync(ct);
            var props = JsonObject.Parse(json)!;
            _location = props["location"]!.GetValue<string>();
            _accountId = props["properties"]!["accountId"]!.GetValue<string>();
            _http.DefaultRequestHeaders.Authorization = null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;

        }
    }

    internal async Task<string> FileUploadAsync(string videoName, string mediaPath, string exludedAIs = null)
    {
        if (!File.Exists(mediaPath))
            throw new Exception($"Could not find file at path {mediaPath}");

        await AuthorizeAsync();
        var queryParams = new Dictionary<string, string>
        {
            { "name", videoName },
            { "description", "video_description" },
            { "privacy", "private" },
            { "accessToken" , _accessToken },
            { "partition", "partition" },
        };
        //TODO: Add support for excludedAIs
        var queryString = new FormUrlEncodedContent(queryParams).ReadAsStringAsync().Result;

        var url = $"https://api.videoindexer.ai/{_location}/Accounts/{_accountId}/Videos?{queryString}";
        using var content = new MultipartFormDataContent();
        await using var fileStream = new FileStream(mediaPath, FileMode.Open, FileAccess.Read);
        using var streamContent = new StreamContent(fileStream);
        content.Add(streamContent, "fileName", Path.GetFileName(mediaPath));
        var response = await _http.PostAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
        return response.ToString();
    }
}
