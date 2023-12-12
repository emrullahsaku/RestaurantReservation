﻿using System.Net.Http;
using System.Threading.Tasks;
using Is_Sistem.Application.Models;
using Newtonsoft.Json;

namespace Is_Sistem.Api.IntegrationTests.Helpers;

public static class ResponseHelper
{
    public static async Task<ApiResult<T>> GetApiResultAsync<T>(HttpResponseMessage responseMessage)
    {
        return JsonConvert.DeserializeObject<ApiResult<T>>(await responseMessage.Content.ReadAsStringAsync());
    }
}
