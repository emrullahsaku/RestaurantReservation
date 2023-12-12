﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Is_Sistem.Application.Services;

namespace Is_Sistem.Api.IntegrationTests.Helpers.Services;

public class TemplateTestService : ITemplateService
{
    public async Task<string> GetTemplateAsync(string templateName)
    {
        await Task.Delay(100);
        return "{UserId} + {Token}";
    }

    public string ReplaceInTemplate(string input, IDictionary<string, string> replaceWords)
    {
        var response = string.Empty;

        foreach (var (key, value) in replaceWords)
            response = input.Replace(key, value);

        return response;
    }
}
